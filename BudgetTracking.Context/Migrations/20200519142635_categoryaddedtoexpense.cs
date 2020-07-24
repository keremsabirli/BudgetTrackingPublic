using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class categoryaddedtoexpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "Expense",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryID",
                table: "Expense",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_CategoryID",
                table: "Expense",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_CategoryID",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_CategoryID",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Expense");
        }
    }
}
