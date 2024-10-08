using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class ExtraPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PuntosExtra",
                table: "TablaPosicionesPlayoff",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Numero",
                value: "15");

            migrationBuilder.UpdateData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Top10s", "Top5s" },
                values: new object[] { 69, 59 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuntosExtra",
                table: "TablaPosicionesPlayoff");

            migrationBuilder.UpdateData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Numero",
                value: "77");

            migrationBuilder.UpdateData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Top10s", "Top5s" },
                values: new object[] { 84, 78 });
        }
    }
}
