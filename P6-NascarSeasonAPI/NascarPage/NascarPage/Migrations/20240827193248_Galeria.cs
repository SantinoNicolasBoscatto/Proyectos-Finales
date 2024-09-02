using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class Galeria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galeria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ronda = table.Column<int>(type: "INTEGER", nullable: false),
                    FotoUno = table.Column<string>(type: "TEXT", nullable: false),
                    FotoDos = table.Column<string>(type: "TEXT", nullable: false),
                    FotoTres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeria", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galeria");
        }
    }
}
