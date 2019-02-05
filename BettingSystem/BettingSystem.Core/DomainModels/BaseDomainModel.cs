using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.DomainModels
{
    public class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public void SetCreateDateTime()
        {
            CreatedDateTime = DateTime.Now;
            SetUpdateDateTime();
        }

        public void SetUpdateDateTime()
        {
            UpdatedDateTime = DateTime.Now;
        }
    }
}
