using Microsoft.EntityFrameworkCore.Migrations;

namespace Papyrus.DataAccess.Migrations
{
    public partial class UpdateRelationOfAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_AdId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AdId",
                table: "Books",
                column: "AdId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_AdId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AdId",
                table: "Books",
                column: "AdId");
        }
    }
}
