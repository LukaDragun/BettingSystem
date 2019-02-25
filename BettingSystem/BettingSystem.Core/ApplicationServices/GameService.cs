using BettingSystem.Core.DataGenerators;
using BettingSystem.Core.InfrastructureContracts.Repositories;

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
            var games = GameDataGenerator.GenerateGames();

            gameRepository.CreateMany(games);
        }

    }
}
