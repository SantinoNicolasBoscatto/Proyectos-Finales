using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using NascarPage;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Repositorio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NascarPageNUnitTests.Repositorio
{
    [TestFixture]
    public class AutoServiceNUnitTests
    {
        private IAutoService autoService = null!;
        private int idPrueba;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList() 
                .ForEach(b => fixture.Behaviors.Remove(b)); 
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var listaAutos = fixture.CreateMany<Auto>().ToList();
            idPrueba = listaAutos[0].Id;

            var options = new DbContextOptionsBuilder<Negocio>()
                .UseInMemoryDatabase(databaseName: $"NascarDatabase-{Guid.NewGuid()}").Options;
            var dbContextFake = new Negocio(options);
            dbContextFake.AddRange(listaAutos);
            dbContextFake.Marcas.Add(new Marca { Foto = "", Id = 1, Nombre = "Marca1" });
            dbContextFake.Nacionalidades.Add(new Nacionalidad { Bandera = "", Id = 1, Nombre = "Nacion1" });
            dbContextFake.Pilotos.Add(new Piloto { FotoPiloto = "", Id = 1, Nombre = "Piloto1", NacionalidadId = 1 });
            dbContextFake.SaveChanges();

            // Uso una instancia distinta de Negocio para AutoService, asi no arrastro las Tracked Entitys.
            var dbContextClean = new Negocio(options);
            autoService = new AutoService(dbContextClean);
        }

        [Test]
        public async Task GetAutos_RecibirListaAutos_ReturnNotNull()
        {
            var resultados = await autoService.GetAutos();
            Assert.That(resultados, Is.Not.Null);
            Assert.That(resultados.Count, Is.GreaterThan(1));
        }
        [Test]
        public async Task GetAutoId_RecibirAutoPorId_ReturnsNotNull()
        {
            var auto = await autoService.GetAutoId(idPrueba);
            Assert.That(auto, Is.Not.Null);
            Assert.That(idPrueba, Is.EqualTo(auto!.Id));
        }
        [Test]
        public async Task AgregarAuto_AgregarAutoBD_ReturnsTrue()
        {
            var auto = new Auto
            {
                Foto = "",
                MarcaId = 1,
                PilotoId = 1
            };
            await autoService.AgregarAuto(auto);
            var autoAgregado = await autoService.GetAutoId(auto.Id);
            Assert.That(autoAgregado, Is.Not.Null); 
            Assert.That(autoAgregado!.Id, Is.EqualTo(auto.Id));
        }
        [Test]
        public async Task ModificarAuto_VerificarModificacion_ReturnsTrue()
        {
            var autoBD = await autoService.GetAutoId(idPrueba);
            autoBD!.Foto = "HolaSoyUnaFoto";
            await autoService.ModificarAuto(autoBD);
            var mod = await autoService.GetAutoId(idPrueba);
            Assert.That(mod!.Foto, Is.EqualTo("HolaSoyUnaFoto"));
        }
        [Test]
        public async Task EliminarAuto_CapturarString_ReturnsNull()
        {
            var autoBD = await autoService.GetAutoId(idPrueba);
            var expectedString = autoBD!.Foto;
            var result = await autoService.EliminarAuto(idPrueba);
            Assert.That(result, Is.EqualTo(expectedString));
            Assert.That(await autoService.EliminarAuto(idPrueba), Is.Null);
        }

        private void DetachAllEntities(Negocio negocio)
        {
            var entries = negocio.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached;
            }
        }

    }
}
