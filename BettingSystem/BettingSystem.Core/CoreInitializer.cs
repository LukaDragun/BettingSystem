using BettingSystem.Core.ApplicationServices;
using Microsoft.Extensions.DependencyInjection;

namespace BettingSystem.Core
{
    public static class CoreInitializer
    {
        public static void InitializeCoreServices(this IServiceCollection services)
        {
            services.AddScoped<GameService>();
            services.AddScoped<WalletTransactionService>();
        }
    }
}
