using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Searching_Tool_Assignment.Migrations
{
    public partial class SourcesAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3a885e86-f585-4249-9991-9b10f30552f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7cbc7b6a-55b3-46dd-a43f-80dd3a79f00e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d896513b-5462-4728-b2df-2fe2a8ea095d", "AQAAAAEAACcQAAAAEGNuXYtaz9zkkBdo6J5PXESfbjvDiBNXl9g+U8ZWOvikKaSRjN9VK1aYT6QJYRDmLA==", "32b1a196-1d9c-428f-aae6-f8e348d83b79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61e181b0-6c5e-408b-85c7-917a203651b0", "AQAAAAEAACcQAAAAEHUSSd8Sjxcqihi22Hk/J1Jz6gPb96tg89mhbEOHUfbax8SxI+djRAhxPUvIdmTqaA==", "4d2eb480-f31f-421b-9242-35cbca9192c7" });

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Bitfindex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6d04d167-3a80-441f-914e-f81012cbac33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d8d078fc-3501-40c6-8162-64ce48165317");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ed1843a-aefc-4ddb-933f-00bf4c8f539b", "AQAAAAEAACcQAAAAECoOSXCkMCmjRDP3KuLl0Z92+eF74KT+A6119hqPEYjwhcaqVi9a6PYOwj1mEvJYHg==", "e56f6bcf-e718-4a5f-8ff3-7a281e2c132c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73f8b08b-0664-4587-a9bf-7192170810f1", "AQAAAAEAACcQAAAAEDP1Vb2LtH/jW2cAoGXYO/oOOvWMfK0TUuuVvC9cPdUsctsfvJz8xrrIdeHq7qiWKQ==", "b8668a37-ddd7-4b01-84ae-c068e080dd66" });

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Bifindex");
        }
    }
}
