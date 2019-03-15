using BettingSystem.Common.Infrastructure.DatabaseContext;
using BettingSystem.Core.InfrastructureContracts.Queries;
using BettingSystem.Core.InfrastructureContracts.Repositories;
using BettingSystem.Infrastructure.Queries;
using BettingSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BettingSystem.Infrastructure
{
    public static class InfrastructureInitializer
    {

        public static void InitializeInfrastructure(this IServiceCollection services, string connectionString) {
            RegisterDbContext(services, connectionString);
            RegisterRepositories(services);
            RegisterQueries(services);
        }

        private static void RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BettingSystemDatabaseContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("BettingSystem.Infrastructure")));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IBetRepository, BetRepository>();
            services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
        }

        private static void RegisterQueries(IServiceCollection services)
        {
            services.AddScoped<IGameQuery, GameQuery>();
            services.AddScoped<IWalletTransactionQuery, WalletTransactionQuery>();
        }

    }
}
