using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;

namespace NascarPage.Repositorio
{
    public interface IMarcaService
    {
        Task ActulizarMarca(Marca marca);
        Task AgregarMarca(Marca marca);
        Task<List<Marca>> GetMarcas();
        Task<Marca?> GetMarcaPorId(int id);
        Task<bool> Existe(int id);
        Task<(string, List<string>)> EliminarMarca(int id);
    }
    public class MarcaService : IMarcaService
    {
        private readonly Negocio negocio;

        public MarcaService(Negocio negocio)
        {
            this.negocio = negocio;
        }

        public async Task<List<Marca>> GetMarcas()
        {
            return await negocio.Marcas.Include(x => x.ListaAutos).AsNoTracking().ToListAsync();
        }

        public async Task<Marca?> GetMarcaPorId(int id)
        {
            return await negocio.Marcas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AgregarMarca(Marca marca)
        {
            negocio.Add(marca);
            await negocio.SaveChangesAsync();
        }

        public async Task ActulizarMarca(Marca marca)
        {
            negocio.Update(marca);
            await negocio.SaveChangesAsync();
        }

        public async Task<(string, List<string>)> EliminarMarca(int id)
        {
            var marca = await negocio.Marcas.Include(x => x.ListaAutos).FirstOrDefaultAsync(x => x.Id == id);
            negocio.Remove(marca!);
            var marcaImg = marca!.Foto;
            var listaImgAutos = new List<string>();
            foreach (var item in marca.ListaAutos)
            {
                if(item.Foto != null) listaImgAutos.Add(item.Foto!);
            }
            await negocio.SaveChangesAsync();
            return (marcaImg, listaImgAutos);
        }


        public async Task<bool> Existe(int id) => await negocio.Marcas.AnyAsync(x => x.Id == id);

    }
}
