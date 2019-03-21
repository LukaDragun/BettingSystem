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

        private readonly IBetRepository betRepository;
        private readonly IBetQuery betQuery;
        private readonly WalletTransactionService walletTransactionService;

        public BetService(IBetRepository betRepository, IBetQuery betQuery, WalletTransactionService walletTransactionService)
        {
            this.betRepository = betRepository;
            this.betQuery = betQuery;
            this.walletTransactionService = walletTransactionService;
        }

        public void PlaceBet(BetDto dto)
        {

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
            return bet.BetValue * bet.Games.Select(e => e.CoefficientValue).Aggregate((float)1.0, (x, y) => x * y);
        }

    }
}
