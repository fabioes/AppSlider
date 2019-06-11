using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    MineType = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<string>(nullable: true),
                    Expirate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    Franchises = table.Column<string>(nullable: true),
                    Roles = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    IdFather = table.Column<Guid>(nullable: true),
                    IdType = table.Column<Guid>(nullable: false),
                    IdCategory = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IdLogo = table.Column<Guid>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    ContactAddress = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Business_IdFather",
                        column: x => x.IdFather,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Files_IdLogo",
                        column: x => x.IdLogo,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_BusinessTypes_IdType",
                        column: x => x.IdType,
                        principalTable: "BusinessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    IdPlayList = table.Column<Guid>(nullable: false),
                    PlayListFileType = table.Column<int>(nullable: false),
                    IdFile = table.Column<Guid>(nullable: false),
                    Duration = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistFiles_Files_IdFile",
                        column: x => x.IdFile,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistFiles_Playlists_IdPlayList",
                        column: x => x.IdPlayList,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPlaylists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    IdBusiness = table.Column<Guid>(nullable: false),
                    IdPlayList = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPlaylists_Business_IdBusiness",
                        column: x => x.IdBusiness,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessPlaylists_Playlists_IdPlayList",
                        column: x => x.IdPlayList,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusinessTypes",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("f9b24f48-1afe-484a-8e09-ada83aa66551"), true, new DateTime(2019, 6, 10, 21, 41, 58, 803, DateTimeKind.Local).AddTicks(421), "Franquia como Tipo de Negócio.", "Franquia" },
                    { new Guid("36bb2422-01cc-4a64-8e7e-f022aac0f11c"), true, new DateTime(2019, 6, 10, 21, 41, 58, 803, DateTimeKind.Local).AddTicks(680), "Estabelecimento como Tipo de Negócio.", "Estabelecimento" },
                    { new Guid("a5d22a51-d9ac-42b1-bba5-161b60e0ab13"), true, new DateTime(2019, 6, 10, 21, 41, 58, 803, DateTimeKind.Local).AddTicks(752), "Anunciante como Tipo de Negócio.", "Anunciante" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[] { new Guid("2fa84b4e-ce62-46d7-a289-6ff0aece6da6"), true, new DateTime(2019, 6, 10, 21, 41, 58, 806, DateTimeKind.Local).AddTicks(8557), "Categoria MidiaFone.", "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("e96c4a63-378f-4eaf-b714-0105f6b579cf"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3316), "Permissão de leitura para rotina de Usuário.", "AppSlider.Read.User" },
                    { new Guid("39d2c107-39af-4687-8cbe-56a687933924"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3496), "Permissão de escrita para rotina de Usuário.", "AppSlider.Write.User" },
                    { new Guid("8c336567-5ae0-4df9-91ee-c8b658f2441c"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3544), "Permissão de leitura para rotina de Negócio.", "AppSlider.Read.Business" },
                    { new Guid("077fdbec-6021-4bc4-b20b-1d56461daf9c"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3586), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("42aa092a-599d-4166-bdff-f893bbca06e4"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3629), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("8184896a-be6f-4929-a608-e161fd92c1d5"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3671), "Permissão de escrita para rotina de Tipos de Negócio.", "AppSlider.Write.BusinessType" },
                    { new Guid("f1a76e22-0787-4a7d-934a-6c08696f0a22"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3724), "Permissão de leitura para rotina de Categoria.", "AppSlider.Read.Category" },
                    { new Guid("90f47c7c-8a54-4630-9a68-12a94e659d2f"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3884), "Permissão de escrita para rotina de Categoria.", "AppSlider.Write.Category" },
                    { new Guid("5db27234-2d10-419c-9043-a7b38971e8b4"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3933), "Permissão de leitura para rotina de Playlist.", "AppSlider.Read.Playlist" },
                    { new Guid("291077e1-b03c-4165-a48f-9ed9d5e06a3b"), new DateTime(2019, 6, 10, 21, 41, 58, 810, DateTimeKind.Local).AddTicks(3974), "Permissão de escrita para rotina de Playlist.", "AppSlider.Write.Playlist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "DataCreated", "Email", "Franchises", "Name", "Password", "Profile", "Roles", "Username" },
                values: new object[] { new Guid("5ba3c6c6-2120-4727-919e-8f10f96e5fa1"), true, new DateTime(2019, 6, 10, 21, 41, 58, 812, DateTimeKind.Local).AddTicks(5541), "", null, "Administrador", "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6", "admin", null, "admin" });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "Active", "ContactAddress", "ContactEmail", "ContactName", "ContactPhone", "DataCreated", "Description", "ExpirationDate", "IdCategory", "IdFather", "IdLogo", "IdType", "Name" },
                values: new object[] { new Guid("7e9b8790-ae13-4831-8f7a-3ea41ed7fde7"), true, "", "", "", "", new DateTime(2019, 6, 10, 21, 41, 58, 758, DateTimeKind.Local).AddTicks(8595), "Franquia padrão 'MidiaFone'", null, new Guid("2fa84b4e-ce62-46d7-a289-6ff0aece6da6"), null, null, new Guid("f9b24f48-1afe-484a-8e09-ada83aa66551"), "MidiaFone" });

            migrationBuilder.CreateIndex(
                name: "IX_Business_IdCategory",
                table: "Business",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Business_IdFather",
                table: "Business",
                column: "IdFather");

            migrationBuilder.CreateIndex(
                name: "IX_Business_IdLogo",
                table: "Business",
                column: "IdLogo");

            migrationBuilder.CreateIndex(
                name: "IX_Business_IdType",
                table: "Business",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlaylists_IdBusiness",
                table: "BusinessPlaylists",
                column: "IdBusiness");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlaylists_IdPlayList",
                table: "BusinessPlaylists",
                column: "IdPlayList");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistFiles_IdFile",
                table: "PlaylistFiles",
                column: "IdFile");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistFiles_IdPlayList",
                table: "PlaylistFiles",
                column: "IdPlayList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPlaylists");

            migrationBuilder.DropTable(
                name: "PlaylistFiles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "BusinessTypes");
        }
    }
}
