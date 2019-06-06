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
                    Blocked = table.Column<bool>(nullable: false)
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
                    Blocked = table.Column<bool>(nullable: false)
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
                    Active = table.Column<bool>(nullable: false)
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
                    Active = table.Column<bool>(nullable: false)
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
                    { new Guid("55ee3c91-4161-486f-ac67-cb6c47de3b67"), true, new DateTime(2019, 6, 6, 0, 49, 46, 721, DateTimeKind.Local).AddTicks(5865), "Franquia como Tipo de Negócio.", "Franquia" },
                    { new Guid("c602ecd0-77f2-4268-86a4-ed0408eea577"), true, new DateTime(2019, 6, 6, 0, 49, 46, 721, DateTimeKind.Local).AddTicks(6126), "Estabelecimento como Tipo de Negócio.", "Estabelecimento" },
                    { new Guid("1ed93701-707f-4e44-9759-eedb6e05e57d"), true, new DateTime(2019, 6, 6, 0, 49, 46, 721, DateTimeKind.Local).AddTicks(6190), "Anunciente como Tipo de Negócio.", "Anunciante" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[] { new Guid("be1b4f08-7307-4ab1-94e7-4f4cad1fbfeb"), true, new DateTime(2019, 6, 6, 0, 49, 46, 724, DateTimeKind.Local).AddTicks(5561), "Categoria MidiaFone.", "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8968566f-2281-450f-930c-d4c589f4510e"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6164), "Permissão de leitura para rotina de Usuário.", "AppSlider.Read.User" },
                    { new Guid("c1042be8-78aa-4da6-bad4-8045c704c278"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6334), "Permissão de escrita para rotina de Usuário.", "AppSlider.Write.User" },
                    { new Guid("d9357b73-abf3-4b7d-92cb-20e9a3d48045"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6383), "Permissão de leitura para rotina de Negócio.", "AppSlider.Read.Business" },
                    { new Guid("018430c4-ede7-4ae7-b1e3-83fd26685810"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6475), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("0213c9de-f636-4800-8b17-56a989f5fe60"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6518), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("b1eb56b4-bf5e-4aad-a189-3aab6d8f4751"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6559), "Permissão de escrita para rotina de Tipos de Negócio.", "AppSlider.Write.BusinessType" },
                    { new Guid("17b30fcc-910b-4e83-b527-840f5928f1c4"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6598), "Permissão de leitura para rotina de Categoria.", "AppSlider.Read.Category" },
                    { new Guid("303e9d24-2d82-4333-8004-ce1cebdf928b"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6639), "Permissão de escrita para rotina de Categoria.", "AppSlider.Write.Category" },
                    { new Guid("d7b0c603-3cb7-449a-aa7a-ec0e6d89a933"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6682), "Permissão de leitura para rotina de Playlist.", "AppSlider.Read.Playlist" },
                    { new Guid("6b788f8f-ca27-4a9e-9b10-bb9aeeaf25d3"), new DateTime(2019, 6, 6, 0, 49, 46, 727, DateTimeKind.Local).AddTicks(6722), "Permissão de escrita para rotina de Playlist.", "AppSlider.Write.Playlist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "DataCreated", "Email", "Franchises", "Name", "Password", "Profile", "Roles", "Username" },
                values: new object[] { new Guid("227c8bdd-4940-4202-9c23-e091dcb1a5fe"), true, new DateTime(2019, 6, 6, 0, 49, 46, 729, DateTimeKind.Local).AddTicks(6020), "", null, "Administrador", "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6", "admin", null, "admin" });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "Active", "ContactAddress", "ContactEmail", "ContactName", "ContactPhone", "DataCreated", "Description", "ExpirationDate", "IdCategory", "IdFather", "IdLogo", "IdType", "Name" },
                values: new object[] { new Guid("377d8458-116f-446f-9d8a-c5653dd753fb"), true, "", "", "", "", new DateTime(2019, 6, 6, 0, 49, 46, 681, DateTimeKind.Local).AddTicks(1975), "Franquia padrão 'MidiaFone'", null, new Guid("be1b4f08-7307-4ab1-94e7-4f4cad1fbfeb"), null, null, new Guid("55ee3c91-4161-486f-ac67-cb6c47de3b67"), "MidiaFone" });

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
