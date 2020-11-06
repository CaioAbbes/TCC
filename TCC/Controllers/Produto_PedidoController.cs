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
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: Produto_Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto_Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto_Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto_Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
