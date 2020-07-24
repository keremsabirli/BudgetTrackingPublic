using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                nullable: false,
                defaultValueSql: "UUID()",
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Member",
                nullable: false,
                defaultValueSql: "UUID()",
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ExpenseType",
                nullable: false,
                defaultValueSql: "UUID()",
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Expense",
                nullable: false,
                defaultValueSql: "UUID()",
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CorporateType",
                nullable: false,
                defaultValueSql: "UUID()",
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Corporate",
                nullable: false,
                defaultValueSql: "UUID()",
                oldClrType: typeof(Guid),
                oldType: "char(36)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "UUID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Member",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "UUID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ExpenseType",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "UUID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Expense",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "UUID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CorporateType",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "UUID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Corporate",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "UUID()");
        }
    }
}
