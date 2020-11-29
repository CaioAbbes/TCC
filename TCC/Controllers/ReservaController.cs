using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
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
            return View(reservaList);
        }

        // GET: Reserva/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 1)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
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
       
    }
}
