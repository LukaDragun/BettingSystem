﻿using BettingSystem.Common.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.Core.DomainModels
{
    public class GameDomainModel : BaseDomainModel
    {
        public GameDomainModel()
        {
            Coefficients = new List<CoefficientDomainModel>();
        }

        public GameType GameType { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public DateTime DateTimeStarting { get; set; }
        public DateTime? DateTimePlayed { get; set; }

        public List<CoefficientDomainModel> Coefficients { get; set; }

        public void AddCoeficients(ICollection<CoefficientDomainModel> coefficients)
        {
            Coefficients.AddRange(coefficients);
            ErrorCheck();
        }

        public void ResolveWithRandomResult(DateTime dateTimePlayed)
        {
            var rand = new Random();
            FirstTeamScore = rand.Next(1, 7);
            SecondTeamScore = rand.Next(1, 7);
            DateTimePlayed = dateTimePlayed;

            ErrorCheck();
        }

        public void ErrorCheck()
        {
            if(!DateTimePlayed.HasValue && (FirstTeamScore.HasValue || SecondTeamScore.HasValue))
            throw new Exception("Cannot change score before game is played");
            if (DateTimePlayed.HasValue && DateTimeStarting > DateTimePlayed)
            throw new Exception("Time Played cannot be before starting time");
            if (Coefficients != null && Coefficients.GroupBy(e => e.BetType).Any(e => e.Count() >= 2))
            throw new Exception("There cannot be 2 coefficients of same type");
        }
    }
}
