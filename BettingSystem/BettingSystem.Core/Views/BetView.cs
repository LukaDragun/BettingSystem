using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.Views
{
    public class BetView
    {
        public int Id { get; set; }
        public ICollection<GameResolutionView> Games { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsResolved { get; set; }
        public float BetValue { get; set; }
        public bool IsResolvable { get; set; }
    }
}
