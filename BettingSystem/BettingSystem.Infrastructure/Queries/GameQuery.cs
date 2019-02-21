using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Core.InfrastructureContracts;
using BettingSystem.Infrastructure.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Infrastructure.Queries
{
    /*class GameQuery : IQuery<BaseView>
    {

        private readonly IQueryable<Bet> inner;

        GameQuery(BettingSystemDatabaseContext context)
        {
            this.inner = context.Set<Bet>();
        }

        GameQuery(GameQuery previous) {
            this.inner = previous.inner.to;
        }

        toTEST()
        {
            return new GameQuery(this.inner.Where())
        }

        public BaseView Project()
        {

        }


    }*/
}
