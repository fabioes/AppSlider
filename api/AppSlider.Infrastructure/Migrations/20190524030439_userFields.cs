using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class userFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCreated",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Franchises",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCreated",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Franchises",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "User");
        }
    }
}
