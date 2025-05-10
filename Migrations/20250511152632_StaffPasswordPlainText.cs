using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApplication.Migrations
{
    /// <inheritdoc />
    public partial class StaffPasswordPlainText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Staffs",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Staffs",
                newName: "PasswordHash");
        }
    }
}
