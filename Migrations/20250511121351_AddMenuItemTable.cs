using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "MenuItems");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MenuItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "MenuItems");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
