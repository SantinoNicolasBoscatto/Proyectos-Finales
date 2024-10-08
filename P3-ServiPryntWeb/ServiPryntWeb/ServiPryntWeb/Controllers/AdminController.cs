using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiPryntWeb.Models._Negocio;
using ServiPryntWeb.Models.Entidades;
using ServiPryntWeb.Models.Repositorio.Abstractas;
using ServiPryntWeb.Models.Validator;
using System;

namespace ServiPryntWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IMarcaService _marcaService;
        private readonly ITypeProductService _typeService;

        public AdminController(IUserService userService, IProductService productService, IMarcaService marcaService, ITypeProductService typeService)
        {
            _userService = userService;
            _productService = productService;
            _marcaService = marcaService;
            _typeService = typeService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Logueado") != null) return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario user)
        {
            if (!ModelState.IsValid) return View("Login", user);
            var result = await _userService.VerificarUsuario(user.Nombre!, user.Password!);
            HttpContext.Session.SetString("Logueado", result.bolean.ToString());
            if (!(bool)result.bolean) return View("Login", user);
            HttpContext.Session.SetString("UserId", result.id.ToString());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            return View();
        }


        public IActionResult DgvProductos(int index, int? valueType, int? valueStock, int? valueOferta)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            ViewBag.valueType = valueType;
            ViewBag.valueStock = valueStock;
            ViewBag.valueOferta = valueOferta;
            ViewBag.Type = _typeService.ListTypes();
            return View();
        }
        public PartialViewResult DgvProductosPartial(int? valueType, int? valueStock, int? valueOferta, int index)
        {
            var model = valueType.HasValue || valueStock.HasValue || valueOferta.HasValue
           ? _productService.ListProducts(pageSize: 6, paging: true, currentPage: index, tuple: (valueType ?? 0, valueStock ?? 0, valueOferta ?? 0))
           : _productService.ListProducts(pageSize: 6, paging: true, currentPage: index);
            ViewBag.valueType = valueType;
            ViewBag.valueStock = valueStock;
            ViewBag.valueOferta = valueOferta;
            ViewBag.Type = _typeService.ListTypes();
            return PartialView("_DgvPartial", model);
        }
        [HttpPost]
        public IActionResult Filtrar(int? valueType, int? valueStock, int? valueOferta)
        {
            string hash;
            if (!(valueType == 0 && valueOferta == 0 && valueStock == 0)) hash = $"#valueType={valueType}&valueStock={valueStock}&valueOferta={valueOferta}&index=1";
            else hash = $"#index=1";
            return Json(new { hash });
        }


        public IActionResult Editar(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            ViewBag.Marca = _marcaService.ListMarcas(paging: false);
            ViewBag.Type = _typeService.ListTypes();
            if (id == 0) return View(new Productos());
            else return View(_productService.GetProduct(id));
        }
        [HttpPost]
        public IActionResult Editar([FromForm] Productos productos)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            bool result;
            if (productos.IdProducto == 0) result = _productService.AddProduct(productos);
            else result = _productService.UpdateProduct(productos);
            if (result) return Redirect($"/Admin/DgvProductos#index=1");
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            bool result = _productService.DeleteProduct(id);
            string redirectUrl;
            if (result) redirectUrl = Url.Action("DgvProductos", "Admin", new { index = 1 })!;
            else redirectUrl = Url.Action("Error", "Admin")!;
            return Json(new { url = redirectUrl });
        }


        public IActionResult DgvMarcas(int index)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            return View();
        }
        public PartialViewResult DgvMarcasPartial(int index)
        {
            var model = _marcaService.ListMarcas(pageSize: 6, paging: true, currentPage: index);
            return PartialView("_DgvMarcasPartial", model);
        }

        public IActionResult EditarMarca(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            if (id == 0) return View(new Marcas());
            else return View(_marcaService.GetMarca(id));
        }
        [HttpPost]
        public IActionResult EditarMarca([FromForm] Marcas marca)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            bool result;
            if (marca.IdMarca == 0) result = _marcaService.AddMarca(marca);
            else result = _marcaService.UpdateMarca(marca);
            if (result) return Redirect($"/Admin/DgvMarcas#index=1");
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EliminarMarca(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            bool result = _marcaService.DeleteMarca(id);
            string redirectUrl = "";
            if (!result) redirectUrl = Url.Action("Error", "Admin")!;
            return Json(new { url = redirectUrl });
        }

        public IActionResult DgvTypes(int index)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            return View();
        }
        public PartialViewResult DgvTypesPartial(int index)
        {
            var model = _typeService.ListTypes(pageSize: 6, paging: true, currentPage: index);
            return PartialView("_DgvTypesPartial", model);
        }

        public IActionResult EditarType(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            if (id == 0) return View(new TypeProduct());
            else return View(_typeService.GetTypeProduct(id));
        }
        [HttpPost]
        public IActionResult EditarType([FromForm] TypeProduct type)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            bool result;
            if (type.TypeId == 0) result = _typeService.AddType(type);
            else result = _typeService.UpdateType(type);
            if (result) return Redirect($"/Admin/DgvTypes#index=1");
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EliminarType(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            bool result = _typeService.DeleteType(id);
            string redirectUrl = "";
            if (!result) redirectUrl = Url.Action("Error", "Admin")!;
            return Json(new { url = redirectUrl });
        }


        public IActionResult Error()
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            if (HttpContext.Session.GetString("Logueado") == null ||
            !LoginValidator.ValLog(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            return View();
        }
    }
}
