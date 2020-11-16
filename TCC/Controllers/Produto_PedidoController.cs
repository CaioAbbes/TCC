using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class Produto_PedidoController : Controller
    {
        // GET: Produto_Pedido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto_Pedido/Details/5
        public ActionResult Details(int IdProdPed)
        {
            var produtoPed = new Produto_pedido ();
            var objProdutoPed = new Produto_pedido();
            produtoPed = objProdutoPed.SelecionaComIdProdPed(IdProdPed);
            return View(produtoPed);
        }

        public ActionResult List(Produto_pedido ProdPed)
        {
            var prodPedList = ProdPed.SelecionaProdPed();
            return View(prodPedList);
        }

        // GET: Produto_Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto_Pedido/Create
        [HttpPost]
        public ActionResult Create(Produto_pedido produtoPed)
        {
            if (ModelState.IsValid)
            {
                var objProdPed = new Produto_pedido();
                objProdPed.InsertProdPed(produtoPed);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}
