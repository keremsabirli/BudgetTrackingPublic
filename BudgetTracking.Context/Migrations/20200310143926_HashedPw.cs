using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class HashedPw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
