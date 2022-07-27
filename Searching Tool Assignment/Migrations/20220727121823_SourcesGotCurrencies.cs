using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Searching_Tool_Assignment.Migrations
{
    public partial class SourcesGotCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Sources");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Sources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                    table.ForeignKey(
                        name: "FK_Currencies_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ece9a0bd-3868-465c-a41d-c4cfbbb5e9c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "13f2ca92-710a-4bbc-b6f4-17749ef82bbc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd335828-dd4c-4ea6-8995-dd8ddf0fe089", "Test Tester", "AQAAAAEAACcQAAAAECMgBTpTsfD/gk/Ki1/Ua0PSrpt/CIemhpHrwamOm/WsBE3iYPZtXfplbh2LIL61wA==", "1ff367fa-f627-416c-84e8-20bd38e52d00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68726dcb-e0c6-43be-8cfe-a181d9378108", "AQAAAAEAACcQAAAAEIiW7GG5LmRq1YEP3sJ3huROxkMcz/+rSVr2krjvjT3JsCDoN+tN7pDJWSCsO4CVag==", "57676179-d206-4ed7-9140-b5a6af9409f3" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CurrencyName", "Extension", "SourceId" },
                values: new object[] { 1, "Bitcoin to USD", "btcusd", null });

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CurrencyId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_SourceId",
                table: "Currencies",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Tickers");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Sources");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Sources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1050bbec-2061-473b-8949-5241f71eaf33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "89c2c1f4-7ac3-4007-a1e6-2e714397761e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "FullName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "838bd69d-7a7c-4a14-b0fe-403492054df8", "Giwrgos Chloros", "AQAAAAEAACcQAAAAEM/ATEMn57/GdLgsITMzRkmCGaNOwbi7TMjt4PMJbJUGEYOryRDzMye/ztPKeXYEpg==", "3a34887f-6f77-4ed4-b76e-9d4bf06c92ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3405204-c1d1-428a-bb8f-deafa6cb6b99", "AQAAAAEAACcQAAAAEO0TaeV+LOV9jvQLkRmJZuDgIPnvUiahKhA3jtG2Xs18FJrAb4FDtKlyJ0sNtzM+Lg==", "ddd1599f-da4a-4c1c-a4ba-87779ac64562" });

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Currency",
                value: "btcusd");
        }
    }
}
