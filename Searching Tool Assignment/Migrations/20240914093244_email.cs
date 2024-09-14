using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Searching_Tool_Assignment.Migrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "77392b2e-0d7e-46a3-a411-446092da5994");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "159aeacb-1d7e-4688-93f8-310e1cdc78aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ad0b522-de64-4834-a32c-ebbac905c0a5", "AQAAAAEAACcQAAAAEA8F5gtpiWlD8DhaHNeB57WqIPaYva9uXITtLciflN+Dfn195KYLPXhcRd5wWL9koQ==", "2847b919-4f1c-464f-bfe7-c63cc822b3bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e9e2e47-a6f9-4c33-b23f-7b31331647ce", "AQAAAAEAACcQAAAAEGCUVI07hOdBhcJgXKu1rgJJ6dfja7xEXWWMjoH1697dOx8v0GuLvqdeIxYjKRFXig==", "cfcb934f-ed44-4856-bbdf-9603f11299b6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
