using BettingSystem.Core.DataGenerators;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using System;

namespace BettingSystem.Core.ApplicationServices
{
    public class GameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public void GenerateAndResolveGames() {
           /* var games = GameDataGenerator.GenerateGames();
            gameRepository.CreateMany(games);*/

            ResolveGames(true);
        }

        private void ResolveGames(bool resolveAllGames = false) //development test mode
        {

            var games = gameRepository.GetUnresolvedGames();
            foreach (var game in games)
            {
                if(resolveAllGames)
                game.ResolveWithRandomResult(DateTime.Now);
            }

            gameRepository.UpdateMany(games);
        }


    }
}
