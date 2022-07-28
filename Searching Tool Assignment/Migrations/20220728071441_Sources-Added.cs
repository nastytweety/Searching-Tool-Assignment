using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Searching_Tool_Assignment.Migrations
{
    public partial class SourcesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "2ed1843a-aefc-4ddb-933f-00bf4c8f539b", "AQAAAAEAACcQAAAAECoOSXCkMCmjRDP3KuLl0Z92+eF74KT+A6119hqPEYjwhcaqVi9a6PYOwj1mEvJYHg==", null, "e56f6bcf-e718-4a5f-8ff3-7a281e2c132c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "73f8b08b-0664-4587-a9bf-7192170810f1", "AQAAAAEAACcQAAAAEDP1Vb2LtH/jW2cAoGXYO/oOOvWMfK0TUuuVvC9cPdUsctsfvJz8xrrIdeHq7qiWKQ==", null, "b8668a37-ddd7-4b01-84ae-c068e080dd66" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "BaseURL", "DateTimeKeyword", "Name", "PriceKeyword" },
                values: new object[] { 2, "https://api.bitfinex.com/v1/pubticker/", "timestamp", "Bifindex", "last_price" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sources",
                keyColumn: "Id",
                keyValue: 2);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "e51395b9-450b-4225-ae56-7a2a8933d68e", "AQAAAAEAACcQAAAAELarhikmpeCVYyDtvd6E4x3G9X939CqLlD5DGa28YV9BavIiQ9F7U6I5aN9xGD9hqw==", "6947940268", "03c664b7-d0a8-4574-b9ee-c6fcbccb884b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "362fecfc-73d2-4d5c-9c3f-cd8c84ba088c", "AQAAAAEAACcQAAAAEFhViQgKDn5xMHaRSN+k/ftETOmslyXMi1Wyw/6Q6zK2UFFGlS7qZ9T13YmYv3mLAg==", "6947940268", "2db3ff66-e431-4a5b-8331-843d29ed9896" });
        }
    }
}
