using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using BettingSystem.Core.TransferObjects;
using BettingSystem.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.Core.ApplicationServices
{
    public class BetService
    {
        private static readonly int MIN_BET_VALUE = 5;
        private readonly IBetRepository betRepository;
        private readonly IBetQuery betQuery;
        private readonly IGameQuery gameQuery;
        private readonly IWalletTransactionQuery walletTransactionQuery;
        private readonly WalletTransactionService walletTransactionService;

        public BetService(IBetRepository betRepository, IBetQuery betQuery, IGameQuery gameQuery, IWalletTransactionQuery walletTransactionQuery, WalletTransactionService walletTransactionService)
        {
            this.betRepository = betRepository;
            this.betQuery = betQuery;
            this.gameQuery = gameQuery;
            this.walletTransactionQuery = walletTransactionQuery;
            this.walletTransactionService = walletTransactionService;
        }

        public void PlaceBet(BetDto dto)
        {
            var offer = gameQuery.AsGameOfferView();
            var bestOffersCoefficients = offer.BestOffers.SelectMany(e => e.Coefficients).Where(e => dto.CoefficientIds.Contains(e.Id));
            var allOffersCoefficients = offer.OtherOffers.SelectMany(e => e.Coefficients).Concat(bestOffersCoefficients).Where(e => dto.CoefficientIds.Contains(e.Id));

            if(allOffersCoefficients.Count() == 0)
            {
                throw new Exception("At least one current offer coefficient needs to be selected.");
            }

            if(allOffersCoefficients.GroupBy(x => x.GameId).Any(g => g.Count() > 1))
            {
                throw new Exception("There can only be one coefficient selected per offered game in a bet.");
            }

            if (bestOffersCoefficients.Count() > 2)
            {
                throw new Exception("There can only be one special offer coefficient selected per bet.");
            }

            var totalFunds = walletTransactionQuery.AsTotalFundsView(includeTransactions: false);

            if(MIN_BET_VALUE >= dto.BetValue || dto.BetValue >= totalFunds.TotalFunds)
            {
                throw new Exception("You can only bet if you have sufficient funds (minimum: "+ MIN_BET_VALUE + ")");
            }

            var bet = new BetDomainModel{
                Coefficients = betRepository.GetCoefficientsForBet(dto.CoefficientIds)
            };

            bet.Id = betRepository.Create(bet);

            var transaction = new WalletTransactionDomainModel();
            transaction.AddBetWithValue(bet,dto.BetValue);

            walletTransactionService.CreateTransactionsForBets(new List<Tuple<BetDomainModel, float>>() { new Tuple<BetDomainModel, float>(bet, dto.BetValue) });
        }

        public void ResolvePendingBets()
        {
            var bets = betRepository.GetUnresolvedBets();

            var betStatuses = betQuery.WhereBetIds(bets.Select(e => e.Id)).Project().ToArray();

            var betTransactions = new List<Tuple<BetDomainModel, float>>();

            foreach(var bet in bets)
            {
                var betStatus = betStatuses.FirstOrDefault(e => e.Id == bet.Id);
                if (betStatus != null && betStatus.IsResolvable && !betStatus.IsResolved)
                {
                    bet.Resolve();

                    if (betStatus.Games.All(e => e.IsGuessed))
                    {
                        betTransactions.Add(new Tuple<BetDomainModel, float>(bet, CalculateProfit(betStatus)));
                    }
                }
            }

            betRepository.UpdateMany(bets);

            walletTransactionService.CreateTransactionsForBets(betTransactions);
        }

        private float CalculateProfit(BetView bet)
        {
            return (float)Math.Round((decimal)bet.BetValue * bet.Games.Select(e => e.CoefficientValue).Aggregate((decimal)0.95, (x, y) => x * (decimal)y),2);
        }

    }
}
