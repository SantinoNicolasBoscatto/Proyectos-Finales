using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;

namespace NascarPage.Repositorio
{
    public interface IPilotoService
    {
        Task<(string?, string?)> EliminarPiloto(int id);
        Task<bool> Existe(int id);
        Task<List<Piloto>> GetCampeones();
        Task<List<Piloto>> GetCarless();
        Task<Piloto?> GetPilotoPorId(int id);
        Task<List<Piloto>> GetPilotos();
        Task ModificarPiloto(Piloto piloto);
        Task<int> PostPilotos(Piloto piloto);
        (int?, int?) PreviousNext(int id);
    }

    public class PilotoService : IPilotoService
    {
        private readonly Negocio negocio;


        public PilotoService(Negocio negocio)
        {
            this.negocio = negocio;
        }


        public (int?, int?) PreviousNext(int id)
        {
            var list = negocio.Pilotos.AsEnumerable().OrderBy(x => int.Parse(x.Numero!)).ToList();
            var piloto = list.FirstOrDefault(x => x.Id == id);
            if (piloto == null) return (null, null);

            var index = list.IndexOf(piloto);
            int? prev = index > 0 ? list[index - 1].Id : null;
            int? next = index < list.Count - 1 ? list[index + 1].Id : null;
            return (prev, next);
        }

        public async Task<List<Piloto>> GetPilotos()
        {
            return negocio.Pilotos.Include(x => x.Auto).Include(x => x.Nacionalidad)
                    .AsEnumerable().OrderBy(x => int.Parse(x.Numero!)).ToList();
        }

        public async Task<List<Piloto>> GetCampeones()
        {
            return await negocio.Pilotos.Where(x => x.Campeonatos > 0).Include(x => x.Auto).Include(x => x.Nacionalidad)
                        .AsNoTracking().ToListAsync();
        }

        public async Task<List<Piloto>> GetCarless()
        {
            return await negocio.Pilotos.Where(x => x.Auto == null).Include(x => x.Nacionalidad).AsNoTracking().ToListAsync();
        }

        public async Task<int> PostPilotos(Piloto piloto)
        {          
            negocio.Add(piloto);
            await negocio.SaveChangesAsync();
            await negocio.SaveChangesAsync();
            return piloto.Id;
        }
        public async Task ModificarPiloto(Piloto piloto)
        {       
            negocio.Update(piloto);
            await negocio.SaveChangesAsync();

        }
        public async Task<(string?, string?)> EliminarPiloto(int id) 
        {
            var pilotoBD = await negocio.Pilotos.Include(x => x.Auto).Where(x => x.Id == id).FirstAsync();
            var URL = pilotoBD.FotoPiloto;
            negocio.Remove(pilotoBD);
            if(pilotoBD.Auto != null)
            {
                var auto = await negocio.Autos.Where(x => x.Id == pilotoBD.Auto.Id).FirstOrDefaultAsync();
                await negocio.SaveChangesAsync();
                return (URL, auto!.Foto);
            }
            await negocio.SaveChangesAsync();
            return (URL, null);
        }
        public async Task<Piloto?> GetPilotoPorId(int id) => await negocio.Pilotos.Include(x => x.Auto).Include(x => x.Nacionalidad).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> Existe(int id) => await negocio.Pilotos.AnyAsync(x => x.Id == id);
    }
}
