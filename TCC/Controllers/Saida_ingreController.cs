using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class Saida_ingreController : Controller
    {
        // GET: Saida_ingre
        public ActionResult Index()
        {
            return View();
        }

        // GET: Saida_ingre/Details/5
        public ActionResult Details(int IdSaidaIngre)
        {
            var saida = new Saida_ingre();
            var objSaida = new Saida_ingre();
            saida = objSaida.SelecionaIdSaida(IdSaidaIngre);
            return View(saida);
        }

        public ActionResult List(Saida_ingre saida)
        {
            var saidaList = saida.SelecionaSaida();
            return View(saidaList);
        }

        // GET: Saida_ingre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saida_ingre/Create
        [HttpPost]
        public ActionResult Create(string cPFfunc, string nome, int qtdUsada, DateTime dataHoraSaida)
        {
            if (ModelState.IsValid)
            {
                var objSaida = new Saida_ingre();
                objSaida.InsertSaidaIngre(cPFfunc, nome, qtdUsada, dataHoraSaida);
                return RedirectToAction("List");
            }

            return View();
        }

        // GET: Saida_ingre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Saida_ingre/Edit/5
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

        // GET: Saida_ingre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Saida_ingre/Delete/5
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
