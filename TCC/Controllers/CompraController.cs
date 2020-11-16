using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var compra = new Compra();
            var objCompra = new Compra();
            compra = objCompra.SelecionaNumCompra(NumCompra);
            return View(compra);
        }

        public ActionResult List(Compra compra)
        {
            var compraList = compra.SelecionaCompra();
            return View(compraList);
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
            return View();
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compra/Edit/5
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

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compra/Delete/5
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
