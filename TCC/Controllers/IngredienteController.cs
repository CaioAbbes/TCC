using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class IngredienteController : Controller
    {
        // GET: Ingrediente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ingrediente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Autenticacao]
        public ActionResult List(Ingrediente ingrediente)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 4 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }

            var listIngre = ingrediente.SelecionaIngrediente();
            return View(listIngre);
        }


        // GET: Ingrediente/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 4 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Ingrediente/Create
        [HttpPost]
        public ActionResult Create(Ingrediente ingrediente)
        {


            if (ModelState.IsValid)
            {
                var objIngrediente = new Ingrediente();
                objIngrediente.InsertIngrediente(ingrediente);
                return RedirectToAction("List");
            }

            return View();

        }

        // GET: Ingrediente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingrediente/Edit/5
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

        // GET: Ingrediente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingrediente/Delete/5
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
