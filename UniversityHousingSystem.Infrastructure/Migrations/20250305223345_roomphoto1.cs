using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHousingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class roomphoto1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhoto_Rooms_RoomId",
                table: "RoomPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPhoto",
                table: "RoomPhoto");

            migrationBuilder.RenameTable(
                name: "RoomPhoto",
                newName: "RoomPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPhoto_RoomId",
                table: "RoomPhotos",
                newName: "IX_RoomPhotos_RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "RoomPhotos",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPhotos",
                table: "RoomPhotos",
                column: "RoomPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhotos_Rooms_RoomId",
                table: "RoomPhotos",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomPhotos_Rooms_RoomId",
                table: "RoomPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomPhotos",
                table: "RoomPhotos");

            migrationBuilder.RenameTable(
                name: "RoomPhotos",
                newName: "RoomPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_RoomPhotos_RoomId",
                table: "RoomPhoto",
                newName: "IX_RoomPhoto_RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "RoomPhoto",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomPhoto",
                table: "RoomPhoto",
                column: "RoomPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomPhoto_Rooms_RoomId",
                table: "RoomPhoto",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
