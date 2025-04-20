using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHousingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHighSchoolDept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HighSchoolDepartments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HighSchoolDepartments",
                columns: table => new
                {
                    HighSchoolDepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighSchoolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighSchoolDepartments", x => x.HighSchoolDepartmentId);
                    table.ForeignKey(
                        name: "FK_HighSchoolDepartments_HighSchools_HighSchoolId",
                        column: x => x.HighSchoolId,
                        principalTable: "HighSchools",
                        principalColumn: "HighSchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HighSchoolDepartments_HighSchoolId_Name",
                table: "HighSchoolDepartments",
                columns: new[] { "HighSchoolId", "Name" },
                unique: true);
        }
    }
}
