using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ServiManagement.Models;
using ServiManagement.Models.DTO;
using ServiManagement.Models.Entidades;
using ServiManagement.Models.Repositorio.Abstracto;
using ServiManagement.Models.Validator;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace ServiManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _usuario;
        private readonly IOrdenesService _ordenes;

        public HomeController(ILogger<HomeController> logger, IUserService usuario, IOrdenesService ordenes)
        {
            _logger = logger;
            _usuario = usuario;
            _ordenes = ordenes;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Logueado") != null &&
            ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            var result = await _usuario.Login(usuario.Name, usuario.Pass);
            if (!result.bolean) return View("Login", usuario);
            HttpContext.Session.SetString("Logueado", result.bolean.ToString());
            HttpContext.Session.SetString("EsAdmin", result.admin.ToString());
            HttpContext.Session.SetString("Id", result.id.ToString());
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> PanelDeControl()
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            if (HttpContext.Session.GetString("EsAdmin") == null ||
            !Boolean.Parse(HttpContext.Session.GetString("EsAdmin"))) return RedirectToAction("Index");
            var list = await _ordenes.ListaOrdenes(new DateTime(1, 1, 1), new DateTime(9999, 12, 31));
            return View(list);
        }
        public async Task<PartialViewResult> PanelDeControlPartial()
        {
            var list = await _ordenes.ListaOrdenes(new DateTime(1, 1, 1), new DateTime(9999, 12, 31));
            return PartialView("_PanelDeControlPartial", list);
        }
        [HttpPost]
        public async Task<PartialViewResult> PanelDeControlPartial(string desde, string hasta, int tecnico)
        {
            DateTime desdeConvertido;
            DateTime hastaConvertido;
            List<OrdenesDTO> list;

            if (DateTime.TryParseExact(desde, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out desdeConvertido) && DateTime.TryParseExact(hasta, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out hastaConvertido))
            {
                list = await _ordenes.ListaOrdenes(desdeConvertido, hastaConvertido, tecnico);
                return PartialView("_PanelDeControlPartial", list);
            }
            list = await _ordenes.ListaOrdenes(new DateTime(1, 1, 1), new DateTime(9999, 12, 31), tecnico);
            return PartialView("_PanelDeControlPartial", list);
        }




        public async Task<IActionResult> Orden(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            ViewBag.listaString = await _ordenes.ListaModelos();
            ViewBag.listaMarca = await _ordenes.ListaMarcas();
            if (id == 0) return View();
            var orden = await _ordenes.ObtenerPorId(id);
            return View(orden);
        }
        [HttpPost]
        public async Task<IActionResult> Orden(Orden orden)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");
            ViewBag.listaString = await _ordenes.ListaModelos();
            ViewBag.listaMarca = await _ordenes.ListaMarcas();

            if (!ModelState.IsValid)
            {          
                return View(orden);
            }
            orden.Tecnico = int.Parse(HttpContext.Session.GetString("Id"));
            if (orden.Id == 0)
            {
                var r =   await _ordenes.AgregarOrden(orden);
                if(r) return RedirectToAction("Index");
                ModelState.AddModelError("NumeroDeOrden", "Este Numero de Orden ya existe");
                return View(orden);
            }
            else
            {
                await _ordenes.ModificarOrden(orden);
                return RedirectToAction("PanelDeControl");
            }
            
        }
        public IActionResult Modificar(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return RedirectToAction("Login");

            var url = Url.Action("Orden", "Home", new { id = id });
            return Json(new { redirect = url });
        }
        public IActionResult ModificarAdmin(int id)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return Json(new { redirect = Url.Action("Login", "Home") });
            if (HttpContext.Session.GetString("EsAdmin") == null ||
            !Boolean.Parse(HttpContext.Session.GetString("EsAdmin"))) return Json(new { redirect = Url.Action("Index", "Home") });
            var url = Url.Action("Orden", "Home", new { id = id });
            return Json(new { redirect = url });
        }


        public IActionResult BuscarOrden()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuscarOrden(string ord)
        {
            var orden = await _ordenes.ObtenerPorNumeroOrden(ord);
            if(orden == null) return View();
            ViewBag.Name = await _ordenes.ObtenerTecnico(orden.Tecnico);
            return View(orden);
        }


        [HttpGet]
        public IActionResult PreDetalleTecnico(string desde, string hasta, int tecnico)
        {
            if (HttpContext.Session.GetString("Logueado") == null ||
            !ValLogin.Val(Boolean.Parse(HttpContext.Session.GetString("Logueado")!))) return Json(new { redirect = Url.Action("Login", "Home") });
            if (HttpContext.Session.GetString("EsAdmin") == null ||
            !Boolean.Parse(HttpContext.Session.GetString("EsAdmin"))) return Json(new { redirect = Url.Action("Index", "Home") });
            desde = desde != null ? desde : "0001-01-01";
            hasta = hasta != null ? hasta : "9999-01-01";
            var url = Url.Action("DetalleTecnico", "Home", new { tecnico = tecnico, desde = desde, hasta = hasta });
            return Json(new { redirect = url });
        }
        [HttpGet]
        public IActionResult DetalleTecnico()
        {
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> DetalleTecnicoPartialView(string desde, string hasta, int tecnico, int index)
        {
            DateTime desdeConvertido;
            DateTime hastaConvertido;
            ListOrdenes list;

            if (DateTime.TryParseExact(desde, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out desdeConvertido) && DateTime.TryParseExact(hasta, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out hastaConvertido))
            {
                list = await _ordenes.ListaFiltrada(desdeConvertido, hastaConvertido, tecnico, 8, index);
                return PartialView("_DetalleTecnicoPartialView", list);
            }

            return PartialView("_DetalleTecnicoPartialView");
        }

        [HttpGet]
        public async Task<IActionResult> MisRegistros()
        {
            if (HttpContext.Session.GetString("EsAdmin") == null ||
            Boolean.Parse(HttpContext.Session.GetString("EsAdmin"))) return RedirectToAction("Index");
            var list = await _ordenes.ListaFiltrada(DateTime.Now.Date, DateTime.Now.Date.AddDays(1), int.Parse(HttpContext.Session.GetString("Id")), 15);
            return View(list);
        }
    }
}
