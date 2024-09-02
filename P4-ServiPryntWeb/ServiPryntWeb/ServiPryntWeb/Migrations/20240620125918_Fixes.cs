using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiPryntWeb.Migrations
{
    /// <inheritdoc />
    public partial class Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Impresoras_IdImpresora",
                table: "Ofertas");

            migrationBuilder.DropTable(
                name: "Impresoras");

            migrationBuilder.RenameColumn(
                name: "IdImpresora",
                table: "Ofertas",
                newName: "IdProducto");

            migrationBuilder.CreateTable(
                name: "TypesProducts",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProducts", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Imagen = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Pdf = table.Column<string>(type: "TEXT", nullable: true),
                    IdMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<int>(type: "INTEGER", nullable: false),
                    Stock = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_TypesProducts_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypesProducts",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdMarca",
                table: "Productos",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TypeId",
                table: "Productos",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Productos_IdProducto",
                table: "Ofertas",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Productos_IdProducto",
                table: "Ofertas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "TypesProducts");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Ofertas",
                newName: "IdImpresora");

            migrationBuilder.CreateTable(
                name: "Impresoras",
                columns: table => new
                {
                    IdImpresora = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Imagen = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Pdf = table.Column<string>(type: "TEXT", nullable: true),
                    Precio = table.Column<int>(type: "INTEGER", nullable: false),
                    Stock = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tinta = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impresoras", x => x.IdImpresora);
                    table.ForeignKey(
                        name: "FK_Impresoras_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impresoras_IdMarca",
                table: "Impresoras",
                column: "IdMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Impresoras_IdImpresora",
                table: "Ofertas",
                column: "IdImpresora",
                principalTable: "Impresoras",
                principalColumn: "IdImpresora",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
