using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Common.Infrastructure.Entities
{
    public class Bet : BaseEntity
    {
        public Bet() { }


        public  virtual WalletTransaction Transaction { get; set; }
        public virtual ICollection<Coefficient> Coefficients { get; set; }
    }
}
