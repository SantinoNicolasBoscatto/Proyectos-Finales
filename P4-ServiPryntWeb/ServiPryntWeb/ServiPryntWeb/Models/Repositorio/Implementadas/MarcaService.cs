using Microsoft.EntityFrameworkCore;
using ServiPryntWeb.Models._Negocio;
using ServiPryntWeb.Models.DTO;
using ServiPryntWeb.Models.Entidades;
using ServiPryntWeb.Models.Repositorio.Abstractas;

namespace ServiPryntWeb.Models.Repositorio.Implementadas
{
    public class MarcaService : IMarcaService
    {
        private readonly Negocio _negocio;

        public MarcaService(Negocio negocio)
        {
            _negocio = negocio;
        }

        public bool AddMarca(Marcas marca)
        {
            try
            {
                _negocio.Marcas.Add(marca);
                var r = _negocio.SaveChanges();
                if (r == 1) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteMarca(int marcaId)
        {
            try
            {
                var marca = _negocio.Marcas.Find(marcaId);
                if (marca == null) return false;
                _negocio.Marcas.Remove(marca);
                var r = _negocio.SaveChanges();
                if (r == 1) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Marcas GetMarca(int MarcaId)
        {
            try
            {
                var marca = _negocio.Marcas.Find(MarcaId);
                return marca!;
            }
            catch (Exception)
            {
                return new Marcas();
            }
        }

        public MarcasListVm ListMarcas(int pageSize = 0, string term = "", bool paging = false, int currentPage = 0)
        {
            var data = new MarcasListVm();
            var list = _negocio.Marcas.AsNoTracking().ToList();
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list.Where(x => x.NombreMarca!.ToLower().Contains(term));
            }
            if (paging)
            {
                int count = list.Count;
                int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                list = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }
            data.MarcasQueryable = list.AsQueryable();
            return data;
        }

        public bool UpdateMarca(Marcas marca)
        {
            try
            {
                var aux = _negocio.Marcas.SingleOrDefault(x => x.IdMarca == marca.IdMarca);
                if (aux != null)
                {
                    aux.NombreMarca = marca.NombreMarca;
                    aux.IdMarca = marca.IdMarca;
                    _negocio.Entry(aux).State = EntityState.Modified;
                    var state = _negocio.SaveChanges();
                    if (state == 1) return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
