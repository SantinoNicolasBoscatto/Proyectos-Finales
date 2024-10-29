using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class Deleteunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pistas_Orden",
                table: "Pistas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pistas_Orden",
                table: "Pistas",
                column: "Orden",
                unique: true);
        }
    }
}
