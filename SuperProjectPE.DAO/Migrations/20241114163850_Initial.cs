using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperProjectPE.DAO.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchAccount",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    AccountPassword = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BranchAc__349DA586C609B6BD", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FromCountry = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__19093A0B9DB2A055", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SilverJewelry",
                columns: table => new
                {
                    SilverJewelryId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SilverJewelryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SilverJewelryDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetalWeight = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ProductionYear = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SilverJe__1F12719775E48DD4", x => x.SilverJewelryId);
                    table.ForeignKey(
                        name: "FK__SilverJew__Categ__29572725",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__BranchAc__49A14740B3483417",
                table: "BranchAccount",
                column: "EmailAddress",
                unique: true,
                filter: "[EmailAddress] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SilverJewelry_CategoryId",
                table: "SilverJewelry",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchAccount");

            migrationBuilder.DropTable(
                name: "SilverJewelry");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
