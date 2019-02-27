using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Entities
{
    public class BetCoefficient
    {
        public BetCoefficient() { }

        public int BetId { get; set; }
        public virtual Bet Bet { get; set; }
        public int CoefficientId { get; set; }
        public virtual Coefficient Coefficient { get; set; }
    }
}
