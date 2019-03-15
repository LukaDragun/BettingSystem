using BettingSystem.Common.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.Views
{
    public class WalletTransactionView
    {
        public DateTime DateTimeUpdated {get; set;}
        public float TransactionValue { get; set; }
        public TransactionType TransactionType { get; set; }
        public int? BetId { get; set; }
    }
}
