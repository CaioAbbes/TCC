using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class MesaController : Controller
    {
        // GET: Mesa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mesa/Details/5
        public ActionResult Details(int IdMesa)
        {
            var mesa = new Mesa();
            var objMesa = new Mesa();
            mesa = objMesa.SelecionaIdMesa(IdMesa);
            return View(mesa);
        }

        public ActionResult List(Mesa mesa)
        {
            var mesaList = mesa.SelecionaMesa();

            var objMesa = new Mesa();
            objMesa.SelecionaMesa();
            return View(mesaList);
        }

        // GET: Mesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mesa/Create
        [HttpPost]
        public ActionResult Create(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                var objMesa = new Mesa();
                objMesa.InsertMesa(mesa);
                return RedirectToAction("List");
            }

            return View();
        }

        // GET: Mesa/Edit/5
        public ActionResult Edit(int IdMesa)
        {
            var mesa = new Mesa();
            var objMesa = new Mesa();
            mesa = objMesa.SelecionaIdMesa(IdMesa);
            return View(mesa);
        }

        // POST: Mesa/Edit/5
        [HttpPost]
        public ActionResult Edit(Mesa mesa)
        {
            var objMesa = new Mesa();
            objMesa.UpdateMesa(mesa);
            return RedirectToAction("List");
        }

       
    }
}
