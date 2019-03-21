using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.Core.DataGenerators
{
    public static class GameDataGenerator
    {
        static readonly string[] teamNames = { "Split", "Zagreb", "Osijek", "Rijeka", "Dubrovnik", "Pariz", "London", "Moskva", "München", "Atena" };

        public static List<GameDomainModel> GenerateGames() {
            var games = new List<GameDomainModel>();
            foreach (GameType sportType in Enum.GetValues(typeof(GameType)))
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

        private static string GetNamePrefixBySportType(GameType type)
        {
            switch (type)
            {
            case GameType.Football:
                return "NK. ";
            case GameType.Basketball:
                return "KK. ";
            case GameType.Handball:
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
                    CoefficientValue = (float)(rand.Next(1, 3) + Math.Round(rand.NextDouble(), 2))
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
