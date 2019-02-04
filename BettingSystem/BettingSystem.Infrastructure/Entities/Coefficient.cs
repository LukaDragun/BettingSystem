using BettingSystem.Common.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Common.Infrastructure.Entities
{
    public class Coefficient
    {
        public int GameID { get; set; }
        public BetType BetType { get; set; }
        public float CoefficientValue { get; set; }


        public virtual Game Game { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
