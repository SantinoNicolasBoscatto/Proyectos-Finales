using Microsoft.EntityFrameworkCore;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Utilidades;

namespace NascarPage.Repositorio
{

    public interface ICampeonService
    {
        Task AgregarCampeon(Campeon campeon);
        Task<string> EliminarCampeon(int id);
        Task<bool> EsCampeon(int? id);
        Task<bool> Existe(int id);
        Task<bool> ExistePiloto(int? id);
        Task<List<Campeon>> GetCampeones(PaginacionDTO paginacionDTO);
        Task<Campeon?> GetCampeonId(int id);
        Task<Campeon?> GetCampeonYear(int year);
        Task ModificarCampeon(Campeon campeon);
    }

    public class CampeonService : ICampeonService
    {
        private readonly Negocio negocio;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CampeonService(Negocio negocio, IHttpContextAccessor httpContextAccessor)
        {
            this.negocio = negocio;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Campeon>> GetCampeones(PaginacionDTO paginacionDTO)
        {
            var query = negocio.Campeones.Include(x => x.Piloto).OrderByDescending(x => x.Year).AsNoTracking().AsQueryable();
            await httpContextAccessor.HttpContext!.InsertarCantidadPaginasCabecera(query, paginacionDTO.RecordsPorPagina);
            return await query.Paginar(paginacionDTO).ToListAsync();
        }
        public async Task<Campeon?> GetCampeonId(int id) => await negocio.Campeones.Include(x => x.Piloto).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Campeon?> GetCampeonYear(int year) => await negocio.Campeones.Include(x => x.Piloto).AsNoTracking().FirstOrDefaultAsync(x => x.Year == year);

        public async Task AgregarCampeon(Campeon campeon)
        {
            negocio.Add(campeon);
            await negocio.SaveChangesAsync();
        }



        public async Task ModificarCampeon(Campeon campeon)
        {
            negocio.Update(campeon);
            await negocio.SaveChangesAsync();
        }

        public async Task<string> EliminarCampeon(int id)
        {
            var campeonBD = await negocio.Campeones.Where(x => x.Id == id).FirstAsync();
            var URL = campeonBD.AutoCampeon;
            negocio.Remove(campeonBD);
            await negocio.SaveChangesAsync();
            return URL;
        }

        public async Task<bool> Existe(int id) => await negocio.Campeones.AnyAsync(x => x.Id == id);
        public async Task<bool> ExistePiloto(int? id) => await negocio.Pilotos.AnyAsync(x => x.Id == id);
        public async Task<bool> EsCampeon(int? id)
        {
            var count = negocio.Campeones.Where(x => x.PilotoId == id).Count();
            return await negocio.Pilotos.AnyAsync(x => x.Id == id && x.Campeonatos > count );
        }

    }
}
