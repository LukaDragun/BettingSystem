using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BettingSystem.Tests
{
    public class WalletTransactionSpecs
    {

        [Fact]
        public void Deposit_transaction_should_not_be_negative()
        {
            var transaction = new WalletTransactionDomainModel()
            {
                TransactionType = Common.Core.Enums.TransactionType.Deposit,
                TransactionValue = -20
            };

            Assert.Throws<Exception>(() => transaction.ErrorCheck());
        }

        [Fact]
        public void Bet_transaction_should_not_be_positive()
        {
            var transaction = new WalletTransactionDomainModel()
            {
                TransactionType = Common.Core.Enums.TransactionType.Bet,
                TransactionValue = 20
            };

            Assert.Throws<Exception>(() => transaction.ErrorCheck());
        }

    }
}
