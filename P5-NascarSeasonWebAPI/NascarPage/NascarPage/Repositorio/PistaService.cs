using Microsoft.EntityFrameworkCore;
using NascarPage.Entitys;
using System.Linq;

namespace NascarPage.Repositorio
{
    public interface IPistaService
    {
        Task AgregarPista(Pista pista);
        Task AgregarySacarPistaCalendario(int idEntra, int idSale);
        Task<(string, string, string)> EliminarPista(int id);
        Task<bool> Existe(int id);
        Task<bool> ExisteEnCalendario(int id);
        Task<bool> ExisteFecha(int? orden);
        Task<bool> ExisteFueraEnCalendario(int id);
        Task<Calendario?> GetCalendario();
        Task<Pista?> GetPistaId(int id);
        Task<Pista?> GetPistaOrden(int Orden);
        Task<List<Pista>> GetPistas(bool calendario);
        Task ModificarOrdenPistas(int idPista, int idPistaSecundaria);
        Task ModificarPista(Pista pista);
    }

    public class PistaService : IPistaService
    {
        private readonly Negocio negocio;

        public PistaService(Negocio negocio)
        {
            this.negocio = negocio;
        }

        public async Task<List<Pista>> GetPistas(bool calendario)
        {
            if(calendario)
            {
                return await negocio.Pistas.OrderBy(x => x.Orden).Where(x => x.EnElCalendario == true)
                    .AsNoTracking().ToListAsync();
            }
            return await negocio.Pistas.OrderBy(x => x.Orden).AsNoTracking().ToListAsync();
        }

        public async Task<Pista?> GetPistaId(int id)
        {
            return await negocio.Pistas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Calendario?> GetCalendario()
        {
            return await negocio.Calendario.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Pista?> GetPistaOrden(int Orden)
        {
            return await negocio.Pistas.AsNoTracking().FirstOrDefaultAsync(x => x.Orden == Orden);
        }

        public async Task AgregarPista(Pista pista)
        {
            negocio.Add(pista);
            if (pista.EnElCalendario == false) pista.Orden = null;
            await negocio.SaveChangesAsync();
        }

        public async Task ModificarPista(Pista pista)
        {
            negocio.Update(pista);
            //if (pista.EnElCalendario == false) pista.Orden = null;
            //else if(pista.Orden == null)
            //{
            //    var maxOrd = await negocio.Pistas.Where(x => x.EnElCalendario == true).OrderByDescending(x => x.Orden).FirstOrDefaultAsync();
            //    if (maxOrd is null) pista.Orden = 1;
            //    else pista.Orden = maxOrd.Orden + 1;
            //}
            await negocio.SaveChangesAsync();
        }

        public async Task ModificarOrdenPistas(int idPista, int idPistaSecundaria)
        {
            var pistaPrimaria = await GetPistaId(idPista);
            var pistaSecundaria = await GetPistaId(idPistaSecundaria);

            int? aux = pistaPrimaria!.Orden;
            pistaPrimaria!.Orden = pistaSecundaria!.Orden;
            pistaSecundaria!.Orden = null;
            negocio.Update(pistaSecundaria);
            await negocio.SaveChangesAsync();
            pistaSecundaria!.Orden = aux;
            negocio.UpdateRange(pistaPrimaria,pistaSecundaria);
            await negocio.SaveChangesAsync();
        }

        public async Task AgregarySacarPistaCalendario(int idEntra, int idSale)
        {
            var entra = await GetPistaId(idEntra);
            var sale = await GetPistaId(idSale);

            var aux = sale!.Orden;
            sale.EnElCalendario = false;
            sale!.Orden = null;
            negocio.Update(sale);
            await negocio.SaveChangesAsync();
            entra!.Orden = aux;
            entra.EnElCalendario = true;
            negocio.Update(entra);
            await negocio.SaveChangesAsync();
        }

        public async Task<(string, string,string)> EliminarPista(int id)
        {
            var pista = await negocio.Pistas.FirstAsync(x => x.Id == id);
            negocio.Remove(pista);
            var fotos = (pista.FotoPrimaria, pista.FotoSecundaria, pista.FotoTerciaria);
            var orden = pista.Orden;
            await negocio.SaveChangesAsync();
            var ordenar = await negocio.Pistas.Where(x => x.EnElCalendario == true && x.Orden > orden).ToListAsync();
            foreach (var item in ordenar)
            {
                item.Orden -= 1;
            }
            await negocio.SaveChangesAsync();
            return fotos;
        }

        public async Task<bool> Existe (int id) =>  await negocio.Pistas.AnyAsync(x => x.Id == id);
        public async Task<bool> ExisteEnCalendario (int id) =>  await negocio.Pistas.AnyAsync(x => x.Id == id && x.EnElCalendario == true);
        public async Task<bool> ExisteFueraEnCalendario (int id) =>  await negocio.Pistas.AnyAsync(x => x.Id == id && x.EnElCalendario == false);
        public async Task<bool> ExisteFecha (int? orden) =>  await negocio.Pistas.AnyAsync(x => x.Orden == orden);
    }
}
