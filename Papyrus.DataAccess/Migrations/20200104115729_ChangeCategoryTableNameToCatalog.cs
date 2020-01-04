using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Papyrus.DataAccess.Migrations
{
    public partial class ChangeCategoryTableNameToCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Categories_CategoryId",
                table: "Genres");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Genres_CategoryId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Genres");

            migrationBuilder.AddColumn<Guid>(
                name: "CatalogId",
                table: "Genres",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_CatalogId",
                table: "Genres",
                column: "CatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Catalogs_CatalogId",
                table: "Genres",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Catalogs_CatalogId",
                table: "Genres");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Genres_CatalogId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Genres");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Genres",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_CategoryId",
                table: "Genres",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Categories_CategoryId",
                table: "Genres",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
