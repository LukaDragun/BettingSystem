using System;
using System.Collections.Generic;

namespace BettingSystem.Core.Views
{
    public class GameView
    {
        public int Id { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public DateTime DateTimeStarting { get; set; }
        public DateTime? DateTimePlayed { get; set; }

        public ICollection<CoefficientView> Coefficients { get; set; }
    }
}
