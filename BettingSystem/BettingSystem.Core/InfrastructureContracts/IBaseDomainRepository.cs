using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.InfrastructureContracts
{
    public interface IBaseDomainRepository<T> where T : BaseDomainModel
    {
        T GetById(int id);
        void Create(T domainModel);
        void Delete(int id);
        void Update(T domainModel);
    }
}
