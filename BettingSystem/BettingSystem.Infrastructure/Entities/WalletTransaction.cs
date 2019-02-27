using BettingSystem.Common.Core.Enums;

namespace BettingSystem.Infrastructure.Entities
{
    public class WalletTransaction : BaseEntity
    {
        public WalletTransaction() { }

        public float TransactionValue { get; set; }
        public TransactionType TransactionType { get; set; }
        public int? BetId { get; set; }

        public virtual Bet Bet { get; set; }
    }
}
