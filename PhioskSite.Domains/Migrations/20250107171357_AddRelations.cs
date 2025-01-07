using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhioskSite.Domains.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "IssueDate",
                table: "Orders",
                newName: "ExpireDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "Orders",
                newName: "IssueDate");

            migrationBuilder.AddColumn<int>(
                name: "AccountNo",
                table: "Orders",
                type: "int",
                nullable: true);
        }
    }
}
