using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingSystem.Infrastructure.Migrations
{
    public partial class FullDatabaseScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false),
                    IsResolved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false),
                    GameType = table.Column<int>(nullable: false),
                    FirstTeamName = table.Column<string>(nullable: true),
                    SecondTeamName = table.Column<string>(nullable: true),
                    FirstTeamScore = table.Column<int>(nullable: true),
                    SecondTeamScore = table.Column<int>(nullable: true),
                    DateTimeStarting = table.Column<DateTime>(nullable: false),
                    DateTimePlayed = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false),
                    TransactionValue = table.Column<float>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    BetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Bets_BetId",
                        column: x => x.BetId,
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coefficients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false),
                    BetType = table.Column<int>(nullable: false),
                    CoefficientValue = table.Column<float>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coefficients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coefficients_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BetCoefficient",
                columns: table => new
                {
                    BetId = table.Column<int>(nullable: false),
                    CoefficientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetCoefficient", x => new { x.BetId, x.CoefficientId });
                    table.ForeignKey(
                        name: "FK_BetCoefficient_Bets_BetId",
                        column: x => x.BetId,
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BetCoefficient_Coefficients_CoefficientId",
                        column: x => x.CoefficientId,
                        principalTable: "Coefficients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bets",
                columns: new[] { "Id", "CreatedDateTime", "IsResolved", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local), false, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local) },
                    { 2, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local), false, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CreatedDateTime", "DateTimePlayed", "DateTimeStarting", "FirstTeamName", "FirstTeamScore", "GameType", "SecondTeamName", "SecondTeamScore", "UpdatedDateTime" },
                values: new object[] { 1, new DateTime(2019, 3, 24, 13, 50, 3, 386, DateTimeKind.Local), new DateTime(2019, 3, 24, 14, 50, 3, 386, DateTimeKind.Local), new DateTime(2019, 3, 24, 13, 50, 3, 386, DateTimeKind.Local), "KK. Split", 1, 2, "KK. Trogir", 2, new DateTime(2019, 3, 24, 13, 50, 3, 386, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "WalletTransactions",
                columns: new[] { "Id", "BetId", "CreatedDateTime", "TransactionType", "TransactionValue", "UpdatedDateTime" },
                values: new object[] { 1, null, new DateTime(2019, 3, 24, 13, 50, 3, 382, DateTimeKind.Local), 1, 500f, new DateTime(2019, 3, 24, 13, 50, 3, 385, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Coefficients",
                columns: new[] { "Id", "BetType", "CoefficientValue", "CreatedDateTime", "GameId", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1, 1, 2.3f, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local), 1, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local) },
                    { 2, 5, 1.5f, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local), 1, new DateTime(2019, 3, 24, 13, 50, 3, 387, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "WalletTransactions",
                columns: new[] { "Id", "BetId", "CreatedDateTime", "TransactionType", "TransactionValue", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2019, 3, 24, 13, 50, 3, 386, DateTimeKind.Local), 2, -220f, new DateTime(2019, 3, 24, 13, 50, 3, 386, DateTimeKind.Local) },
                    { 3, 2, new DateTime(2019, 3, 24, 13, 50, 3, 386, DateTimeKind.Local), 2, -210f, new DateTime(2019, 3, 24, 13, 50, 3, 386, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "BetCoefficient",
                columns: new[] { "BetId", "CoefficientId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BetCoefficient",
                columns: new[] { "BetId", "CoefficientId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BetCoefficient_CoefficientId",
                table: "BetCoefficient",
                column: "CoefficientId");

            migrationBuilder.CreateIndex(
                name: "IX_Coefficients_GameId",
                table: "Coefficients",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_BetId",
                table: "WalletTransactions",
                column: "BetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetCoefficient");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "Coefficients");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
