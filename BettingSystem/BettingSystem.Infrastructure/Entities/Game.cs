using BettingSystem.Common.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Common.Infrastructure.Entities
{
    public class Game
    {
        public int GameID { get; set; }
        public SportType GameType { get; set; } 
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
        public DateTime DateTimeStarting { get; set; }
        public DateTime? DateTimePlayed { get; set; }


        public virtual ICollection<Coefficient> Coefficients { get; set; }
    }
}
