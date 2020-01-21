using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Papyrus.DataAccess.Migrations
{
    public partial class AddAdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdId",
                table: "Photos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdId",
                table: "Photos",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AdId",
                table: "Books",
                column: "AdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Ad_AdId",
                table: "Books",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Ad_AdId",
                table: "Photos",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Ad_AdId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Ad_AdId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AdId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Books_AdId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AdId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AdId",
                table: "Books");
        }
    }
}
