using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class NullableIdsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corporate_User_UserID",
                table: "Corporate");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Corporate_CorporateID",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Member_MemberID",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_User_UserID",
                table: "Member");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Member",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberID",
                table: "Expense",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CorporateID",
                table: "Expense",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Corporate",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_Corporate_User_UserID",
                table: "Corporate",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Corporate_CorporateID",
                table: "Expense",
                column: "CorporateID",
                principalTable: "Corporate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Member_MemberID",
                table: "Expense",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_User_UserID",
                table: "Member",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corporate_User_UserID",
                table: "Corporate");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Corporate_CorporateID",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Member_MemberID",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_User_UserID",
                table: "Member");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Member",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MemberID",
                table: "Expense",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CorporateID",
                table: "Expense",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Corporate",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Corporate_User_UserID",
                table: "Corporate",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Corporate_CorporateID",
                table: "Expense",
                column: "CorporateID",
                principalTable: "Corporate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Member_MemberID",
                table: "Expense",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_User_UserID",
                table: "Member",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
