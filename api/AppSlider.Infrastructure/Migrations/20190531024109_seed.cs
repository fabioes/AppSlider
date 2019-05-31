using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSlider.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataCreated", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0d5beeb3-fab5-43b4-b875-92dc95d435c7"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(5881), "Permissão de leitura para rotina de Usuário.", "AppSlider.Read.User" },
                    { new Guid("039556c8-d606-41a0-948c-eba734d7bd2a"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(7247), "Permissão de escrita para rotina de Usuário.", "AppSlider.Write.User" },
                    { new Guid("badbec7e-ae79-4be9-8da5-69d948ade166"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(7397), "Permissão de leitura para rotina de Negócio.", "AppSlider.Read.Business" },
                    { new Guid("15af4c6d-e100-4480-899c-b2e037a834a6"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(7486), "Permissão de escrita para rotina de Negócio.", "AppSlider.Write.Business" },
                    { new Guid("5acfcc83-d224-434c-a0c1-a2e087e7f833"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(7702), "Permissão de leitura para rotina de Tipos de Negócio.", "AppSlider.Read.BusinessType" },
                    { new Guid("dfa4e054-1967-4455-b9ed-eb9d3b15e4dd"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(7799), "Permissão de escrita para rotina de Tipos de Negócio.", "AppSlider.Write.BusinessType" },
                    { new Guid("5dea69a6-ad35-4b5e-9e21-d6b3c875bef7"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(7864), "Permissão de leitura para rotina de Categoria.", "AppSlider.Read.Category" },
                    { new Guid("92268d62-70e4-4055-b919-15d6574ac55b"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(7929), "Permissão de escrita para rotina de Categoria.", "AppSlider.Write.Category" },
                    { new Guid("25893bb8-2b90-42e1-90cf-f5602f628156"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(8014), "Permissão de leitura para rotina de Playlist.", "AppSlider.Read.Playlist" },
                    { new Guid("fc77fe60-9e6a-403e-b4e8-77c0f381a8e2"), new DateTime(2019, 5, 30, 23, 41, 8, 416, DateTimeKind.Local).AddTicks(8077), "Permissão de escrita para rotina de Playlist.", "AppSlider.Write.Playlist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "DataCreated", "Email", "Franchises", "Name", "Password", "Profile", "Roles", "Username" },
                values: new object[] { new Guid("48c07b5a-6939-4677-b409-a1eedb18e9c0"), true, new DateTime(2019, 5, 30, 23, 41, 8, 464, DateTimeKind.Local).AddTicks(7091), "", null, "Administrador", "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6", "admin", null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("039556c8-d606-41a0-948c-eba734d7bd2a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0d5beeb3-fab5-43b4-b875-92dc95d435c7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("15af4c6d-e100-4480-899c-b2e037a834a6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("25893bb8-2b90-42e1-90cf-f5602f628156"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5acfcc83-d224-434c-a0c1-a2e087e7f833"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5dea69a6-ad35-4b5e-9e21-d6b3c875bef7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("92268d62-70e4-4055-b919-15d6574ac55b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("badbec7e-ae79-4be9-8da5-69d948ade166"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dfa4e054-1967-4455-b9ed-eb9d3b15e4dd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc77fe60-9e6a-403e-b4e8-77c0f381a8e2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("48c07b5a-6939-4677-b409-a1eedb18e9c0"));
        }
    }
}
