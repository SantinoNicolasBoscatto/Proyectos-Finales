using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;

namespace NascarPage.Repositorio
{
    public interface ITablaService
    {
        Task ReiniciarTablasyCarreras();
        Task<List<PosicionManofactura>> GetManofacturas();
        Task<List<PosicionPlayoff>> GetTablaPlayOff();
        Task<List<PosicionPlayoff>> GetTablaPlayOffReducida();
        Task<List<PosicionCampeonatoRegular>> GetTablaRegular();
    }

    public class TablasService : ITablaService
    {
        private readonly Negocio negocio;

        public TablasService(Negocio negocio)
        {
            this.negocio = negocio;
        }
        public async Task<List<PosicionCampeonatoRegular>> GetTablaRegular()
        {
            return await negocio.TablaPosicionesCampeonatoRegular.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.Puntos).ToListAsync();
        }
        public async Task<List<PosicionPlayoff>> GetTablaPlayOff()
        {
            List<PosicionPlayoff> list = new List<PosicionPlayoff>();
            var fecha = await negocio.Calendario.Select(x => x.EventoActual).FirstAsync();
            if (fecha < 27)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.Clasificado16avos)
                        .ThenByDescending(x => x.PuntosPlayoff).ToListAsync();
            }
            else if (fecha <= 27 && fecha >= 29)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.Clasificado12avos)
                        .ThenByDescending(x => x.PuntosPlayoff).ToListAsync();
            }
            else if (fecha <= 30 && fecha >= 32)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.Clasificado8avos)
                        .ThenByDescending(x => x.PuntosPlayoff).ToListAsync();
            }
            else if (fecha <= 33 && fecha >= 35)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.ClasificadoFinal4)
                        .ThenByDescending(x => x.PuntosPlayoff).ToListAsync();
            }
            else
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                    .OrderByDescending(x => x.PuntosPlayoff).ToListAsync();
            }
            return list;
        }
        public async Task<List<PosicionPlayoff>> GetTablaPlayOffReducida()
        {
            List<PosicionPlayoff> list = new List<PosicionPlayoff>();
            var fecha = await negocio.Calendario.Select(x => x.EventoActual).FirstAsync();
            if (fecha < 28)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.Clasificado16avos)
                        .ThenByDescending(x => x.PuntosPlayoff)
                        .ThenByDescending(x => x.Regular.Wins)
                        .ThenByDescending(x => x.Regular.Top5s)
                        .ThenByDescending(x => x.Regular.Top10s)
                        .Take(20).ToListAsync();
            }
            else if (fecha >= 27 && fecha <= 30)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.Clasificado12avos)
                        .ThenByDescending(x => x.PuntosPlayoff)
                        .ThenByDescending(x => x.Regular.Wins)
                        .ThenByDescending(x => x.Regular.Top5s)
                        .ThenByDescending(x => x.Regular.Top10s)
                        .Take(16).ToListAsync();
            }
            else if (fecha >= 30 && fecha <= 33)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.Clasificado8avos)
                        .ThenByDescending(x => x.PuntosPlayoff)
                        .ThenByDescending(x => x.Regular.Wins)
                        .ThenByDescending(x => x.Regular.Top5s)
                        .ThenByDescending(x => x.Regular.Top10s)
                        .Take(12).ToListAsync();
            }
            else if (fecha >= 33 && fecha <= 36)
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                        .OrderByDescending(x => x.ClasificadoFinal4)
                        .ThenByDescending(x => x.PuntosPlayoff)
                        .ThenByDescending(x => x.Regular.Wins)
                        .ThenByDescending(x => x.Regular.Top5s)
                        .ThenByDescending(x => x.Regular.Top10s)
                        .Take(8).ToListAsync();
            }
            else
            {
                list = await negocio.TablaPosicionesPlayoff.Include(x => x.Piloto).Include(x => x.Marca)
                    .OrderByDescending(x => x.PuntosPlayoff).Take(4).ToListAsync();
            }
            return list;
        }
        public async Task<List<PosicionManofactura>> GetManofacturas()
        {
            return await negocio.TablaPosicionesManofactura.Include(x => x.Marca).OrderByDescending(x => x.Puntos).ToListAsync();
        }
        public async Task ReiniciarTablasyCarreras()
        {
            var listPlayoff = await negocio.TablaPosicionesPlayoff.ToListAsync();
            negocio.TablaPosicionesPlayoff.RemoveRange(listPlayoff);
            negocio.TablaPosicionesPlayoff
                .FromSqlInterpolated($"UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='TablaPosicionesPlayoff';");
            var listRegular = await negocio.TablaPosicionesCampeonatoRegular.ToListAsync();
            negocio.TablaPosicionesCampeonatoRegular.RemoveRange(listRegular);
            negocio.TablaPosicionesCampeonatoRegular
                .FromSqlInterpolated($"UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='TablaPosicionesCampeonatoRegular';");  
            
            var listManofactura = await negocio.TablaPosicionesManofactura.ToListAsync();
            negocio.TablaPosicionesManofactura.RemoveRange(listManofactura);
            negocio.TablaPosicionesManofactura
                .FromSqlInterpolated($"UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='TablaPosicionesManofactura';");

            var borrarCalendario = await negocio.Calendario.FirstOrDefaultAsync();
            if(borrarCalendario != null)negocio.Remove(borrarCalendario);
            var listaPistasDisputadas = await negocio.Pistas.Where(x => x.Disputada == true).ToListAsync();
            foreach (var item in listaPistasDisputadas)
            {
                item.Disputada = false;
            }
            await negocio.SaveChangesAsync();


            var list = await negocio.Pilotos.Include(x => x.Auto)
                .Where(x =>x.Auto != null && x.EnActivo == true).Select(x => new
            {
                Id = x.Id,
                MarcaId = x.Auto.MarcaId
            }).ToListAsync();
            foreach (var item in list)
            {

                var posicion = new PosicionCampeonatoRegular
                {
                    Id = item.Id,
                    PilotoId = item.Id,
                    Behind = 0,
                    Wins = 0,
                    Top5s = 0,
                    Top10s = 0,
                    Puntos = 0,
                    Poles = 0,
                    DNF = 0,
                    LapsLead = 0,
                    MarcaId = item.MarcaId
                };

                var posicionPlayoff = new PosicionPlayoff
                {
                    Id = item.Id,
                    PilotoId = item.Id,
                    PuntosPlayoff = 0,
                    BehindPlayoff = 0,
                    MarcaId = item.MarcaId,
                    Clasificado16avos = false,
                    Clasificado12avos = false,
                    Clasificado8avos = false,
                    ClasificadoFinal4 = false
                };
                negocio.Add(posicion);
                negocio.Add(posicionPlayoff);
                await negocio.SaveChangesAsync();
            }
            var lista = await negocio.Marcas.ToListAsync();
            foreach (var item in lista)
            {
                var posicionManofactura = new PosicionManofactura
                {
                    MarcaId = item.Id,
                    Puntos = 0,

                };
                negocio.Add(posicionManofactura);
                await negocio.SaveChangesAsync();
            }
            var calendario = new Calendario
            {
                Id = 1,
                EventoActual = 1,
                CantidadDeEventos = 36
            };
            negocio.Add(calendario);
            var carreras = await negocio.Carreras.ToListAsync();
            negocio.Carreras.RemoveRange(carreras);
            await negocio.SaveChangesAsync();
        }
    }
}
