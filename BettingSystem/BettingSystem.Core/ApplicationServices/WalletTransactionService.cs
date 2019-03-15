using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.DomainModels;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.ApplicationServices
{
    public class WalletTransactionService
    {

        private readonly IWalletTransactionRepository walletTransactionRepository;

        public WalletTransactionService(IWalletTransactionRepository walletTransactionRepository)
        {
            this.walletTransactionRepository = walletTransactionRepository;
        }


        public bool AddFunds(int value)
        {
            var transaction = new WalletTransactionDomainModel{
                TransactionType = TransactionType.Deposit,
                TransactionValue = value
            };

            return walletTransactionRepository.Create(transaction);
        }

    }
}
