using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Common.Infrastructure.Entities
{
    public class Bet
    {
        public int BetId { get; set; }
        public DateTime DateTimeMade { get; set; }


        public  virtual WalletTransaction Transaction { get; set; }
        public virtual ICollection<Coefficient> Coefficients { get; set; }
    }
}
