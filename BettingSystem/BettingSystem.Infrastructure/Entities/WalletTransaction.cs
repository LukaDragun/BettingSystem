using BettingSystem.Common.Core.Enums;

namespace BettingSystem.Common.Infrastructure.Entities
{
    public class WalletTransaction
    {
        public int TransactionId { get; set; }
        public float TransactionValue { get; set; }
        public TransactionType TransactionType { get; set; }


        public virtual Bet Bet { get; set; }
    }
}
