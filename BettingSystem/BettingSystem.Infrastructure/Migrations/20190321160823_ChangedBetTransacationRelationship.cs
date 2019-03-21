using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingSystem.Infrastructure.Migrations
{
    public partial class ChangedBetTransacationRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_BetId",
                table: "WalletTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_BetId",
                table: "WalletTransactions",
                column: "BetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WalletTransactions_BetId",
                table: "WalletTransactions");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_BetId",
                table: "WalletTransactions",
                column: "BetId",
                unique: true,
                filter: "[BetId] IS NOT NULL");
        }
    }
}
