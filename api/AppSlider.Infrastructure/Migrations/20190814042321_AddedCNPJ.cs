using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class AddedCNPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long?>(
                name: "CNPJ",
                table: "Business",
                nullable: true,
                defaultValue: null);   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
