using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.BaseInterfaces
{
    public interface IRepository<T> where T : BaseDomainModel
    {
        void Create(T domainModel);
        void CreateMany(ICollection<T> domainModels);
        void Update(T domainModel);
        void UpdateMany(ICollection<T> domainModels);
    }
}
