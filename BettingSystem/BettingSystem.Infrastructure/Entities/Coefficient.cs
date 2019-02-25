using BettingSystem.Common.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Entities
{
    public class Coefficient : BaseEntity
    {
        public Coefficient() { }

        public BetType BetType { get; set; }
        public float CoefficientValue { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<BetCoefficient> BetCoefficients { get; set; }
    }
}
