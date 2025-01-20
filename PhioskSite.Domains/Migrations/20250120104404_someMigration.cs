using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhioskSite.Domains.Migrations
{
    /// <inheritdoc />
    public partial class someMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/Phones/iPhone_16_ultramarine_1.webp");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/Phones/iPhone_16_ultramarine_1.webp");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/Phones/iPhone_16_ultramarine_1.webp");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/Phones/iPhone_16_ultramarine_1.webp");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/Phones/iPhone_16_ultramarine_1.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/frontPic1.svg");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/frontPic1.svg");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/frontPic1.svg");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/frontPic1.svg");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/frontPic1.svg");
        }
    }
}
