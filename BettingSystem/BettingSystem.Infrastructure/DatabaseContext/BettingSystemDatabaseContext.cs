using BettingSystem.Infrastructure.Entities;
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
            modelBuilder.Entity<WalletTransaction>().HasOne(o => o.Bet).WithOne(r => r.Transaction).HasForeignKey<WalletTransaction>(wt => wt.BetId);
            modelBuilder.Entity<Coefficient>().HasOne(c => c.Game).WithMany(g => g.Coefficients).IsRequired();

            modelBuilder.Entity<BetCoefficient>().HasKey(bc => new { bc.BetId, bc.CoefficientId });
            modelBuilder.Entity<BetCoefficient>().HasOne(bc => bc.Coefficient).WithMany(b => b.BetCoefficients).HasForeignKey(bc => bc.CoefficientId);
            modelBuilder.Entity<BetCoefficient>().HasOne(bc => bc.Bet).WithMany(c => c.BetCoefficients).HasForeignKey(bc => bc.BetId);
    }
    }
}
