using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class ChangeLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Business",
                nullable: true);       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
        }
    }
}
