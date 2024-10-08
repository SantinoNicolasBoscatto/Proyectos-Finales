using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class TablasPosiciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GanoEnLaRonda",
                table: "TablaPosicionesPlayoff");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TablaPosicionesPlayoff",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_TablaPosicionesPlayoff_TablaPosicionesCampeonatoRegular_Id",
                table: "TablaPosicionesPlayoff",
                column: "Id",
                principalTable: "TablaPosicionesCampeonatoRegular",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TablaPosicionesPlayoff_TablaPosicionesCampeonatoRegular_Id",
                table: "TablaPosicionesPlayoff");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TablaPosicionesPlayoff",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "GanoEnLaRonda",
                table: "TablaPosicionesPlayoff",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
