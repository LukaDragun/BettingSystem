using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Entities
{
    public class Bet : BaseEntity
    {
        public Bet() { }


        public WalletTransaction Transaction { get; set; }
        public ICollection<BetCoefficient> BetCoefficients { get; set; }
    }
}
