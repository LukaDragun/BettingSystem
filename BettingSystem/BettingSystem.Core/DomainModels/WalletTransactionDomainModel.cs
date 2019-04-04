using BettingSystem.Common.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.DomainModels
{
    public class WalletTransactionDomainModel : BaseDomainModel
    {
        public WalletTransactionDomainModel()
        {
        }

        public float TransactionValue { get; set; }
        public TransactionType TransactionType { get; set; }

        public BetDomainModel Bet { get; set; }

        public void AddDeposit(float value)
        {
            TransactionType = TransactionType.Deposit;
            TransactionValue = value;
            ErrorCheck();
        }

        public void AddBetWithValue(BetDomainModel bet, float value)
        {
            if (bet.IsResolved)
            {
                TransactionType = TransactionType.Win;
                TransactionValue = value;
            }
            else
            {
                TransactionType = TransactionType.Bet;
                TransactionValue = -value;
            }

            Bet = bet;
            ErrorCheck();
        }

        public void ErrorCheck()
        {
            if ((TransactionType == TransactionType.Win || TransactionType == TransactionType.Deposit) && TransactionValue <= 0)
                throw new Exception("Transaction cannot be zero or negative for Deposit or Win");
            if (TransactionType == TransactionType.Bet && TransactionValue >= 0)
                throw new Exception("Transaction cannot be zero or positive for Bet");
        }
    }
}
