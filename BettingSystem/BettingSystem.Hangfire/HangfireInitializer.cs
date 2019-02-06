using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BettingSystem.Hangfire
{
    public static class HangfireInitializer
    {
        public static void SetupHangfireServices(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));         
        }
        
        public static void ConfigureHangfire(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            SetupHangfireJobs();
        }

        private static void SetupHangfireJobs()
        {
            //RecurringJob.AddOrUpdate(() => Console.WriteLine("Daily Job"), Cron.Daily);
        }
    }
}
