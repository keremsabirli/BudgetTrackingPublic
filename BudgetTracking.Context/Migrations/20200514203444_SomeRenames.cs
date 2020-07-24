using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class SomeRenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corporate_CorporateType_CorporateTypeID",
                table: "Corporate");

            migrationBuilder.DropTable(
                name: "CorporateType");

            migrationBuilder.DropIndex(
                name: "IX_Corporate_CorporateTypeID",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "CorporateTypeID",
                table: "Corporate");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "UUID()"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AddColumn<string>(
                name: "CorporateTypeID",
                table: "Corporate",
                type: "char(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CorporateType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, defaultValueSql: "UUID()"),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Icon = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserID = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateType_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corporate_CorporateTypeID",
                table: "Corporate",
                column: "CorporateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateType_UserID",
                table: "CorporateType",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Corporate_CorporateType_CorporateTypeID",
                table: "Corporate",
                column: "CorporateTypeID",
                principalTable: "CorporateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
