using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Core.BaseInterfaces;
using BettingSystem.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BettingSystem.Infrastructure.Queries
{
    public abstract class BaseQuery<TView, TEntity> : IQuery<TView>
        where TEntity : BaseEntity
    {
        protected readonly IQueryable<TEntity> inner;

        public BaseQuery(BettingSystemDatabaseContext context)
        {
            this.inner = context.Set<TEntity>();
        }

        public BaseQuery(IQueryable<TEntity> inner)
        {
            this.inner = inner;
        }

        public abstract IQueryable<TView> Project();
    }
}
