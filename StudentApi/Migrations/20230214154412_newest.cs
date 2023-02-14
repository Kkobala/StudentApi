using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApi.Migrations
{
    /// <inheritdoc />
    public partial class newest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentGPA",
                table: "studentEntities");

            migrationBuilder.AddColumn<double>(
                name: "StudentGPA",
                table: "gradeEntities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentGPA",
                table: "gradeEntities");

            migrationBuilder.AddColumn<double>(
                name: "StudentGPA",
                table: "studentEntities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
