using Microsoft.EntityFrameworkCore;
using ServiPryntWeb.Models._Negocio;
using ServiPryntWeb.Models.DTO;
using ServiPryntWeb.Models.Entidades;
using ServiPryntWeb.Models.Repositorio.Abstractas;

namespace ServiPryntWeb.Models.Repositorio.Implementadas
{
    public class ProductService : IProductService
    {
        private readonly Negocio _negocio;
        private readonly IFileService _fileService;
        public ProductService(Negocio negocio, IFileService fileService)
        {
            _negocio = negocio;
            _fileService = fileService;
        }

        public ProductosListVm ListProducts(int pageSize, string term = "", bool paging = false, int currentPage = 0,
            (int valueType, int valueStock, int valueOferta) tuple = default, bool oferta = false, bool onlyOfert = false,
            (int valueType, int valueMarca) tupleHome = default)
        {
            var data = new ProductosListVm();
            IEnumerable<Productos> list = _negocio.Productos.Include(x => x.Marca).Include(x => x.TypeProduct).AsNoTracking().ToList();
            if (oferta) list = list.Where(x => x.Oferta == false);
            if (onlyOfert)
            {
                list = list.Where(x => x.Oferta == true);
                data.ProductosQueryable = list.AsQueryable();
                return data;
            }


            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list.Where(x => x.Nombre!.ToLower().Contains(term));
            }
            if (tuple != default)
            {
                if (tuple.valueOferta == 1) list = list.Where(x => x.Oferta == true);
                else if (tuple.valueOferta == 2) list = list.Where(x => x.Oferta == false);
                if (tuple.valueStock == 1) list = list.Where(x => x.Stock == true);
                else if (tuple.valueStock == 2) list = list.Where(x => x.Stock == false);
                if (tuple.valueType != 0) list = list.Where(x => x.TypeId == tuple.valueType);

            }
            if (tupleHome != default)
            {
                if (tupleHome.valueType != 0) list = list.Where(x => x.TypeId == tupleHome.valueType);
                if (tupleHome.valueMarca != 0) list = list.Where(x => x.IdMarca == tupleHome.valueMarca);
            }

            if (paging)
            {
                int count = list.Count();
                int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                list = list.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }
            data.ProductosQueryable = list.AsQueryable();
            return data;
        }
        public Productos GetProduct(int ProductId)
        {
            try
            {
                var product = _negocio.Productos.Find(ProductId);
                return product!;
            }
            catch (Exception)
            {
                return new Productos();
            }
        }
        public bool AddProduct(Productos product)
        {
            try
            {
                if (product.ImagenFile != null)
                {
                    var tupla = _fileService.SaveFile(product.ImagenFile, "Imp-Img", ".png");
                    if (tupla.Item1 == 1) product.Imagen = tupla.Item2;
                }
                if (product.PdfFile != null)
                {
                    var tupla = _fileService.SaveFile(product.PdfFile!, "pdf", ".pdf");
                    if (tupla.Item1 == 1) product.Pdf = tupla.Item2;
                }
                _negocio.Productos.Add(product);
                var r = _negocio.SaveChanges();
                if (r == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateProduct(Productos productos)
        {
            try
            {
                var aux = _negocio.Productos.SingleOrDefault(x => x.IdProducto == productos.IdProducto);
                if (aux != null)
                {
                    if (productos.ImagenFile != null)
                    {
                        if (!string.IsNullOrEmpty(aux.Imagen)) _fileService.DeleteFile(aux.Imagen, "Imp-Img");
                        var tupla = _fileService.SaveFile(productos.ImagenFile, "Imp-Img", ".png");
                        if (tupla.Item1 == 1) aux.Imagen = tupla.Item2;
                    }
                    if (productos.PdfFile != null)
                    {
                        if (!string.IsNullOrEmpty(aux.Pdf)) _fileService.DeleteFile(aux.Pdf, "pdf");
                        var tupla = _fileService.SaveFile(productos.PdfFile, "pdf", ".pdf");
                        if (tupla.Item1 == 1) aux.Pdf = tupla.Item2;
                    }
                    aux.Nombre = productos.Nombre;
                    aux.Descripcion = productos.Descripcion;
                    aux.Stock = productos.Stock;
                    aux.Oferta = productos.Oferta;
                    aux.IdMarca = productos.IdMarca;
                    aux.TypeId = productos.TypeId;
                    aux.Precio = productos.Precio;
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
        public bool DeleteProduct(int ProductId)
        {
            try
            {
                var product = _negocio.Productos.Find(ProductId);
                if (product == null) return false;
                _negocio.Productos.Remove(product);
                var r = _negocio.SaveChanges();
                if (r == 1) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
