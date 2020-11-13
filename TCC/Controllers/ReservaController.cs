using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int IdReserva)
        {
            var Reserva = new Reserva();
            var objReserva = new Reserva();
            Reserva = objReserva.SelecionaIdReserva(IdReserva);
            return View(Reserva);
        }

        public ActionResult List(Reserva reserva)
        {
            var reservaList = reserva.SelecionaReserva();

            var objReserva = new Reserva();
            objReserva.SelecionaReserva();

            return View(reservaList);
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                var objReserva = new Reserva();
                objReserva.InsertReserva(reserva);
                return RedirectToAction("List");
            }

            return View();
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reserva/Edit/5
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

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reserva/Delete/5
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
