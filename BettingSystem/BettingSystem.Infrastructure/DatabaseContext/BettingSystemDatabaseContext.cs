using BettingSystem.Common.Core.Enums;
using BettingSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
            modelBuilder.Entity<WalletTransaction>().HasOne(o => o.Bet).WithMany(r => r.Transactions).HasForeignKey(wt => wt.BetId);
            modelBuilder.Entity<Coefficient>().HasOne(c => c.Game).WithMany(g => g.Coefficients).HasForeignKey(g => g.GameId).IsRequired();

            modelBuilder.Entity<BetCoefficient>().HasKey(bc => new { bc.BetId, bc.CoefficientId });
            modelBuilder.Entity<BetCoefficient>().HasOne(bc => bc.Coefficient).WithMany(b => b.BetCoefficients).HasForeignKey(bc => bc.CoefficientId);
            modelBuilder.Entity<BetCoefficient>().HasOne(bc => bc.Bet).WithMany(c => c.BetCoefficients).HasForeignKey(bc => bc.BetId);

            IntializeData(modelBuilder);
        }

        private void IntializeData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<WalletTransaction>().HasData(
                new WalletTransaction { Id = 1, TransactionType = TransactionType.Deposit, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, TransactionValue = 500 },
                new WalletTransaction { Id = 2, TransactionType = TransactionType.Bet, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, TransactionValue = -220, BetId = 1 },
                new WalletTransaction { Id = 3, TransactionType = TransactionType.Bet, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, TransactionValue = -210, BetId = 2 }
                );
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, FirstTeamName = "KK. Split", SecondTeamName = "KK. Trogir", DateTimeStarting = DateTime.Now, DateTimePlayed = DateTime.Now.AddHours(1), FirstTeamScore = 1, SecondTeamScore = 2, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, GameType = GameType.Basketball }
                );
            modelBuilder.Entity<Coefficient>().HasData(
                new Coefficient { Id = 1, GameId = 1, BetType = BetType.One, CoefficientValue = 2.3f, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now },
                new Coefficient { Id = 2, GameId = 1, BetType = BetType.XTwo, CoefficientValue = 1.5f, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now }
                );
            modelBuilder.Entity<Bet>().HasData(
                new Bet { Id = 1, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, IsResolved = false },
                new Bet { Id = 2, CreatedDateTime = DateTime.Now, UpdatedDateTime = DateTime.Now, IsResolved = false }
                );
            modelBuilder.Entity<BetCoefficient>().HasData(
                new BetCoefficient { BetId = 1, CoefficientId = 1 },
                new BetCoefficient { BetId = 2, CoefficientId = 2 }
                );
        }
    }
}
