using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhioskSite.Domains.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Address = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_UserAccount",
                        column: x => x.AccountNo,
                        principalTable: "UserAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PhoneName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Color = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    storageCapacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nchar(500)", fixedLength: true, maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    AddedOn = table.Column<DateOnly>(type: "date", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Invoice",
                        column: x => x.InvoiceNumber,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_AccountNo",
                table: "Invoice",
                column: "AccountNo");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_InvoiceNumber",
                table: "Phone",
                column: "InvoiceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
