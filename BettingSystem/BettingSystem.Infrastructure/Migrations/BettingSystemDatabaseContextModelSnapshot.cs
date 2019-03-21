﻿// <auto-generated />
using System;
using BettingSystem.Common.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BettingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(BettingSystemDatabaseContext))]
    partial class BettingSystemDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<bool>("IsResolved");

                    b.Property<DateTime>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.BetCoefficient", b =>
                {
                    b.Property<int>("BetId");

                    b.Property<int>("CoefficientId");

                    b.HasKey("BetId", "CoefficientId");

                    b.HasIndex("CoefficientId");

                    b.ToTable("BetCoefficient");
                });

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.Coefficient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BetType");

                    b.Property<float>("CoefficientValue");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("GameId");

                    b.Property<DateTime>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Coefficients");
                });

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime?>("DateTimePlayed");

                    b.Property<DateTime>("DateTimeStarting");

                    b.Property<string>("FirstTeamName");

                    b.Property<int?>("FirstTeamScore");

                    b.Property<int>("GameType");

                    b.Property<string>("SecondTeamName");

                    b.Property<int?>("SecondTeamScore");

                    b.Property<DateTime>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.WalletTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BetId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int>("TransactionType");

                    b.Property<float>("TransactionValue");

                    b.Property<DateTime>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("WalletTransactions");
                });

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.BetCoefficient", b =>
                {
                    b.HasOne("BettingSystem.Infrastructure.Entities.Bet", "Bet")
                        .WithMany("BetCoefficients")
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BettingSystem.Infrastructure.Entities.Coefficient", "Coefficient")
                        .WithMany("BetCoefficients")
                        .HasForeignKey("CoefficientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.Coefficient", b =>
                {
                    b.HasOne("BettingSystem.Infrastructure.Entities.Game", "Game")
                        .WithMany("Coefficients")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BettingSystem.Infrastructure.Entities.WalletTransaction", b =>
                {
                    b.HasOne("BettingSystem.Infrastructure.Entities.Bet", "Bet")
                        .WithMany("Transactions")
                        .HasForeignKey("BetId");
                });
#pragma warning restore 612, 618
        }
    }
}
