using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    IdType = table.Column<int>(nullable: false),
                    IdCategory = table.Column<int>(nullable: true),
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
                    BusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Business_BusinessId",
                        column: x => x.BusinessId,
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
                    { 1, true, new DateTime(2019, 7, 28, 23, 15, 58, 487, DateTimeKind.Local).AddTicks(6949), "Franquia como Tipo de Negócio.", "Franquia" },
                    { 2, true, new DateTime(2019, 7, 28, 23, 15, 58, 487, DateTimeKind.Local).AddTicks(7827), "Estabelecimento como Tipo de Negócio.", "Estabelecimento" },
                    { 3, true, new DateTime(2019, 7, 28, 23, 15, 58, 487, DateTimeKind.Local).AddTicks(7914), "Anunciante como Tipo de Negócio.", "Anunciante" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[] { 1, true, new DateTime(2019, 7, 28, 23, 15, 58, 502, DateTimeKind.Local).AddTicks(7648), "Categoria MidiaFone.", "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("799cab3a-be4f-47a0-911f-9d40c9cfb67c"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(990), "Permissão de leitura para rotina de Equipamento.", "AppSlider.Read.Equipament" },
                    { new Guid("732ec56b-a66b-448e-a602-a396f637efd3"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(935), "Permissão de escrita para rotina de Playlist.", "AppSlider.Write.Playlist" },
                    { new Guid("a7c276d7-151e-40d8-b99c-acb604a23ed3"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(881), "Permissão de leitura para rotina de Playlist.", "AppSlider.Read.Playlist" },
                    { new Guid("b9e11b09-cdb0-43e5-b081-908446bd437f"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(826), "Permissão de escrita para rotina de Categoria.", "AppSlider.Write.Category" },
                    { new Guid("d5792d04-f497-45b4-86fc-363515b77ff0"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(772), "Permissão de leitura para rotina de Categoria.", "AppSlider.Read.Category" },
                    { new Guid("3b49dd53-a367-4ffb-b799-14610e7f3b4a"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(663), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("cd0b05d8-2d0f-4f27-971d-3659c7d11b72"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(1089), "Permissão de escrita para rotina de Equipamento.", "AppSlider.Write.Equipament" },
                    { new Guid("c155e7ac-68ad-43df-85c4-8a579cf73aed"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(602), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("1dd62954-9563-4456-933c-74d4c6b198a0"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(464), "Permissão de leitura para rotina de Negócio.", "AppSlider.Read.Business" },
                    { new Guid("5c16825b-0251-4b8d-8c3e-f4896a7af7a0"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(400), "Permissão de escrita para rotina de Usuário.", "AppSlider.Write.User" },
                    { new Guid("9cd8e7f1-6a7c-4235-96d3-7dbd935d98a3"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(262), "Permissão de leitura para rotina de Usuário.", "AppSlider.Read.User" },
                    { new Guid("5ef1b67d-14a2-43de-afb7-7ddd7b028205"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(717), "Permissão de escrita para rotina de Tipos de Negócio.", "AppSlider.Write.BusinessType" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Blocked", "DataCreated", "Email", "Franchises", "Name", "Password", "Profile", "Roles", "Username" },
                values: new object[] { new Guid("b84fdff3-2892-4280-99d4-af461f5e8fd2"), true, true, new DateTime(2019, 7, 28, 23, 15, 58, 516, DateTimeKind.Local).AddTicks(678), "", null, "Administrador", "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6", "sa", null, "admin" });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "Active", "Blocked", "ContactAddress", "ContactEmail", "ContactName", "ContactPhone", "DataCreated", "Description", "ExpirationDate", "IdCategory", "IdFather", "IdLogo", "IdType", "Name" },
                values: new object[] { new Guid("7a34cc5b-324c-46c5-9f49-d61f5fec9b96"), true, true, "", "", "", "", new DateTime(2019, 7, 28, 23, 15, 58, 446, DateTimeKind.Local).AddTicks(3845), "Franquia padrão 'MidiaFone'", null, 1, null, null, 1, "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Active", "Blocked", "BusinessId", "DataCreated", "Expirate", "Name" },
                values: new object[] { new Guid("c128a299-4580-460b-b463-89c5d968796b"), true, true, new Guid("7a34cc5b-324c-46c5-9f49-d61f5fec9b96"), new DateTime(2019, 7, 28, 23, 15, 58, 509, DateTimeKind.Local).AddTicks(524), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Curiosidades MidiaFone" });

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
                name: "IX_Playlists_BusinessId",
                table: "Playlists",
                column: "BusinessId");
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
