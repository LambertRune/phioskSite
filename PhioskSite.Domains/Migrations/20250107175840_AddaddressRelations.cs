using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhioskSite.Domains.Migrations
{
    /// <inheritdoc />
    public partial class AddaddressRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "AddressId");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Country", "Number", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 101, "New York", "USA", "10", "10001", "Main Street" },
                    { 102, "Chicago", "USA", "25", "60614", "Elm Avenue" },
                    { 103, "London", "UK", "221B", "NW1 6XE", "Baker Street" },
                    { 104, "Paris", "France", "50", "75001", "Rue de Rivoli" },
                    { 105, "Paris", "France", "110", "75008", "Avenue des Champs-Élysées" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "AddedOn", "Brand", "Color", "Description", "ImageUrl", "OrderId", "PhoneName", "Price", "StorageCapacity" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 1), "Samsung", "Phantom Black", "High-performance smartphone with a sleek design and powerful camera.", "https://example.com/images/galaxy_s23.jpg", null, "Galaxy S23", 999.99m, 256 },
                    { 2, new DateOnly(2025, 1, 2), "Apple", "Starlight", "The latest iPhone with exceptional speed and a stunning display.", "https://example.com/images/iphone_15.jpg", null, "iPhone 15", 1199.99m, 512 },
                    { 3, new DateOnly(2025, 1, 3), "Google", "Obsidian", "Google's flagship smartphone with cutting-edge AI features.", "https://example.com/images/pixel_8_pro.jpg", null, "Pixel 8 Pro", 899.99m, 128 },
                    { 4, new DateOnly(2025, 1, 4), "Sony", "Frosted Silver", "A photography powerhouse with a stunning 4K OLED display.", "https://example.com/images/xperia_1_v.jpg", null, "Xperia 1 V", 1099.99m, 256 },
                    { 5, new DateOnly(2025, 1, 5), "OnePlus", "Volcanic Black", "A balanced combination of performance and value for tech enthusiasts.", "https://example.com/images/oneplus_12.jpg", null, "OnePlus 12", 799.99m, 256 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "FirstName", "LastName", "Mail", "Phone" },
                values: new object[,]
                {
                    { 5, null, "Charlie", "Davis", "charlie.davis@example.com", "444-222-1111" },
                    { 1, 101, "John", "Doe", "john.doe@example.com", "123-456-7890" },
                    { 2, 102, "Jane", "Smith", "jane.smith@example.com", "987-654-3210" },
                    { 3, 103, "Alice", "Johnson", "alice.johnson@example.com", null },
                    { 4, 104, "Bob", "Brown", "bob.brown@example.com", "555-123-4567" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ExpireDate", "InvoiceDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 15), new DateOnly(2025, 1, 1), 1 },
                    { 2, new DateOnly(2025, 1, 18), new DateOnly(2025, 1, 3), 2 },
                    { 3, new DateOnly(2025, 1, 20), new DateOnly(2025, 1, 5), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Users",
                newName: "Address");
        }
    }
}
