using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionCarreraId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carreras",
                table: "Carreras");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carreras",
                newName: "Evento");

            migrationBuilder.AlterColumn<int>(
                name: "Evento",
                table: "Carreras",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Evento",
                table: "Carreras",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Carreras",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carreras",
                table: "Carreras",
                column: "Id");
        }
    }
}
