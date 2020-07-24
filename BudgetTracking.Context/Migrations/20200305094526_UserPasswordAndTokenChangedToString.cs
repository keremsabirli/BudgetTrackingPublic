using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class UserPasswordAndTokenChangedToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "User",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Token",
                table: "User",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "User",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
