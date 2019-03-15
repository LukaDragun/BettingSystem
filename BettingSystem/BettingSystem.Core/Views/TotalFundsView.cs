using System.Collections.Generic;

namespace BettingSystem.Core.Views
{
    public class TotalFundsView
    {
        public float TotalFunds { get; set; }
        public ICollection<WalletTransactionView> Transactions { get; set; }
    }
}
