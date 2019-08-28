using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class AdvertiserEquipament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertiserEquipament",
                columns: table => new
                {
                    IdAdvertiser = table.Column<Guid>(nullable: false),
                    IdEquipament = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertiserEquipament", x => new { x.IdAdvertiser, x.IdEquipament });
                    table.ForeignKey(
                        name: "FK_AdvertiserEquipament_Advertisers_IdAdvertiser",
                        column: x => x.IdAdvertiser,
                        principalTable: "Advertisers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertiserEquipament_Equipaments_IdEquipament",
                        column: x => x.IdEquipament,
                        principalTable: "Equipaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_AdvertiserEquipament_IdEquipament",
                table: "AdvertiserEquipament",
                column: "IdEquipament");


        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertiserEquipament");
          
        }
    }
}
