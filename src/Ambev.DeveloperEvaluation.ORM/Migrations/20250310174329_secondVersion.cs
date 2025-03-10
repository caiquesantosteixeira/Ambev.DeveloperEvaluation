using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class secondVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentualDescount",
                table: "SaleItem");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "SaleItem",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrancheStoreName",
                table: "Sale",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Sale",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Sale",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "SaleItem");

            migrationBuilder.DropColumn(
                name: "BrancheStoreName",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Sale");

            migrationBuilder.AddColumn<int>(
                name: "PercentualDescount",
                table: "SaleItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
