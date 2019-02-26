using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.Core.DataGenerators
{
    public static class GameDataGenerator
    {
        static readonly string[] teamNames = { "Hajduk", "Dinamo", "Osijek", "Rijeka", "Dubrovnik", "Pariz", "London", "Moskva", "München", "Atena" };

        public static List<GameDomainModel> GenerateGames() {
            var games = new List<GameDomainModel>();
            foreach (SportType sportType in Enum.GetValues(typeof(SportType)))
            {

                var teamNames = GetRandomTeamNames();

                for (var i = 0; i < teamNames.Length - 1; i += 2)
                {
                    var game = new GameDomainModel()
                    {
                        FirstTeamName = GetNamePrefixBySportType(sportType) + teamNames[i],
                        SecondTeamName = GetNamePrefixBySportType(sportType) + teamNames[i+1],
                        DateTimeStarting = GetRandomTime(),
                        GameType = sportType
                    };

                    game.AddCoeficients(GenerateRandomCoefficients());

                    games.Add(game);
                }               
            }

            return games;
        }

        private static string GetNamePrefixBySportType(SportType type)
        {
            switch (type)
            {
            case SportType.Football:
                return "NK. ";
            case SportType.Basketball:
                return "KK. ";
            case SportType.Handball:
                return "RK. ";
            default:
                    return "";
            }   
        }

        private static DateTime GetRandomTime()
        {
            Random rand = new Random();
            var time = DateTime.Now;
            time = time.AddMinutes(rand.Next(1, 59));
            return time;
        }


        private static List<CoefficientDomainModel> GenerateRandomCoefficients() {
            Random rand = new Random();
            var items = new List<CoefficientDomainModel>();
            var numberOfCoefficients = rand.Next(1, Enum.GetValues(typeof(BetType)).Length);
            var coefficients = Enum.GetValues(typeof(BetType)).Cast<int>().ToList().OrderBy(x => rand.Next()).ToArray();
            for (var i = 0; i < numberOfCoefficients; i++)
            {
                var coefficient = new CoefficientDomainModel
                {
                    BetType = (BetType)coefficients[i],
                    CoefficientValue = (float)(rand.Next(1, 3) + rand.NextDouble())
                };

                items.Add(coefficient);
            }

            return items;
        }

        private static string[] GetRandomTeamNames()
        {
            Random rand = new Random();
            return teamNames.ToList().OrderBy(x => rand.Next()).ToArray();
        }
    }
}
