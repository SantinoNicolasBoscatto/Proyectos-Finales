using Microsoft.EntityFrameworkCore;
using ServiManagement.Models._Negocio;
using ServiManagement.Models.DTO;
using ServiManagement.Models.Entidades;
using ServiManagement.Models.Repositorio.Abstracto;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiManagement.Models.Repositorio.Implementado
{
    public class OrdenesService : IOrdenesService
    {

        private readonly Negocio negocio;

        public OrdenesService(Negocio negocio)
        {
            this.negocio = negocio;
        }

        //SELECTS

        public async Task<List<string>> ListaModelos()
        {
            var list = await negocio.Ordenes.AsNoTracking().GroupBy(x => x.Modelo).ToListAsync();
            List<string> lista = new List<string>();
            foreach (var item in list) {
                foreach (var subitem in item)
                {
                    lista.Add(subitem.Modelo);
                    break;
                }
            }
            return lista;       
        }  
        public async Task<List<Marca>> ListaMarcas() => await negocio.Marcas.AsNoTracking().ToListAsync();

        public async Task<List<OrdenesDTO>> ListaOrdenes(DateTime desde, DateTime hasta, int tecnico = 0)
        {
            var list = await negocio.Ordenes.AsNoTracking().Include(x => x.Usuario).ToListAsync();
            if (tecnico != 0) list = list.Where(x => x.Tecnico == tecnico).ToList();
            List<Orden> auxList = new List<Orden>();
            foreach (var o in list)
            {
                if (o.FechaDeCarga >= desde && o.FechaDeCarga <= hasta) auxList.Add(o);
            }

            var data = auxList.GroupBy(x => x.Tecnico).Select(x => new
            {
                tecnicoId = x.Key,
                tecnicoName = x.Select(y => y.Usuario.Name).First(),
                MaquinasCerradas = x.Count(),
                MontoGenerado = x.Sum(x => x.Monto)
            }).ToList();

            List<OrdenesDTO> listDTO = new List<OrdenesDTO>();
            foreach (var item in data)
            {
                OrdenesDTO aux = new OrdenesDTO
                {
                    TecnicoId = (int)item.tecnicoId,
                    TecnicoName = item.tecnicoName,
                    MontoTotal = item.MontoGenerado,
                    OrdenesCompletadas = item.MaquinasCerradas
                };
                listDTO.Add(aux);
            }
            return listDTO;
        }
        public async Task<ListOrdenes> ListaFiltrada (DateTime desde, DateTime hasta, int tecnico, int pageSize, int currentPage = 0)
        {
            ListOrdenes dataList = new ListOrdenes();
            var list = await negocio.Ordenes.AsNoTracking().Include(x => x.Marca).Where(x => x.Tecnico == tecnico).ToListAsync();
            var auxList = new List<Orden>();
            foreach (var o in list)
            {
                if (o.FechaDeCarga >= desde && o.FechaDeCarga <= hasta) auxList.Add(o);
            }
            auxList = auxList.OrderBy(x => x.FechaDeCarga).ToList();
            int count = auxList.Count();
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            dataList.ListaOrdenes = auxList.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            dataList.PageSize = pageSize;
            dataList.CurrentPage = currentPage;
            dataList.TotalPages = TotalPages;

            return dataList;
        }
        public async Task<Orden> ObtenerPorId(int id) => await negocio.Ordenes.Include(x => x.Marca).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);   
        public async Task<Orden> ObtenerPorNumeroOrden(string ord) 
        => await negocio.Ordenes.Include(x => x.Marca).FirstOrDefaultAsync(x => x.NumeroDeOrden == ord);


        public async Task<string> ObtenerTecnico(int id)
        {
            var user = await negocio.Usuarios.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return user.Name;
        }




        public async Task<bool> AgregarOrden(Orden orden)
        {
            try
            {
                negocio.Add(orden);
                negocio.Entry(orden.Marca).State = EntityState.Unchanged;
                var r = await negocio.SaveChangesAsync();
                if (r != 1) return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ModificarOrden(Orden orden)
        {
            try
            {
                negocio.Update(orden);
                negocio.Entry(orden.Marca).State = EntityState.Unchanged;
                negocio.Entry(orden).Property(o => o.Tecnico).IsModified = false;
                negocio.Entry(orden).Property(o => o.Id).IsModified = false;
                var r = await negocio.SaveChangesAsync();
                if (r != 1) return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
