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

            migrationBuilder.InsertData(
                table: "BusinessTypes",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("eacebea6-0859-40cc-822f-a0b43cf4f09c"), true, new DateTime(2019, 6, 17, 1, 40, 48, 307, DateTimeKind.Local).AddTicks(7481), "Franquia como Tipo de Negócio.", "Franquia" },
                    { new Guid("00aba179-5d6d-4f7b-9df3-1dff4262594a"), true, new DateTime(2019, 6, 17, 1, 40, 48, 307, DateTimeKind.Local).AddTicks(7739), "Estabelecimento como Tipo de Negócio.", "Estabelecimento" },
                    { new Guid("f729156b-cf17-4e1b-af39-e8f28ac82ad0"), true, new DateTime(2019, 6, 17, 1, 40, 48, 307, DateTimeKind.Local).AddTicks(7874), "Anunciante como Tipo de Negócio.", "Anunciante" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Blocked", "DataCreated", "Description", "Name" },
                values: new object[] { new Guid("1a707818-eb75-421a-a28a-3d2172707dcb"), true, new DateTime(2019, 6, 17, 1, 40, 48, 313, DateTimeKind.Local).AddTicks(6339), "Categoria MidiaFone.", "MidiaFone" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("9ed1dc75-c3b5-4630-aae3-af24fb134190"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6378), "Permissão de leitura para rotina de Usuário.", "AppSlider.Read.User" },
                    { new Guid("ad80052b-545e-412e-9578-daf17220025f"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6563), "Permissão de escrita para rotina de Usuário.", "AppSlider.Write.User" },
                    { new Guid("e4544d2c-18aa-4da1-88d9-6e8de8a85cfc"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6614), "Permissão de leitura para rotina de Negócio.", "AppSlider.Read.Business" },
                    { new Guid("6a472771-b38a-4315-b770-9577d3b7d410"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6657), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("314aeed0-bfcb-4b76-baaa-7b8970fd01e8"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6777), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("85b152fe-411e-4821-8bd6-dbb3a5bd49e8"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6820), "Permissão de escrita para rotina de Tipos de Negócio.", "AppSlider.Write.BusinessType" },
                    { new Guid("fdd5bbbd-1d5f-46aa-93a5-8b069d5dbf17"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6892), "Permissão de leitura para rotina de Categoria.", "AppSlider.Read.Category" },
                    { new Guid("6b608f8d-e0f5-4d20-981d-2da0b489dab2"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(6990), "Permissão de escrita para rotina de Categoria.", "AppSlider.Write.Category" },
                    { new Guid("6420bc94-ad83-43c6-8f84-41c08492d8c6"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(7032), "Permissão de leitura para rotina de Playlist.", "AppSlider.Read.Playlist" },
                    { new Guid("d5b2c6e4-8f35-4a58-bd54-0c2b88fca3e3"), new DateTime(2019, 6, 17, 1, 40, 48, 318, DateTimeKind.Local).AddTicks(7073), "Permissão de escrita para rotina de Playlist.", "AppSlider.Write.Playlist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Blocked", "DataCreated", "Email", "Franchises", "Name", "Password", "Profile", "Roles", "Username" },
                values: new object[] { new Guid("b3613f5e-3b06-463a-943e-ca51b7dabbd7"), true, true, new DateTime(2019, 6, 17, 1, 40, 48, 320, DateTimeKind.Local).AddTicks(8952), "", null, "Administrador", "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6", "sa", null, "admin" });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "Active", "Blocked", "ContactAddress", "ContactEmail", "ContactName", "ContactPhone", "DataCreated", "Description", "ExpirationDate", "IdCategory", "IdFather", "IdLogo", "IdType", "Name" },
                values: new object[] { new Guid("12b1e0d6-1d07-4677-9e92-29ece0a0e842"), true, true, "", "", "", "", new DateTime(2019, 6, 17, 1, 40, 48, 253, DateTimeKind.Local).AddTicks(926), "Franquia padrão 'MidiaFone'", null, new Guid("1a707818-eb75-421a-a28a-3d2172707dcb"), null, null, new Guid("eacebea6-0859-40cc-822f-a0b43cf4f09c"), "MidiaFone" });

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
