using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.InfrastructureContracts
{
    public interface IGameRepository : IBaseRepository<GameDomainModel>
    {
    }
}
