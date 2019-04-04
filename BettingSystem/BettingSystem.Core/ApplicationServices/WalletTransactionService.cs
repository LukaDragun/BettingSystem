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


        public int AddFunds(int value)
        {
            var transaction = new WalletTransactionDomainModel();

            transaction.AddDeposit(value);

            return walletTransactionRepository.Create(transaction);
        }

        public IEnumerable<int> CreateTransactionsForBets(ICollection<Tuple<BetDomainModel, float>> betTransactions)
        {
            var transactions = new List<WalletTransactionDomainModel>();

            foreach (var betTransaction in betTransactions)
            {
                var transaction = new WalletTransactionDomainModel();
                transaction.AddBetWithValue(betTransaction.Item1, betTransaction.Item2);
                transactions.Add(transaction);
            }

            return walletTransactionRepository.CreateMany(transactions);
        }
        
    }
}
