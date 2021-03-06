﻿using BettingSystem.Common.Core.Enums;
using BettingSystem.Core.BaseInterfaces;
using BettingSystem.Core.Views;

namespace BettingSystem.Core.InfrastructureContracts.Queries
{
    public interface IGameQuery : IQuery<GameView>
    {
        IGameQuery WhereUnresolved();
        IGameQuery WhereGameType(GameType type);

        GameOfferView AsGameOfferView();
    }
}
