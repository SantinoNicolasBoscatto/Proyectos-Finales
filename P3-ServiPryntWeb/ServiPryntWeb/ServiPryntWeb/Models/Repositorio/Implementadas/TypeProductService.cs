using Microsoft.EntityFrameworkCore;
using ServiPryntWeb.Models._Negocio;
using ServiPryntWeb.Models.DTO;
using ServiPryntWeb.Models.Entidades;
using ServiPryntWeb.Models.Repositorio.Abstractas;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace ServiPryntWeb.Models.Repositorio.Implementadas
{
    public class TypeProductService : ITypeProductService
    {
        private readonly Negocio _negocio;

        public TypeProductService(Negocio negocio)
        {
            _negocio = negocio;
        }

        public bool AddType(TypeProduct type)
        {
            try
            {
                _negocio.TypesProducts!.Add(type);
                var r = _negocio.SaveChanges();
                if (r == 1) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteType(int typeId)
        {
            try
            {
                var type = _negocio.TypesProducts!.Find(typeId);
                if (type == null) return false;
                _negocio.TypesProducts.Remove(type);
                var r = _negocio.SaveChanges();
                if (r == 1) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TypeProduct GetTypeProduct(int TypeId)
        {
            try
            {
                var type = _negocio.TypesProducts!.Find(TypeId);
                return type!;
            }
            catch (Exception)
            {
                return new TypeProduct();
            }
        }

        public TypesListVm ListTypes(int pageSize = 0, string term = "", bool paging = false, int currentPage = 0)
        {
            var data = new TypesListVm();
            var list = _negocio.TypesProducts!.AsNoTracking().ToList();
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list.Where(x => x.TypeName!.ToLower().Contains(term));
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
            data.TypesQueryable = list.AsQueryable();
            return data;
        }

        public bool UpdateType(TypeProduct type)
        {
            try
            {
                var aux = _negocio.TypesProducts!.SingleOrDefault(x => x.TypeId == type.TypeId);
                if (aux != null)
                {
                    aux.TypeName = type.TypeName;
                    aux.TypeId = type.TypeId;
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
