using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class AddAdvertiserEstablishmentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.CreateTable(
                name: "Advertisers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Establishments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertiserEstablishments",
                columns: table => new
                {
                    IdAdvertiser = table.Column<Guid>(nullable: false),
                    IdEstablishment = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertiserEstablishments", x => new { x.IdAdvertiser, x.IdEstablishment });
                    table.ForeignKey(
                        name: "FK_AdvertiserEstablishments_Advertisers_IdAdvertiser",
                        column: x => x.IdAdvertiser,
                        principalTable: "Advertisers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertiserEstablishments_Establishments_IdEstablishment",
                        column: x => x.IdEstablishment,
                        principalTable: "Establishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

   

            migrationBuilder.CreateIndex(
                name: "IX_AdvertiserEstablishments_IdEstablishment",
                table: "AdvertiserEstablishments",
                column: "IdEstablishment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
