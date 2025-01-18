using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhioskSite.Domains.Migrations
{
    /// <inheritdoc />
    public partial class foto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/frontpic1");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/frontpic1");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/frontpic1");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/frontpic1");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/frontpic1");
        }
    }
}
