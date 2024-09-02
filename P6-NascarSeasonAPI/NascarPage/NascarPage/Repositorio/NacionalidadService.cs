using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;

namespace NascarPage.Repositorio
{
    public interface INacionalidadService
    {
        Task AgregarNacionalidad(Nacionalidad nacionalidad);
        Task<string> EliminarNacionalidad(int id);
        Task<bool> Existe(int id);
        Task<List<Nacionalidad>> GetNacionalidades();
        Task<Nacionalidad?> GetNacionalidadPorId(int id);
        Task ModificarNacionalidad(Nacionalidad nacionalidad);
    }

    public class NacionalidadService : INacionalidadService
    {
        private readonly Negocio negocio;

        public NacionalidadService(Negocio negocio)
        {
            this.negocio = negocio;
        }

        public async Task<List<Nacionalidad>> GetNacionalidades() => await negocio.Nacionalidades.AsNoTracking().ToListAsync();
        public async Task<Nacionalidad?> GetNacionalidadPorId(int id) => await negocio.Nacionalidades.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task AgregarNacionalidad(Nacionalidad nacionalidad)
        {
            negocio.Add(nacionalidad);
            await negocio.SaveChangesAsync();
        }

        public async Task ModificarNacionalidad(Nacionalidad nacionalidad)
        {
            negocio.Update(nacionalidad);
            await negocio.SaveChangesAsync();
        }

        public async Task<string> EliminarNacionalidad(int id)
        {
            try
            {
                var borrar = await negocio.Nacionalidades.FirstAsync(x => x.Id == id);
                negocio.Remove(borrar);
                var url = borrar.Bandera;
                await negocio.SaveChangesAsync();
                return url;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Existe(int id) => await negocio.Nacionalidades.AnyAsync(x => x.Id == id);

    }
}
