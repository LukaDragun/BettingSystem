using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.DataGenerators;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using System;

namespace BettingSystem.Core.ApplicationServices
{
    public class GameService
    {
        private readonly IGameRepository gameRepository;
        private readonly BetService betService;

        public GameService(IGameRepository gameRepository, BetService betService)
        {
            this.gameRepository = gameRepository;
            this.betService = betService;
        }

        public void GenerateAndResolveGames() {
            ResolveGames(true);

            var games = GameDataGenerator.GenerateGames();
            gameRepository.CreateMany(games);
        }

        private void ResolveGames(bool resolveAllGames = false) //development test mode
        {

            var games = gameRepository.GetUnresolvedGames();
            foreach (var game in games)
            {
                if(resolveAllGames)
                    game.ResolveWithRandomResult(game.DateTimeStarting.AddMinutes(GetPlayTimeByGameType(game.GameType)));
                else if(game.DateTimeStarting.AddMinutes(GetPlayTimeByGameType(game.GameType)) <= DateTime.Now)
                    game.ResolveWithRandomResult(DateTime.Now);
            }

            gameRepository.UpdateMany(games);

            betService.ResolvePendingBets();
        }

        private int GetPlayTimeByGameType(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.Football:
                    return 90;
                case GameType.Basketball:
                    return 40;
                case GameType.Handball:
                    return 60;
                default:
                    throw new Exception("Sport not supported");
            }
        }
    }
}
