using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class NacionalidadPiloto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Nacionalidades_NacionalidadId",
                table: "Pilotos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Nacionalidades_NacionalidadId",
                table: "Pilotos",
                column: "NacionalidadId",
                principalTable: "Nacionalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Nacionalidades_NacionalidadId",
                table: "Pilotos");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Nacionalidades_NacionalidadId",
                table: "Pilotos",
                column: "NacionalidadId",
                principalTable: "Nacionalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
