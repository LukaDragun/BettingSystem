using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Entities
{
    public class BetCoefficient
    {
        public BetCoefficient() { }

        public int BetId { get; set; }
        public Bet Bet { get; set; }
        public int CoefficientId { get; set; }
        public Coefficient Coefficient { get; set; }
    }
}
