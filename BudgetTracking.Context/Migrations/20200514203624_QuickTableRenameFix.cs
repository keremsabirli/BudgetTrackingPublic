using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class QuickTableRenameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseType",
                table: "ExpenseType");

            migrationBuilder.RenameTable(
                name: "ExpenseType",
                newName: "PaymentMethod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.RenameTable(
                name: "PaymentMethod",
                newName: "ExpenseType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseType",
                table: "ExpenseType",
                column: "Id");
        }
    }
}
