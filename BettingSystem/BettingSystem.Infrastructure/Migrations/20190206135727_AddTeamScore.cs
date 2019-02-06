using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingSystem.Infrastructure.Migrations
{
    public partial class AddTeamScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstTeamScore",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondTeamScore",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTeamScore",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SecondTeamScore",
                table: "Games");
        }
    }
}
