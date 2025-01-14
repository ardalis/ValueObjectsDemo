using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValueObjects.ConsoleDemo.Migrations
{
    /// <inheritdoc />
    public partial class laborer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_M3Workers",
                table: "M3Workers");

            migrationBuilder.RenameTable(
                name: "M3Workers",
                newName: "Laborers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laborers",
                table: "Laborers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Laborers",
                table: "Laborers");

            migrationBuilder.RenameTable(
                name: "Laborers",
                newName: "M3Workers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M3Workers",
                table: "M3Workers",
                column: "Id");
        }
    }
}
