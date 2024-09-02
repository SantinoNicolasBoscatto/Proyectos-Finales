using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class Correccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Carreras",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carreras",
                table: "Carreras",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carreras",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carreras");
        }
    }
}
