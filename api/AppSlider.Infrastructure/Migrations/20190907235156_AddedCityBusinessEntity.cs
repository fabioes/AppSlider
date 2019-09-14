using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class AddedCityBusinessEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {          
            migrationBuilder.AddColumn<string>(
                name: "ContactCity",
                table: "Business",
                nullable: true);
         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.DropColumn(
                name: "ContactCity",
                table: "Business");
                      
        }
    }
}
