using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;

namespace NascarPage.Repositorio
{
    public interface IAutoService
    {
        Task AgregarAuto(Auto auto);
        Task<string?> EliminarAuto(int id);
        Task<bool> Existe(int id); 
        Task<bool> ExisteMarca(int id);
        Task<bool> ExistePiloto(int? id);
        Task<Auto?> GetAutoId(int id);
        Task<List<Auto>> GetAutos();
        Task ModificarAuto(Auto auto);
    }

    public class AutoService : IAutoService
    {
        private readonly Negocio negocio;

        public AutoService(Negocio negocio)
        {
            this.negocio = negocio;
        }
        public async Task<List<Auto>> GetAutos() => await negocio.Autos.Include(x => x.Marca).Include(x => x.Piloto).AsNoTracking().ToListAsync();
        public async Task<Auto?> GetAutoId(int id) => await negocio.Autos.Include(x => x.Marca).Include(x => x.Piloto).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task AgregarAuto(Auto auto)
        {
            negocio.Add(auto);
            await negocio.SaveChangesAsync();
        }

        public async Task ModificarAuto(Auto auto)
        {     
            negocio.Update(auto);
            await negocio.SaveChangesAsync();
        }

        public async Task<string?> EliminarAuto(int id)
        {
            var autoBD = await negocio.Autos.FirstOrDefaultAsync(x => x.Id == id);
            if (autoBD == null) return null;
            var URL = autoBD.Foto;
            negocio.Remove(autoBD);
            await negocio.SaveChangesAsync();
            return URL!;
        }

        public async Task<bool> Existe(int id) => await negocio.Autos.AnyAsync(x => x.Id == id);
        public async Task<bool> ExistePiloto(int? id) => await negocio.Pilotos.AnyAsync(x => x.Id == id);
        public async Task<bool> ExisteMarca(int id) => await negocio.Marcas.AnyAsync(x => x.Id == id);
    }
}
