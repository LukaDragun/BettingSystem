using BettingSystem.Common.Infrastructure.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BettingSystem.Common.Infrastructure.DatabaseContext
{
    public class BettingSystemDatabaseContext : DbContext
    {

        public BettingSystemDatabaseContext() : base("BettingSystemContext")
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Coefficient> Coefficients { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Coefficient>().HasKey(c => new { c.Id, c.BetType });
            modelBuilder.Entity<WalletTransaction>().HasOptional(o => o.Bet).WithRequired(r => r.Transaction);
        }
    }
}
