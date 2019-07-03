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
                    PlaylistFileType = table.Column<int>(nullable: false),
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
                    { new Guid("73b18281-2566-49e7-bd47-2f858eb4f0cf"), true, new DateTime(2019, 7, 3, 0, 33, 57, 585, DateTimeKind.Local).AddTicks(1188), "Franquia como Tipo de Negócio.", "Franquia" },
                    { new Guid("d4d5fdae-dfae-4d2b-93c3-afecb4db33c4"), true, new DateTime(2019, 7, 3, 0, 33, 57, 585, DateTimeKind.Local).AddTicks(1623), "Estabelecimento como Tipo de Negócio.", "Estabelecimento" },
                    { new Guid("2abc3c81-81ec-4231-91c1-0bcd338845e7"), true, new DateTime(2019, 7, 3, 0, 33, 57, 585, DateTimeKind.Local).AddTicks(1786), "Anunciante como Tipo de Negócio.", "Anunciante" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[] { new Guid("28f8faeb-6f0d-40b8-ae04-35ab61f40c77"), true, new DateTime(2019, 7, 3, 0, 33, 57, 588, DateTimeKind.Local).AddTicks(7132), "Categoria MidiaFone.", "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("72af5098-3216-418b-94d9-fe0769026e0d"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1958), "Permissão de leitura para rotina de Equipamento.", "AppSlider.Read.Equipament" },
                    { new Guid("0c9c33ed-9b69-4d72-aea2-98ea0b412889"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1914), "Permissão de escrita para rotina de Playlist.", "AppSlider.Write.Playlist" },
                    { new Guid("6c7e23b1-24a2-46c2-9457-80db72a8f7aa"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1869), "Permissão de leitura para rotina de Playlist.", "AppSlider.Read.Playlist" },
                    { new Guid("4ee615d4-e58e-4b5c-b48a-88f3062bfa97"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1744), "Permissão de escrita para rotina de Categoria.", "AppSlider.Write.Category" },
                    { new Guid("f50bedee-f90d-4a78-990a-2a37a8bc4c8f"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1685), "Permissão de leitura para rotina de Categoria.", "AppSlider.Read.Category" },
                    { new Guid("c479f64d-6ce9-4c50-9c8e-bf58d27ed12d"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1410), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("13a35ba9-7647-48e8-a60f-10a502cd789c"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(2001), "Permissão de escrita para rotina de Equipamento.", "AppSlider.Write.Equipament" },
                    { new Guid("85144031-f7a3-4f19-a767-4ba91e06ebb3"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1363), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("359bc08f-5945-4cdc-8395-8a9506293b7e"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1315), "Permissão de leitura para rotina de Negócio.", "AppSlider.Read.Business" },
                    { new Guid("320ac917-36f9-48e9-bbec-762f061ed5ac"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1262), "Permissão de escrita para rotina de Usuário.", "AppSlider.Write.User" },
                    { new Guid("da939422-78b5-47e0-9e0a-b27675e9e7a9"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1080), "Permissão de leitura para rotina de Usuário.", "AppSlider.Read.User" },
                    { new Guid("31d181d8-5118-4d02-92e5-7d003dd24ad3"), new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1584), "Permissão de escrita para rotina de Tipos de Negócio.", "AppSlider.Write.BusinessType" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Blocked", "DataCreated", "Email", "Franchises", "Name", "Password", "Profile", "Roles", "Username" },
                values: new object[] { new Guid("803db767-ee31-4606-b983-5454f22cbfba"), true, true, new DateTime(2019, 7, 3, 0, 33, 57, 600, DateTimeKind.Local).AddTicks(4799), "", null, "Administrador", "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6", "sa", null, "admin" });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "Active", "Blocked", "ContactAddress", "ContactEmail", "ContactName", "ContactPhone", "DataCreated", "Description", "ExpirationDate", "IdCategory", "IdFather", "IdLogo", "IdType", "Name" },
                values: new object[] { new Guid("81853d7a-41af-49b5-8bd8-83d622f7b8c4"), true, true, "", "", "", "", new DateTime(2019, 7, 3, 0, 33, 57, 538, DateTimeKind.Local).AddTicks(7870), "Franquia padrão 'MidiaFone'", null, new Guid("28f8faeb-6f0d-40b8-ae04-35ab61f40c77"), null, null, new Guid("73b18281-2566-49e7-bd47-2f858eb4f0cf"), "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Active", "Blocked", "DataCreated", "Expirate", "FranchiseId", "Name" },
                values: new object[] { new Guid("256eb97e-ebda-4310-9a30-412cfbd280ae"), true, true, new DateTime(2019, 7, 3, 0, 33, 57, 592, DateTimeKind.Local).AddTicks(1497), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new Guid("81853d7a-41af-49b5-8bd8-83d622f7b8c4"), "Curiosidades MidiaFone" });

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
