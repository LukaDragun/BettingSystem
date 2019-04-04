using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.DomainModels;
using System;
using Xunit;

namespace BettingSystem.Tests
{
    public class GameSpecs
    {
        [Fact]
        public void Game_should_not_have_score_if_not_played()
        {
            var game = new GameDomainModel()
            {
                FirstTeamScore = 3,
                SecondTeamScore = 2
            };

            Assert.Throws<Exception>(() => game.ErrorCheck());
        }

        [Fact]
        public void Game_should_not_be_played_before_started()
        {
            var game = new GameDomainModel()
            {
               DateTimePlayed = DateTime.Now.AddSeconds(-1),
               DateTimeStarting = DateTime.Now
            };

            Assert.Throws<Exception>(() => game.ErrorCheck());
        }


        [Fact]
        public void Game_should_not_have_two_same_types_of_coefficients()
        {
            var game = new GameDomainModel();

            Assert.Throws<Exception>(() => game.AddCoeficients(new CoefficientDomainModel[] { new CoefficientDomainModel(BetType.One, 3), new CoefficientDomainModel(BetType.One, 2) }));
        }

    }
}
