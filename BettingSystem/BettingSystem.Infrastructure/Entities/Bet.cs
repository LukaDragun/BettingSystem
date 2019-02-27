using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Entities
{
    public class Bet : BaseEntity
    {
        public Bet() { }

        public bool IsResolved { get; set; }

        public WalletTransaction Transaction { get; set; }
        public virtual ICollection<BetCoefficient> BetCoefficients { get; set; }
    }
}
