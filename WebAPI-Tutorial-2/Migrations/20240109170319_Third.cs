using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Tutorial_2.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sourses_Teachers_TeacherId",
                table: "Sourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sourses",
                table: "Sourses");

            migrationBuilder.RenameTable(
                name: "Sourses",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Sourses_TeacherId",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Sourses");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                table: "Sourses",
                newName: "IX_Sourses_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sourses",
                table: "Sourses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sourses_Teachers_TeacherId",
                table: "Sourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
