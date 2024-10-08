using Microsoft.AspNetCore.Mvc;
using NascarPage;
using NascarPage.Controllers;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NascarPageTests.Tests_Unitarios
{
    [TestClass]
    public class AutosControllerTest : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosAutos()
        {
            //Preparacion 
            var nombreBD = Guid.NewGuid().ToString();
            var negocio = ConstruirContext(nombreBD);
            var mapper = ConfigurarMapper();
            await ConstruirData(negocio);
            
            var negocio2 = ConstruirContext(nombreBD);
            var controller = new AutosController(new AutoService(negocio), null, mapper, null);
            // Prueba
            var respuestaHTTP = await controller.Get();
            var result = respuestaHTTP.Result as OkObjectResult;
            var value = result!.Value as List<LecturaAutoDTO>;
            Assert.AreEqual(2, value!.Count);

        }

        private async Task ConstruirData(Negocio negocio)
        {
            negocio.Add(new Marca() { Id = 1, Nombre = "Marca1", Foto = "" });
            negocio.Add(new Marca() { Id = 2, Nombre = "Marca2", Foto = "" });
            negocio.Add(new Nacionalidad() { Id = 1, Bandera = "", Nombre = "Arg" });
            negocio.Add(new Piloto()
            {
                Id = 1,
                Campeonatos = 0,
                Edad = 20,
                CarrerasGanadas = 0,
                EnActivo = true,
                FotoPiloto = "",
                NacionalidadId = 1,
                Nombre = "Driver1",
                Numero = "01",
                Poles = 0,
                Top10s = 0,
                Top5s = 0
            });
            negocio.Add(new Piloto()
            {
                Id = 2,
                Campeonatos = 0,
                Edad = 20,
                CarrerasGanadas = 0,
                EnActivo = true,
                FotoPiloto = "",
                NacionalidadId = 1,
                Nombre = "Driver2",
                Numero = "01",
                Poles = 0,
                Top10s = 0,
                Top5s = 0
            });
            negocio.Add(new Auto() { Id = 1, Foto = "", PilotoId = 1, MarcaId = 1 });
            negocio.Add(new Auto() { Id = 2, Foto = "", PilotoId = 2, MarcaId = 2 });
            await negocio.SaveChangesAsync();
        }
    }
}
