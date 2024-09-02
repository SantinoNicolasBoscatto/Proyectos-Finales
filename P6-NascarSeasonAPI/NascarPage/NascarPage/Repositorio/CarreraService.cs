using Azure;
using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace NascarPage.Repositorio
{
    public interface ICarreraService
    {
        Task AgregarCarrera(List<Carrera> listCarreras);
        Task<List<Carrera>> GetCarrera(int id);
    }

    public class CarreraService : ICarreraService
    {
        private readonly Negocio negocio;

        public CarreraService(Negocio negocio)
        {
            this.negocio = negocio;
        }

        public async Task<List<Carrera>> GetCarrera(int id)
        {
            return await negocio.Carreras.AsNoTracking().Where(x => x.Evento == id).OrderBy(x => x.Finish).ToListAsync();
        }

        public async Task AgregarCarrera(List<Carrera> listCarreras)
        {
            try
            {
                var calendario = await negocio.Calendario.FirstAsync();
                var listMarcas = await negocio.Marcas.Select(x => x.Id).ToListAsync();
                await ActualizarFinalEtapa(calendario);
                await negocio.SaveChangesAsync();
                Dictionary<int, bool> dicMarcas = new Dictionary<int, bool>();
                foreach (var item in listMarcas)
                {
                    dicMarcas.Add(item, true);
                }
                // CARGO TABLA REGULAR
                foreach (var item in listCarreras)
                {
                    await ActualizarTablaPilotoYTablaManofactura(item, calendario, dicMarcas);
                }
                await negocio.SaveChangesAsync();
                // CARGO TABLA PLAYOFF
                foreach (var item in listCarreras)
                {
                    await ActualizarTablaPilotoPlayoff(item, calendario);
                }
                await negocio.SaveChangesAsync();

                // Actualizar Behind Regular
                var max = await negocio.TablaPosicionesCampeonatoRegular.OrderByDescending(x => x.Puntos).Select(x => x.Puntos).FirstOrDefaultAsync();
                var posicions = await negocio.TablaPosicionesCampeonatoRegular.ToListAsync();
                foreach (var item in posicions)
                {
                    item.Behind = item.Puntos - max;
                }
                // Actualizar Behind Playoff
                var minPlayoff = await VerificarEtapa(calendario);
                var playoff = await negocio.TablaPosicionesPlayoff.OrderByDescending(x => x.PuntosPlayoff).ToListAsync();
                int aux = 0;
                foreach (var item in playoff)
                {
                    item.BehindPlayoff = item.PuntosPlayoff - minPlayoff.Item1;
                    //if (!minPlayoff.Item2)
                    //{
                    if (item.BehindPlayoff > 0) aux = item.BehindPlayoff;
                    else item.BehindPlayoff -= aux;
                    //}
                }


                await negocio.AddRangeAsync(listCarreras);
                var pista = await negocio.Pistas.FirstOrDefaultAsync(x => x.Orden == calendario.EventoActual);
                pista!.Disputada = true;
                calendario.EventoActual += 1;
                await negocio.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        private async Task ActualizarTablaPilotoYTablaManofactura(Carrera item, Calendario calendario, Dictionary<int, bool> dicMarcas)
        {
            item.Evento = calendario.EventoActual;
            var piloto = await negocio.Pilotos.Include(x => x.Auto).FirstOrDefaultAsync(x => x.Numero == item.Numero && x.EnActivo == true);
            if (piloto is null)
            {
                return;
            }
            var posicion = await negocio.TablaPosicionesCampeonatoRegular.FirstAsync(x => x.PilotoId == piloto.Id);
            if (item.Finish == 1)
            {
                piloto.CarrerasGanadas += 1;
                posicion.Wins += 1;
            }
            if (item.Finish <= 5)
            {
                piloto.Top5s += 1;
                posicion.Top5s += 1;
            }
            if (item.Finish <= 10)
            {
                piloto.Top10s += 1;
                posicion.Top10s += 1;
            }
            if (item.Start == 1)
            {
                piloto.Poles += 1;
                posicion.Poles += 1;
            }
            if (item.Status != "Running")
            {
                posicion.DNF += 1;
            }
            posicion.LapsLead += item.Led;
            posicion.Puntos += item.Puntos;
            if (dicMarcas.ContainsKey(piloto.Auto.MarcaId) && dicMarcas[piloto.Auto.MarcaId])
            {
                var manofactura = await negocio.TablaPosicionesManofactura
                    .FirstOrDefaultAsync(x => x.MarcaId == piloto.Auto.MarcaId);
                if (manofactura is null)
                {
                    piloto.Auto.PilotoId = 0;
                }
                manofactura!.Puntos += item.Puntos;
                dicMarcas[piloto.Auto.MarcaId] = false;
            }
        }
        private async Task ActualizarTablaPilotoPlayoff(Carrera item, Calendario calendario)
        {
            var piloto = await negocio.Pilotos.Include(x => x.Auto).FirstOrDefaultAsync(x => x.Numero == item.Numero && x.EnActivo == true);
            if (piloto == null) return;
            var posicionPlayOff = await negocio.TablaPosicionesPlayoff.FirstOrDefaultAsync(x => x.PilotoId == piloto.Id);
            if (posicionPlayOff is null)
            {
                return;
            }
            if (calendario.EventoActual < 27)
            {
                switch (item.Finish)
                {
                    case 1:
                        posicionPlayOff.PuntosExtra += 15;
                        posicionPlayOff.Clasificado16avos = true;
                        break;
                    case 2:
                        posicionPlayOff.PuntosExtra += 10;
                        break;
                    case 3:
                        posicionPlayOff.PuntosExtra += 8;
                        break;
                    case 4:
                        posicionPlayOff.PuntosExtra += 7;
                        break;
                    case 5:
                        posicionPlayOff.PuntosExtra += 6;
                        break;
                    case 6:
                        posicionPlayOff.PuntosExtra += 5;
                        break;
                    case 7:
                        posicionPlayOff.PuntosExtra += 4;
                        break;
                    case 8:
                        posicionPlayOff.PuntosExtra += 3;
                        break;
                    case 9:
                        posicionPlayOff.PuntosExtra += 2;
                        break;
                    case 10:
                        posicionPlayOff.PuntosExtra += 1;
                        break;
                    default:
                        break;
                }
                await negocio.SaveChangesAsync();
            }
            else if (calendario.EventoActual >= 27 && calendario.EventoActual <= 29 && posicionPlayOff.Clasificado16avos)
            {
                if (item.Finish == 1) posicionPlayOff.Clasificado12avos = true;
            }
            else if (calendario.EventoActual >= 30 && calendario.EventoActual <= 32 && posicionPlayOff.Clasificado12avos)
            {
                if (item.Finish == 1) posicionPlayOff.Clasificado8avos = true;
            }
            else if (calendario.EventoActual >= 33 && calendario.EventoActual <= 35 && posicionPlayOff.Clasificado8avos)
            {
                if (item.Finish == 1) posicionPlayOff.ClasificadoFinal4 = true;
            }
            posicionPlayOff.PuntosPlayoff += item.Puntos;
        }
        private async Task ActualizarFinalEtapa(Calendario calendario)
        {
            if (calendario.EventoActual == 27)
                await PuntuacionPlayoff(calendario, 16, "Clasificado16avos", 2000, true);
            else if (calendario.EventoActual == 30)
                await PuntuacionPlayoff(calendario, 12, "Clasificado12avos", 3000);
            else if (calendario.EventoActual == 33)
                await PuntuacionPlayoff(calendario, 8, "Clasificado8avos", 4000);
            if (calendario.EventoActual == 36)
                await PuntuacionPlayoff(calendario, 4, "ClasificadoFinal4", 5000);
        }
        private async Task PuntuacionPlayoff(Calendario calendario, int clasificados, string Etapa,
             int BasePoints, bool primerFase = false)
        {
            var clasificadosPlayoff = await PuntuacionPlayoffExtensions(calendario, clasificados, Etapa, BasePoints);
            foreach (var c in clasificadosPlayoff)
            {
                c.PuntosPlayoff = primerFase ? BasePoints + c.PuntosExtra : BasePoints;
                c.Regular.Puntos = c.PuntosPlayoff;
            }
        }
        // Metodos Auxiliares
        private async Task<List<PosicionPlayoff>> PuntuacionPlayoffExtensions(Calendario calendario, int clasificados, string Etapa,
             int BasePoints)
        {
            Type type = typeof(PosicionPlayoff);
            PropertyInfo etapaClasificatoria = type.GetProperty(Etapa)!;

            var predicateTrue = BuildPredicate(Etapa, true);
            var predicateFalse = BuildPredicate(Etapa, false);
            var count = await negocio.TablaPosicionesPlayoff.Where(predicateTrue).CountAsync();

            var pilotos = await negocio.TablaPosicionesPlayoff
            .Where(predicateFalse).OrderByDescending(x => x.Regular.Puntos)
            .Take(clasificados - count).ToListAsync();

            foreach (var p in pilotos)
            {
                etapaClasificatoria.SetValue(p, true);
            }
            await negocio.SaveChangesAsync();
            return await negocio.TablaPosicionesPlayoff.Include(x => x.Regular)
                                            .Where(predicateTrue).ToListAsync();
        }
        private async Task<(int, bool)> VerificarEtapa(Calendario calendario)
        {
            if (calendario.EventoActual < 27)
            {
                var count = await negocio.TablaPosicionesPlayoff.Where(x => x.Clasificado16avos == true).CountAsync();
                var skips = await negocio.TablaPosicionesPlayoff.Where(x => x.Clasificado16avos == false)
                            .OrderByDescending(x => x.PuntosPlayoff).Select(x => x.PuntosPlayoff).ToListAsync();
                var r = skips.Skip(16 - count);
                return (r.FirstOrDefault(), true);
            }
            else if (calendario.EventoActual >= 27 && calendario.EventoActual <= 29)
            {
                var count = await negocio.TablaPosicionesPlayoff.Where(x => x.Clasificado12avos == true).CountAsync();
                var skips = await negocio.TablaPosicionesPlayoff.Where(x => x.Clasificado12avos == false)
                            .OrderByDescending(x => x.PuntosPlayoff).Select(x => x.PuntosPlayoff).ToListAsync();
                var r = skips.Skip(12 - count);
                return (r.FirstOrDefault(), false);
            }
            else if (calendario.EventoActual >= 30 && calendario.EventoActual <= 32)
            {
                var count = await negocio.TablaPosicionesPlayoff.Where(x => x.Clasificado8avos == true).CountAsync();
                var skips = await negocio.TablaPosicionesPlayoff.Where(x => x.Clasificado8avos == false)
                            .OrderByDescending(x => x.PuntosPlayoff).Select(x => x.PuntosPlayoff).ToListAsync();
                var r = skips.Skip(8 - count);
                return (r.FirstOrDefault(), false);
            }
            else if (calendario.EventoActual >= 33 && calendario.EventoActual <= 35)
            {
                var count = await negocio.TablaPosicionesPlayoff.Where(x => x.ClasificadoFinal4 == true).CountAsync();
                var skips = await negocio.TablaPosicionesPlayoff.Where(x => x.ClasificadoFinal4 == false)
                            .OrderByDescending(x => x.PuntosPlayoff).Select(x => x.PuntosPlayoff).ToListAsync();
                var r = skips.Skip(4 - count);
                return (r.FirstOrDefault(), false);
            }
            else if (calendario.EventoActual == 36)
            {
                return (await negocio.TablaPosicionesPlayoff.Where(x => x.ClasificadoFinal4 == true)
                .OrderByDescending(x => x.PuntosPlayoff).Select(x => x.PuntosPlayoff).FirstOrDefaultAsync(), false);
            }
            else return (0, false);
        }
        private Expression<Func<PosicionPlayoff, bool>> BuildPredicate(string etapa, bool bandera)
        {
            var parameter = Expression.Parameter(typeof(PosicionPlayoff), "x");
            var property = Expression.Property(parameter, etapa);
            var value = Expression.Constant(bandera);

            var predicate = Expression.Equal(property, value);
            return Expression.Lambda<Func<PosicionPlayoff, bool>>(predicate, parameter);
        }
    }
}
