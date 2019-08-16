using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class AddedCNPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CNPJ",
                table: "Business",
                nullable: false,
                defaultValue: 0L);   
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: new Guid("1ed3ae84-dcdb-49a2-bbd8-28adffb960c5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2d6e9497-37c5-45b6-aad9-9f916f11ec74"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2f713fab-e66f-4251-889f-aae3a80a4e03"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3fa0238e-501b-44f3-9ee7-7fb5c90928e3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("42851c45-e47b-4311-b1b1-70ba549f96e9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6b241709-0e51-4f61-8199-6621d14620c5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("72774ffd-0ee8-42a9-b3b9-c3a12986ebe2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7dacadf6-a2f2-4ae5-a3eb-40e01e44aa0d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("841fecd2-3d2a-43eb-849e-39483ebb3eaa"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2952b6c-fde0-4a37-b66d-ab2d6705688f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4097746-33b9-492b-8222-a41fcfdb0742"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d239a7d3-f3de-4282-89dc-3ec1adbb2c6d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f18bfe40-4e10-474b-af17-77f5bf1f30ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e9c04a0-1fd5-4356-a08a-3da029e21b30"));

            migrationBuilder.DeleteData(
                table: "Business",
                keyColumn: "Id",
                keyValue: new Guid("ffa4d1f3-6877-4de2-9973-95ece57a5b3c"));

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Business");

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "Id", "Active", "Blocked", "ContactAddress", "ContactEmail", "ContactName", "ContactPhone", "DataCreated", "Description", "ExpirationDate", "IdCategory", "IdFather", "IdLogo", "IdType", "Name" },
                values: new object[] { new Guid("7a34cc5b-324c-46c5-9f49-d61f5fec9b96"), true, true, "", "", "", "", new DateTime(2019, 7, 28, 23, 15, 58, 446, DateTimeKind.Local).AddTicks(3845), "Franquia padrão 'MidiaFone'", null, 1, null, null, 1, "MidiaFone" });

            migrationBuilder.UpdateData(
                table: "BusinessTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCreated",
                value: new DateTime(2019, 7, 28, 23, 15, 58, 487, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "BusinessTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCreated",
                value: new DateTime(2019, 7, 28, 23, 15, 58, 487, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "BusinessTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCreated",
                value: new DateTime(2019, 7, 28, 23, 15, 58, 487, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCreated",
                value: new DateTime(2019, 7, 28, 23, 15, 58, 502, DateTimeKind.Local).AddTicks(7648));

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
                    { new Guid("c155e7ac-68ad-43df-85c4-8a579cf73aed"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(602), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("3b49dd53-a367-4ffb-b799-14610e7f3b4a"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(663), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("cd0b05d8-2d0f-4f27-971d-3659c7d11b72"), new DateTime(2019, 7, 28, 23, 15, 58, 514, DateTimeKind.Local).AddTicks(1089), "Permissão de escrita para rotina de Equipamento.", "AppSlider.Write.Equipament" },
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
                table: "Playlists",
                columns: new[] { "Id", "Active", "Blocked", "BusinessId", "DataCreated", "Expirate", "Name" },
                values: new object[] { new Guid("c128a299-4580-460b-b463-89c5d968796b"), true, true, new Guid("7a34cc5b-324c-46c5-9f49-d61f5fec9b96"), new DateTime(2019, 7, 28, 23, 15, 58, 509, DateTimeKind.Local).AddTicks(524), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Curiosidades MidiaFone" });
        }
    }
}
