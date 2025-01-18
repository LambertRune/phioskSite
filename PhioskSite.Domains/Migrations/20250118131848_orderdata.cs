using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhioskSite.Domains.Migrations
{
    /// <inheritdoc />
    public partial class orderdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ExpireDate", "InvoiceDate", "UserId" },
                values: new object[] { 4, new DateOnly(2025, 1, 20), new DateOnly(2025, 1, 5), 3 });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderId",
                value: null);
        }
    }
}
