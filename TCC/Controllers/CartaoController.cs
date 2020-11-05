using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class CartaoController : Controller
    {
        // GET: Cartao
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cartao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cartao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cartao/Create
        [HttpPost]
        public ActionResult Create(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                var objCartao = new Cartao();
                objCartao.InsertCartao(cartao);
                return RedirectToAction("Index");
            }

            return View();

        }

        // GET: Cartao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cartao/Edit/5
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

        // GET: Cartao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cartao/Delete/5
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
