using Microsoft.EntityFrameworkCore.Migrations;

namespace Papyrus.DataAccess.Migrations
{
    public partial class ApplyConfigurationToAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Members_MemberId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Ad_AdId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Ad_AdId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ad",
                table: "Ad");

            migrationBuilder.RenameTable(
                name: "Ad",
                newName: "Ads");

            migrationBuilder.RenameIndex(
                name: "IX_Ad_MemberId",
                table: "Ads",
                newName: "IX_Ads_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Members_MemberId",
                table: "Ads",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Ads_AdId",
                table: "Books",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Ads_AdId",
                table: "Photos",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Members_MemberId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Ads_AdId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Ads_AdId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.RenameTable(
                name: "Ads",
                newName: "Ad");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_MemberId",
                table: "Ad",
                newName: "IX_Ad_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ad",
                table: "Ad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Members_MemberId",
                table: "Ad",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
