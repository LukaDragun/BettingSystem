using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.InfrastructureContracts
{
    public interface IBaseRepository<T> where T : BaseDomainModel
    {
        void Create(T domainModel);
        void Delete(int id);
        void Update(T domainModel);
    }
}
