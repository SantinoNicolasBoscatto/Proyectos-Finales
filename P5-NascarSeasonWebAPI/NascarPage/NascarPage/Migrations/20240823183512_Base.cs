using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class Base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventoActual = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadDeEventos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Finish = table.Column<int>(type: "INTEGER", nullable: false),
                    Start = table.Column<int>(type: "INTEGER", nullable: false),
                    Laps = table.Column<int>(type: "INTEGER", nullable: false),
                    Led = table.Column<int>(type: "INTEGER", nullable: false),
                    Puntos = table.Column<int>(type: "INTEGER", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Piloto = table.Column<string>(type: "TEXT", nullable: false),
                    Interval = table.Column<string>(type: "TEXT", nullable: false),
                    Qual = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    FotoPiloto = table.Column<string>(type: "TEXT", nullable: false),
                    CarrerasGanadas = table.Column<int>(type: "INTEGER", nullable: false),
                    Poles = table.Column<int>(type: "INTEGER", nullable: false),
                    Top5s = table.Column<int>(type: "INTEGER", nullable: false),
                    Top10s = table.Column<int>(type: "INTEGER", nullable: false),
                    Campeonatos = table.Column<int>(type: "INTEGER", nullable: false),
                    EnActivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Distancia = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Vueltas = table.Column<int>(type: "INTEGER", nullable: false),
                    FotoPrimaria = table.Column<string>(type: "TEXT", nullable: false),
                    FotoSecundaria = table.Column<string>(type: "TEXT", nullable: false),
                    FotoTerciaria = table.Column<string>(type: "TEXT", nullable: false),
                    Orden = table.Column<int>(type: "INTEGER", nullable: true),
                    Disputada = table.Column<bool>(type: "INTEGER", nullable: false),
                    EnElCalendario = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TablaPosicionesManofactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Puntos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaPosicionesManofactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaPosicionesManofactura_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autos_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campeones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoCampeon = table.Column<string>(type: "TEXT", nullable: false),
                    PilotoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeones_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TablaPosicionesCampeonatoRegular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Wins = table.Column<int>(type: "INTEGER", nullable: false),
                    Poles = table.Column<int>(type: "INTEGER", nullable: false),
                    Top5s = table.Column<int>(type: "INTEGER", nullable: false),
                    Top10s = table.Column<int>(type: "INTEGER", nullable: false),
                    DNF = table.Column<int>(type: "INTEGER", nullable: false),
                    LapsLead = table.Column<int>(type: "INTEGER", nullable: false),
                    Puntos = table.Column<int>(type: "INTEGER", nullable: false),
                    Behind = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaPosicionesCampeonatoRegular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaPosicionesCampeonatoRegular_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TablaPosicionesCampeonatoRegular_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TablaPosicionesPlayoff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PuntosPlayoff = table.Column<int>(type: "INTEGER", nullable: false),
                    GanoEnLaRonda = table.Column<bool>(type: "INTEGER", nullable: false),
                    BehindPlayoff = table.Column<int>(type: "INTEGER", nullable: false),
                    Clasificado16avos = table.Column<bool>(type: "INTEGER", nullable: false),
                    Clasificado12avos = table.Column<bool>(type: "INTEGER", nullable: false),
                    Clasificado8avos = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClasificadoFinal4 = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaPosicionesPlayoff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TablaPosicionesPlayoff_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TablaPosicionesPlayoff_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_MarcaId",
                table: "Autos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_PilotoId",
                table: "Autos",
                column: "PilotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campeones_PilotoId",
                table: "Campeones",
                column: "PilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pistas_Orden",
                table: "Pistas",
                column: "Orden",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaPosicionesCampeonatoRegular_MarcaId",
                table: "TablaPosicionesCampeonatoRegular",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaPosicionesCampeonatoRegular_PilotoId",
                table: "TablaPosicionesCampeonatoRegular",
                column: "PilotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaPosicionesManofactura_MarcaId",
                table: "TablaPosicionesManofactura",
                column: "MarcaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaPosicionesPlayoff_MarcaId",
                table: "TablaPosicionesPlayoff",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_TablaPosicionesPlayoff_PilotoId",
                table: "TablaPosicionesPlayoff",
                column: "PilotoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "Campeones");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Pistas");

            migrationBuilder.DropTable(
                name: "TablaPosicionesCampeonatoRegular");

            migrationBuilder.DropTable(
                name: "TablaPosicionesManofactura");

            migrationBuilder.DropTable(
                name: "TablaPosicionesPlayoff");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Pilotos");
        }
    }
}
