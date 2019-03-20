using BettingSystem.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Core.BaseInterfaces
{
    public interface IRepository<T> where T : BaseDomainModel
    {
        int Create(T domainModel);
        IEnumerable<int> CreateMany(ICollection<T> domainModels);
        bool Update(T domainModel);
        bool UpdateMany(ICollection<T> domainModels);
    }
}
