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
            try
            {
                var Reserva = new Reserva();
                var objReserva = new Reserva();
                Reserva = objReserva.SelecionaIdReserva(IdReserva);
                return View(Reserva);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar a reserva');</script>";
                return View();
            }
        }

        public ActionResult List(Reserva reserva)
        {
            try
            {
                var reservaList = reserva.SelecionaReserva();
                return View(reservaList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar as reservas');</script>";
                return View();
            }

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
                int IdCli = int.Parse(Session["IdCli"].ToString());
                objReserva.InsertReserva(reserva, IdCli);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar uma reservas');</script>";
            return View();
        }
       
    }
}
