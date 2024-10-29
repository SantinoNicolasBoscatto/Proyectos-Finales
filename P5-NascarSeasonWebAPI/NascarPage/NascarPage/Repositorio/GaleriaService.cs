using Microsoft.EntityFrameworkCore;
using NascarPage.DTOs;
using NascarPage.Entitys;
using NascarPage.Utilidades;

namespace NascarPage.Repositorio
{
    public interface IGaleriaService
    {
        Task AgregarGaleria(Galeria galeria);
        Task<(string, string, string)> Eliminar(int id);
        Task<bool> Existe(int id);
        Task<List<Galeria>> GetFotos(PaginacionDTO paginacionDTO);
        Task<Galeria?> GetFotosPorId(int id);
        Task<Galeria?> GetFotosPorRonda(int ronda);
        Task ModificarGaleria(Galeria galeria);
    }

    public class GaleriaService : IGaleriaService
    {
        private readonly Negocio negocio;
        private readonly IHttpContextAccessor httpContextAccessor;

        public GaleriaService(Negocio negocio, IHttpContextAccessor httpContextAccessor)
        {
            this.negocio = negocio;
            this.httpContextAccessor = httpContextAccessor;
        }

        public  async Task<List<Galeria>> GetFotos(PaginacionDTO paginacionDTO)
        {
            var query = negocio.Galeria.AsNoTracking().AsQueryable();
            await httpContextAccessor.HttpContext!.InsertarCantidadPaginasCabecera(query, paginacionDTO.RecordsPorPagina);
            return await query.Paginar(paginacionDTO).ToListAsync();
        }

        public async Task<Galeria?> GetFotosPorId(int id)
        {
            return await negocio.Galeria.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Galeria?> GetFotosPorRonda(int ronda)
        {
            return await negocio.Galeria.AsNoTracking().FirstOrDefaultAsync(x => x.Ronda == ronda);
        }

        public async Task AgregarGaleria(Galeria galeria)
        {
            negocio.Add(galeria);
            await negocio.SaveChangesAsync();
        }

        public async Task ModificarGaleria(Galeria galeria)
        {
            negocio.Update(galeria);
            await negocio.SaveChangesAsync();
        }

        public async Task<(string, string, string)> Eliminar(int id)
        {
            var borrar = await negocio.Galeria.FirstOrDefaultAsync(x => x.Id == id);
            negocio.Remove(borrar!);
            var URLs = (borrar!.FotoUno, borrar.FotoDos, borrar.FotoTres);
            await negocio.SaveChangesAsync();
            return URLs;
        }

        public async Task<bool> Existe(int id) => await negocio.Galeria.AnyAsync(x => x.Id == id);
    }
}
