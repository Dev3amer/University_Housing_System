using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHousingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSexToBuilding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Sex",
                table: "Buildings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Buildings");
        }
    }
}
