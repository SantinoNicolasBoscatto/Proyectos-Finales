using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiPryntWeb.Models;
using ServiPryntWeb.Models.Entidades;
using ServiPryntWeb.Models.Repositorio.Abstractas;
using System.Diagnostics;

namespace ServiPryntWeb.Controllers
{
    public class HomeController : Controller 
    {
        private readonly IProductService _productService;
        private readonly IMarcaService _marcaService;
        private readonly ITypeProductService _typeProductService;


        public HomeController(IProductService impresoraService, ITypeProductService typeProductService, 
            IMarcaService marcaService)
        {
            _productService = impresoraService;
            _typeProductService = typeProductService;
            _marcaService = marcaService;
        }

        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult Servicios()
        {
            return View();
        }

        public IActionResult Productos(int size, int index)
        {
            ViewBag.size = size;
            var list = _productService.ListProducts(pageSize: 0, onlyOfert: true); 
            return View(list);
        }

        public PartialViewResult ProductosAJAX(int? valueType, int? valueMarca, int size, int index) 
        {
            var pageSize = 6;
            var list = valueType.HasValue || valueMarca.HasValue ?
            _productService.ListProducts(pageSize: pageSize, paging: true, currentPage: index, tupleHome: (valueType ?? 0,
            valueMarca ?? 0), oferta: true) : _productService.ListProducts(paging: true, currentPage: index, 
            pageSize: pageSize, oferta: true);

            ViewBag.size = size;
            ViewBag.valueType = valueType;
            ViewBag.valueMarca = valueMarca;
            ViewBag.Type = _typeProductService.ListTypes(pageSize: 0, paging: false);
            ViewBag.Marca = _marcaService.ListMarcas(pageSize: 0, paging: false);
            return PartialView("_ProductosPartialView",list);
        }

        [HttpPost]
        public IActionResult FiltrarProductos(int? valueType, int? valueMarca)
        {
            string hash;
            if (!(valueType == 0 && valueMarca == 0)) 
                hash = $"#valueType={valueType}&valueMarca={valueMarca}&index=1";
            else 
                hash = $"#index=1";
            return Json(new { hash });
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
