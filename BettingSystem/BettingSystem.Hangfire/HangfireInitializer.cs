using BettingSystem.Core.ApplicationServices;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BettingSystem.Hangfire
{
    public static class HangfireInitializer
    {
        public static void SetupHangfireServices(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));         
        }
        
        public static void ConfigureHangfire(this IApplicationBuilder app, GameService gameService)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            SetupHangfireJobs(gameService);
        }

        private static void SetupHangfireJobs(GameService gameService)
        {
            RecurringJob.AddOrUpdate("GenerateAndResolveGames", () => gameService.GenerateAndResolveGames(), Cron.Hourly);
        }
    }
}
