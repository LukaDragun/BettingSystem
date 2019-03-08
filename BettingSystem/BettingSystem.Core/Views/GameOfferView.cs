using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.Views
{
    public class GameOfferView
    {
        public ICollection<GameView> BestOffers { get; set; }
        public ICollection<GameView> OtherGames { get; set; }
    }
}
