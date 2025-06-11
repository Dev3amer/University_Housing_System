using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHousingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNeededSpaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableSpaces",
                table: "RegistrationPeriods",
                newName: "AvailableMaleSpaces");

            migrationBuilder.AddColumn<int>(
                name: "AvailableFemaleSpaces",
                table: "RegistrationPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableFemaleSpaces",
                table: "RegistrationPeriods");

            migrationBuilder.RenameColumn(
                name: "AvailableMaleSpaces",
                table: "RegistrationPeriods",
                newName: "AvailableSpaces");
        }
    }
}
