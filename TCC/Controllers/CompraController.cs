using System;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        // GET: Compra/Details/5
        public ActionResult Details(int NumCompra)
        {
            try
            {
                var compra = new Compra();
                var objCompra = new Compra();
                compra = objCompra.SelecionaNumCompra(NumCompra);
                return View(compra);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar a compra');</script>";
                return View();
            }
        }

        public ActionResult List(Compra compra)
        {
            try
            {
                var compraList = compra.SelecionaCompra();
                return View(compraList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar a compra');</script>";
                return View();
            }
        }


        // GET: Compra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult Create(string CodigoBarras, string NomeForn, int QtdEntraIngre, DateTime DataHoraChegada)
        {
            if (ModelState.IsValid)
            {
                var objCompra = new Compra();
                objCompra.InsertCompra(CodigoBarras, NomeForn, QtdEntraIngre, DataHoraChegada);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar a compra');</script>";
            return View();
        }
    }
}
