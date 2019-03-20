using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using BettingSystem.Core.TransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.Core.ApplicationServices
{
    public class BetService
    {

        private readonly IWalletTransactionRepository walletTransactionRepository;
        private readonly IBetRepository betRepository;

        public BetService(IWalletTransactionRepository walletTransactionRepository, IBetRepository betRepository)
        {
            this.walletTransactionRepository = walletTransactionRepository;
            this.betRepository = betRepository;
        }

        public void PlaceBet(BetDto dto)
        {

            var bet = new BetDomainModel{
                Coefficients = betRepository.GetCoefficientsForBet(dto.CoefficientIds)
            };

            bet.Id = betRepository.Create(bet);

            var transaction = new WalletTransactionDomainModel();
            transaction.AddBetWithValue(bet,dto.BetValue);

            walletTransactionRepository.Create(transaction);
        }

    }
}
