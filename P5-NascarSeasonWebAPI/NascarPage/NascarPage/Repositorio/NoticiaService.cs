using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;

namespace NascarPage.Repositorio
{
    public interface INoticiaService
    {
        Task AgregarNoticia(Noticia noticia);
        Task<string> EliminarNoticia(int id);
        Task<bool> Existe(int id);
        Task<Noticia?> GetNoticiaId(int id);
        Task<List<Noticia>> GetNoticias();
        Task<List<Noticia>> GetNoticiasBig();
        Task<List<Noticia>> GetNoticiasHalf();
        Task ModificarNoticia(Noticia noticia);
    }

    public class NoticiaService : INoticiaService
    {
        private readonly Negocio negocio;

        public NoticiaService(Negocio negocio)
        {
            this.negocio = negocio;
        }

        public async Task<List<Noticia>> GetNoticias() => await negocio.Noticias.AsNoTracking().ToListAsync();
        public async Task<List<Noticia>> GetNoticiasBig() => await negocio.Noticias.Where(x => !string.IsNullOrEmpty(x.Detalles))
            .AsNoTracking().ToListAsync();
        public async Task<List<Noticia>> GetNoticiasHalf() => await negocio.Noticias.Where(x => string.IsNullOrEmpty(x.Detalles))
            .AsNoTracking().ToListAsync();
        public async Task<Noticia?> GetNoticiaId(int id) => await negocio.Noticias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);


        public async Task AgregarNoticia(Noticia noticia)
        {
            negocio.Add(noticia);
            await negocio.SaveChangesAsync();
        }

        public async Task ModificarNoticia(Noticia noticia)
        {
            negocio.Update(noticia);
            await negocio.SaveChangesAsync();
        }

        public async Task<string> EliminarNoticia(int id)
        {
            var noticiaBD = await negocio.Noticias.Where(x => x.Id == id).FirstAsync();
            var URL = noticiaBD.Foto;
            negocio.Remove(noticiaBD);
            await negocio.SaveChangesAsync();
            return URL!;
        }

        public async Task<bool> Existe(int id) => await negocio.Noticias.AnyAsync(x => x.Id == id);
    }
}
