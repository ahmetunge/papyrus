using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Papyrus.DataAccess.Migrations
{
    public partial class AddedTimeAndUserIdToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Properties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Photos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Logs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowVersion",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Ads",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "Ads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Ads");
        }
    }
}
