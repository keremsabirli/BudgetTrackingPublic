using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetTracking.Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: false),
                    MailAddress = table.Column<string>(nullable: false),
                    Password = table.Column<byte[]>(nullable: true),
                    Token = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false),
                    Icon = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corporate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false),
                    CorporateTypeID = table.Column<Guid>(nullable: false),
                    IconUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corporate_CorporateType_CorporateTypeID",
                        column: x => x.CorporateTypeID,
                        principalTable: "CorporateType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corporate_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    CorporateID = table.Column<Guid>(nullable: false),
                    MemberID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Corporate_CorporateID",
                        column: x => x.CorporateID,
                        principalTable: "Corporate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corporate_CorporateTypeID",
                table: "Corporate",
                column: "CorporateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Corporate_UserID",
                table: "Corporate",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateType_UserID",
                table: "CorporateType",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CorporateID",
                table: "Expense",
                column: "CorporateID");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_MemberID",
                table: "Expense",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserID",
                table: "Member",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "ExpenseType");

            migrationBuilder.DropTable(
                name: "Corporate");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "CorporateType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
