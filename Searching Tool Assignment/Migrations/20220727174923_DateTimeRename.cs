using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Searching_Tool_Assignment.Migrations
{
    public partial class DateTimeRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateKeyword",
                table: "Sources",
                newName: "DateTimeKeyword");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "Tickers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "aab45516-2578-46ba-b09e-e157b70f5ed3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "04143f64-49c4-4d72-9e27-498f7eecf7a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e51395b9-450b-4225-ae56-7a2a8933d68e", "AQAAAAEAACcQAAAAELarhikmpeCVYyDtvd6E4x3G9X939CqLlD5DGa28YV9BavIiQ9F7U6I5aN9xGD9hqw==", "03c664b7-d0a8-4574-b9ee-c6fcbccb884b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "362fecfc-73d2-4d5c-9c3f-cd8c84ba088c", "AQAAAAEAACcQAAAAEFhViQgKDn5xMHaRSN+k/ftETOmslyXMi1Wyw/6Q6zK2UFFGlS7qZ9T13YmYv3mLAg==", "2db3ff66-e431-4a5b-8331-843d29ed9896" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeKeyword",
                table: "Sources",
                newName: "DateKeyword");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Tickers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
