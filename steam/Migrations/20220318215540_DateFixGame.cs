using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace steam.Migrations
{
    public partial class DateFixGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Games",
                newName: "ReleaseDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Games",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
