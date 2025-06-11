using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHousingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIsAccepted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
