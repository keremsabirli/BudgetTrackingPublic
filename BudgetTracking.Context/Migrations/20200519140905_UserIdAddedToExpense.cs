using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class UserIdAddedToExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Expense",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserID",
                table: "Expense",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_User_UserID",
                table: "Expense",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_User_UserID",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_UserID",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Expense");
        }
    }
}
