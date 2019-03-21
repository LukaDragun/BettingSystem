using BettingSystem.Common.Core.Enums;
using System;

namespace BettingSystem.Core.Views
{
    public class GameResolutionView
    {
        public GameType GameType { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public DateTime DateTimeStarting { get; set; }
        public DateTime? DateTimePlayed { get; set; }
        public bool IsGuessed {get; set;}
        public BetType BetType { get; set; }
        public float CoefficientValue { get; set; }
    }
}
