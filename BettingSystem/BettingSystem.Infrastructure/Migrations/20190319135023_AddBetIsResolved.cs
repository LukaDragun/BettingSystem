using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingSystem.Infrastructure.Migrations
{
    public partial class AddBetIsResolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "Bets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "Bets");
        }
    }
}
