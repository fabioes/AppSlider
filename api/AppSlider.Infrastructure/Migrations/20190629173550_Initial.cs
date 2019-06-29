using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
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
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
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
                    Size = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
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
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    Franchises = table.Column<string>(nullable: true),
                    Roles = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
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
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IdLogo = table.Column<Guid>(nullable: true),
                    ContactName = table.Column<string>(maxLength: 200, nullable: true),
                    ContactEmail = table.Column<string>(maxLength: 200, nullable: true),
                    ContactPhone = table.Column<string>(maxLength: 50, nullable: true),
                    ContactAddress = table.Column<string>(maxLength: 300, nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    Expirate = table.Column<DateTime>(nullable: false),
                    FranchiseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Business_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Business",
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

            migrationBuilder.CreateTable(
                name: "Equipaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 200, nullable: true),
                    IdFranchise = table.Column<Guid>(nullable: false),
                    IdEstablishment = table.Column<Guid>(nullable: true),
                    IdPlaylist = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipaments_Business_IdEstablishment",
                        column: x => x.IdEstablishment,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipaments_Business_IdFranchise",
                        column: x => x.IdFranchise,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipaments_Playlists_IdPlaylist",
                        column: x => x.IdPlaylist,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "BusinessTypes",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0ea0ec66-5aba-40d3-8098-5d0e258e6309"), true, new DateTime(2019, 6, 29, 14, 35, 49, 459, DateTimeKind.Local).AddTicks(3283), "Franquia como Tipo de Negócio.", "Franquia" },
                    { new Guid("77baf8b9-09ec-4c20-86fd-65efbba5e5b3"), true, new DateTime(2019, 6, 29, 14, 35, 49, 459, DateTimeKind.Local).AddTicks(3642), "Estabelecimento como Tipo de Negócio.", "Estabelecimento" },
                    { new Guid("fd918c53-a5eb-42b1-9474-c16dd2116248"), true, new DateTime(2019, 6, 29, 14, 35, 49, 459, DateTimeKind.Local).AddTicks(3866), "Anunciante como Tipo de Negócio.", "Anunciante" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[] { new Guid("cabbc0f7-f5e0-4301-88d8-7a76ba5ce90f"), true, new DateTime(2019, 6, 29, 14, 35, 49, 463, DateTimeKind.Local).AddTicks(903), "Categoria MidiaFone.", "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("9d1a0956-c84f-4b57-9056-af8c370c01e1"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(7675), "Permissão de leitura para rotina de Usuário.", "AppSlider.Read.User" },
                    { new Guid("b67063a4-7af2-423e-aa47-c1632120aaee"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(7952), "Permissão de escrita para rotina de Usuário.", "AppSlider.Write.User" },
                    { new Guid("6b6b8638-4af7-482f-a63d-aece73215fb4"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(8057), "Permissão de leitura para rotina de Negócio.", "AppSlider.Read.Business" },
                    { new Guid("2924fefd-7a33-432a-ad05-a1f5b634b04d"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(8162), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("f9d06571-0b07-4c95-b47b-72d335dfbe42"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(8287), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("b2093d13-1b9e-4290-aa60-a6990787fb9f"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(8419), "Permissão de escrita para rotina de Tipos de Negócio.", "AppSlider.Write.BusinessType" },
                    { new Guid("47c3cec0-2a48-4f00-b179-85604605bb3a"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(8686), "Permissão de leitura para rotina de Categoria.", "AppSlider.Read.Category" },
                    { new Guid("5c91a132-fe2e-425a-b0b4-5b3573d6de09"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(8828), "Permissão de escrita para rotina de Categoria.", "AppSlider.Write.Category" },
                    { new Guid("361a05a7-9e46-4129-83d6-445c6b8ec9b4"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(9040), "Permissão de leitura para rotina de Playlist.", "AppSlider.Read.Playlist" },
                    { new Guid("66252759-14d9-4293-b587-f0d4cd5b3df1"), new DateTime(2019, 6, 29, 14, 35, 49, 477, DateTimeKind.Local).AddTicks(9138), "Permissão de escrita para rotina de Playlist.", "AppSlider.Write.Playlist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Blocked", "DataCreated", "Email", "Franchises", "Name", "Password", "Profile", "Roles", "Username" },
                values: new object[] { new Guid("97942e3e-7d2a-4be4-a1fb-72295e65ed7d"), true, true, new DateTime(2019, 6, 29, 14, 35, 49, 480, DateTimeKind.Local).AddTicks(8147), "", null, "Administrador", "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6", "sa", null, "admin" });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "Active", "Blocked", "ContactAddress", "ContactEmail", "ContactName", "ContactPhone", "DataCreated", "Description", "ExpirationDate", "IdCategory", "IdFather", "IdLogo", "IdType", "Name" },
                values: new object[] { new Guid("893652cc-0166-437e-a750-d306abbe1d4b"), true, true, "", "", "", "", new DateTime(2019, 6, 29, 14, 35, 49, 386, DateTimeKind.Local).AddTicks(75), "Franquia padrão 'MidiaFone'", null, new Guid("cabbc0f7-f5e0-4301-88d8-7a76ba5ce90f"), null, null, new Guid("0ea0ec66-5aba-40d3-8098-5d0e258e6309"), "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Active", "Blocked", "DataCreated", "Expirate", "FranchiseId", "Name" },
                values: new object[] { new Guid("370cd979-a3f2-4303-8cb8-68aa27475882"), true, true, new DateTime(2019, 6, 29, 14, 35, 49, 468, DateTimeKind.Local).AddTicks(2215), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new Guid("893652cc-0166-437e-a750-d306abbe1d4b"), "Curiosidades MidiaFone" });

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
                name: "IX_BusinessTypes_Name",
                table: "BusinessTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Equipaments_IdEstablishment",
                table: "Equipaments",
                column: "IdEstablishment");

            migrationBuilder.CreateIndex(
                name: "IX_Equipaments_IdFranchise",
                table: "Equipaments",
                column: "IdFranchise");

            migrationBuilder.CreateIndex(
                name: "IX_Equipaments_IdPlaylist",
                table: "Equipaments",
                column: "IdPlaylist");

            migrationBuilder.CreateIndex(
                name: "IX_Equipaments_MacAddress",
                table: "Equipaments",
                column: "MacAddress");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistFiles_IdFile",
                table: "PlaylistFiles",
                column: "IdFile");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistFiles_IdPlayList",
                table: "PlaylistFiles",
                column: "IdPlayList");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_FranchiseId",
                table: "Playlists",
                column: "FranchiseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPlaylists");

            migrationBuilder.DropTable(
                name: "Equipaments");

            migrationBuilder.DropTable(
                name: "PlaylistFiles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "BusinessTypes");
        }
    }
}
