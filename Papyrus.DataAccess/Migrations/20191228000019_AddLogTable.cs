using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Papyrus.DataAccess.Migrations
{
    public partial class AddLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Detail = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Audit = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
