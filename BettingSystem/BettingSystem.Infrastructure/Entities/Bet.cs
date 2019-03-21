using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Entities
{
    public class Bet : BaseEntity
    {
        public Bet() { }

        public bool IsResolved { get; set; }

        public ICollection<WalletTransaction> Transactions { get; set; }
        public virtual ICollection<BetCoefficient> BetCoefficients { get; set; }
    }
}
