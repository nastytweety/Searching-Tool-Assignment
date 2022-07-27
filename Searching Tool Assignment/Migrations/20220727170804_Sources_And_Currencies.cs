using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Searching_Tool_Assignment.Migrations
{
    public partial class Sources_And_Currencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Sources_SourceId",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_SourceId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Currencies");

            migrationBuilder.RenameColumn(
                name: "EndPoint",
                table: "Sources",
                newName: "PriceKeyword");

            migrationBuilder.AddColumn<string>(
                name: "BaseURL",
                table: "Sources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateKeyword",
                table: "Sources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a89fc00c-986b-4116-988d-1fb546c7412e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d3729a56-4dae-4c8d-a685-c46e6b501617");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25ff0250-2297-4a7a-8d9e-7522a4f816b8", "AQAAAAEAACcQAAAAEPvZp0aTgq1T+S02u8o+VIwpnnxWTAcOYYnW7BUGRnwncNteJlPLdfIuIkQgCUXboA==", "aa0b292d-8ceb-4103-a9de-6560f706ff38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca59c622-ea1f-4bad-b951-61f1a0378b22", "AQAAAAEAACcQAAAAEHcBu3xUabFFGJ46f6bee2E74kUInnM3s9ZP+J61mqaWWsk1rGq2Mc4a+IUgBFzyxA==", "7709c69f-4ea8-464f-95d5-b423bd7cbab0" });

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BaseURL", "DateKeyword", "PriceKeyword" },
                values: new object[] { "https://www.bitstamp.net/api/v2/ticker/", "timestamp", "last" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseURL",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "DateKeyword",
                table: "Sources");

            migrationBuilder.RenameColumn(
                name: "PriceKeyword",
                table: "Sources",
                newName: "EndPoint");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Sources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Currencies",
                type: "int",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd335828-dd4c-4ea6-8995-dd8ddf0fe089", "AQAAAAEAACcQAAAAECMgBTpTsfD/gk/Ki1/Ua0PSrpt/CIemhpHrwamOm/WsBE3iYPZtXfplbh2LIL61wA==", "1ff367fa-f627-416c-84e8-20bd38e52d00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68726dcb-e0c6-43be-8cfe-a181d9378108", "AQAAAAEAACcQAAAAEIiW7GG5LmRq1YEP3sJ3huROxkMcz/+rSVr2krjvjT3JsCDoN+tN7pDJWSCsO4CVag==", "57676179-d206-4ed7-9140-b5a6af9409f3" });

            migrationBuilder.UpdateData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CurrencyId", "EndPoint" },
                values: new object[] { 1, "https://www.bitstamp.net/api/v2/ticker/" });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_SourceId",
                table: "Currencies",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Sources_SourceId",
                table: "Currencies",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id");
        }
    }
}
