using BettingSystem.Common.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BettingSystem.Common.Infrastructure.DatabaseContext
{
    public class BettingSystemDatabaseContext : DbContext
    {

        public BettingSystemDatabaseContext(DbContextOptions<BettingSystemDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Coefficient> Coefficients { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coefficient>().HasKey(c => new { c.Id, c.BetType });
            modelBuilder.Entity<WalletTransaction>().HasOne(o => o.Bet).WithOne(r => r.Transaction).HasForeignKey<WalletTransaction>(wt => wt.BetId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
