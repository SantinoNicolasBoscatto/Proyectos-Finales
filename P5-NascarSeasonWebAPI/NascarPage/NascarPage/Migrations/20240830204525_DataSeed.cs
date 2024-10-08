using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NascarPage.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Pilotos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Foto", "Nombre" },
                values: new object[,]
                {
                    { 1, "", "Chevrolet" },
                    { 2, "", "Ford" },
                    { 3, "", "Dodge" },
                    { 4, "", "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "Nacionalidades",
                columns: new[] { "Id", "Bandera", "Nombre" },
                values: new object[,]
                {
                    { 1, "", "Estados Unidos" },
                    { 2, "", "Alemania" },
                    { 3, "", "Inglaterra" },
                    { 4, "", "Mexico" },
                    { 5, "", "Argentina" },
                    { 6, "", "Francia" },
                    { 7, "", "Italia" },
                    { 8, "", "Dinamarca" }
                });

            migrationBuilder.InsertData(
                table: "Pistas",
                columns: new[] { "Id", "Disputada", "Distancia", "EnElCalendario", "FotoPrimaria", "FotoSecundaria", "FotoTerciaria", "Nombre", "Orden", "Vueltas" },
                values: new object[,]
                {
                    { 1, false, "", true, "", "", "", "Daytona 500", 1, 200 },
                    { 2, false, "", true, "", "", "", "California 500", 2, 250 },
                    { 3, false, "", true, "", "", "", "California Night 600", 3, 275 },
                    { 4, false, "", true, "", "", "", "Darlington 500", 4, 367 },
                    { 5, false, "", true, "", "", "", "Gateway 400", 5, 267 },
                    { 6, false, "", true, "", "", "", "Martinsville 500", 6, 500 },
                    { 7, false, "", true, "", "", "", "Atlanta 500", 7, 325 },
                    { 8, false, "", true, "", "", "", "Atlanta Night 600", 8, 350 },
                    { 9, false, "", true, "", "", "", "Watkins Glen 220", 9, 90 },
                    { 10, false, "", true, "", "", "", "Dover 400", 10, 267 },
                    { 11, false, "", true, "", "", "", "Kansas 400", 11, 267 },
                    { 12, false, "", true, "", "", "", "Las Vegas 400", 12, 267 },
                    { 13, false, "", true, "", "", "", "Twin Ring 400", 13, 250 },
                    { 14, false, "", true, "", "", "", "Bristol Dirty Night 500", 14, 500 },
                    { 15, false, "", true, "", "", "", "Indianapolis 400", 15, 160 },
                    { 16, false, "", true, "", "", "", "Nashville 400", 16, 325 },
                    { 17, false, "", true, "", "", "", "Nazareth 400", 17, 325 },
                    { 18, false, "", true, "", "", "", "Infineon 350k", 18, 112 },
                    { 19, false, "", true, "", "", "", "Rockingham 350", 19, 393 },
                    { 20, false, "", true, "", "", "", "Phoenix 500k", 20, 312 },
                    { 21, false, "", true, "", "", "", "New Hampshire 400", 21, 312 },
                    { 22, false, "", true, "", "", "", "Pocono 500", 22, 200 },
                    { 23, false, "", true, "", "", "", "Richmond 400", 23, 400 },
                    { 24, false, "", true, "", "", "", "Evergreen 400", 24, 450 },
                    { 25, false, "", true, "", "", "", "Talladega 500", 25, 188 },
                    { 26, false, "", true, "", "", "", "Milwaukee Night 450", 26, 350 },
                    { 27, false, "", true, "", "", "", "Chicagoland 400", 27, 267 },
                    { 28, false, "", true, "", "", "", "Iowa Night 400", 28, 400 },
                    { 29, false, "", true, "", "", "", "Kentucky Speedway 400", 29, 267 },
                    { 30, false, "", true, "", "", "", "Michigan 400", 30, 200 },
                    { 31, false, "", true, "", "", "", "Lowes Night 600", 31, 400 },
                    { 32, false, "", true, "", "", "", "Bristol 500", 32, 500 },
                    { 33, false, "", true, "", "", "", "Bristol Night 500", 33, 500 },
                    { 34, false, "", true, "", "", "", "Texas 500", 34, 333 },
                    { 35, false, "", true, "", "", "", "Coca Cola 600", 35, 250 },
                    { 36, false, "", true, "", "", "", "Homestead Miami 400 Championship", 36, 267 }
                });

            migrationBuilder.InsertData(
                table: "Pilotos",
                columns: new[] { "Id", "Campeonatos", "CarrerasGanadas", "Edad", "EnActivo", "FotoPiloto", "NacionalidadId", "Nombre", "Numero", "Poles", "Top10s", "Top5s" },
                values: new object[,]
                {
                    { 1, 0, 2, 28, true, "", 1, "Milo Davis", "00", 4, 19, 10 },
                    { 2, 2, 49, 40, true, "", 1, "Ryan Smith", "1", 37, 153, 108 },
                    { 3, 0, 8, 39, true, "", 2, "Hans Muller", "2", 1, 59, 24 },
                    { 4, 0, 0, 22, true, "", 1, "Jim Anderson", "5", 0, 2, 0 },
                    { 5, 2, 31, 32, true, "", 1, "Zack Taylor", "7", 43, 90, 67 },
                    { 6, 0, 4, 27, true, "", 1, "Ethan Brown", "9", 2, 23, 11 },
                    { 7, 0, 2, 32, true, "", 1, "Michael Mrucz", "10", 2, 8, 4 },
                    { 8, 0, 7, 31, true, "", 1, "Dave Seth", "11", 10, 28, 16 },
                    { 9, 0, 0, 24, true, "", 3, "Roger Moore", "12", 1, 5, 2 },
                    { 10, 0, 0, 23, true, "", 1, "Philipp Harrinson", "14", 0, 3, 0 },
                    { 11, 1, 27, 38, true, "", 4, "Daniel Suarez", "15", 17, 60, 43 },
                    { 12, 0, 3, 39, true, "", 5, "Agustin Canapino", "16", 7, 33, 17 },
                    { 13, 0, 1, 26, true, "", 1, "Kenny Douglas", "17", 2, 10, 4 },
                    { 14, 0, 0, 21, true, "", 1, "Marnie Miller", "18", 0, 0, 0 },
                    { 15, 0, 3, 27, true, "", 1, "Matt McGlovin", "21", 9, 21, 10 },
                    { 16, 0, 5, 33, true, "", 6, "Pierre Lefevre", "22", 3, 39, 20 },
                    { 17, 6, 97, 48, true, "", 1, "Jack Miller", "24", 53, 270, 183 },
                    { 18, 0, 1, 34, true, "", 1, "Emmet Wilson", "27", 0, 14, 6 },
                    { 19, 0, 0, 29, true, "", 1, "Michael Schmidt", "29", 0, 17, 9 },
                    { 20, 0, 8, 36, true, "", 1, "Colton Berta", "31", 15, 34, 21 },
                    { 21, 0, 0, 32, true, "", 1, "Thomas Turner", "32", 0, 6, 2 },
                    { 22, 0, 1, 25, true, "", 1, "Miles Biffle", "34", 2, 19, 9 },
                    { 23, 0, 4, 30, true, "", 1, "Mark Martins", "36", 1, 53, 28 },
                    { 24, 0, 0, 24, true, "", 1, "Noah Sanders", "37", 0, 8, 0 },
                    { 25, 0, 0, 25, true, "", 3, "Reginald Loundon", "38", 0, 3, 1 },
                    { 26, 3, 13, 43, true, "", 8, "Kevin Magnussen", "39", 21, 47, 31 },
                    { 27, 0, 0, 27, true, "", 1, "Scott Gilliham", "42", 0, 5, 1 },
                    { 28, 0, 1, 34, true, "", 1, "Oliver Cook", "47", 0, 12, 6 },
                    { 29, 0, 21, 30, true, "", 3, "Lewis Hammersmith", "48", 40, 56, 36 },
                    { 30, 0, 6, 36, true, "", 1, "Carl Menard", "50", 8, 26, 11 },
                    { 31, 0, 1, 29, true, "", 1, "Tony Montana", "55", 2, 22, 7 },
                    { 32, 0, 0, 24, true, "", 7, "Pipo Argenti", "56", 0, 1, 0 },
                    { 33, 0, 1, 35, true, "", 1, "Henry Brooks", "71", 1, 4, 2 },
                    { 34, 0, 0, 33, true, "", 1, "Chad Pepper", "73", 1, 20, 4 },
                    { 35, 3, 35, 31, true, "", 1, "Santino Boscatto", "77", 29, 69, 54 },
                    { 36, 0, 0, 28, true, "", 1, "Quinn Simons", "81", 0, 7, 2 },
                    { 37, 0, 4, 36, true, "", 7, "Marco Rossi", "83", 6, 40, 21 },
                    { 38, 0, 0, 26, true, "", 1, "Benjamin Owen", "87", 0, 3, 0 },
                    { 39, 0, 13, 29, true, "", 1, "Harry Mcqueen", "88", 22, 41, 30 },
                    { 40, 1, 17, 32, true, "", 1, "Cole Anderson", "99", 25, 51, 29 }
                });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id", "Foto", "MarcaId", "PilotoId" },
                values: new object[,]
                {
                    { 1, "", 4, 1 },
                    { 2, "", 1, 2 },
                    { 3, "", 3, 3 },
                    { 4, "", 1, 4 },
                    { 5, "", 3, 5 },
                    { 6, "", 2, 6 },
                    { 7, "", 1, 7 },
                    { 8, "", 4, 8 },
                    { 9, "", 3, 9 },
                    { 10, "", 1, 10 },
                    { 11, "", 4, 11 },
                    { 12, "", 2, 12 },
                    { 13, "", 2, 13 },
                    { 14, "", 4, 14 },
                    { 15, "", 2, 15 },
                    { 16, "", 3, 16 },
                    { 17, "", 1, 17 },
                    { 18, "", 1, 18 },
                    { 19, "", 1, 19 },
                    { 20, "", 1, 20 },
                    { 21, "", 2, 21 },
                    { 22, "", 2, 22 },
                    { 23, "", 1, 23 },
                    { 24, "", 2, 24 },
                    { 25, "", 2, 25 },
                    { 26, "", 1, 26 },
                    { 27, "", 1, 27 },
                    { 28, "", 4, 28 },
                    { 29, "", 1, 29 },
                    { 30, "", 1, 30 },
                    { 31, "", 4, 31 },
                    { 32, "", 4, 32 },
                    { 33, "", 2, 33 },
                    { 34, "", 4, 34 },
                    { 35, "", 1, 35 },
                    { 36, "", 2, 36 },
                    { 37, "", 4, 37 },
                    { 38, "", 4, 38 },
                    { 39, "", 1, 39 },
                    { 40, "", 2, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Pistas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marcas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Pilotos",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Nacionalidades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Pilotos");
        }
    }
}
