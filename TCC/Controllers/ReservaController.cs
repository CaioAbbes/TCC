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

            var objReserva = new Reserva();
            int[] NumLugar = new int[] { 1, 2, 3, 4, 5 }; //5, pois é o maximo de cadeiras que uma mesa pode ter
            SelectList Lista = new SelectList(NumLugar);
            ViewBag.Lista = Lista;

            string[] TipoLugar = new string[] {"Coberto", "Arejado" }; //5, pois é o maximo de cadeiras que uma mesa pode ter
            SelectList ListaTipoLugar = new SelectList(TipoLugar);
            ViewBag.ListaTipoLugar = ListaTipoLugar;

            return View(objReserva);
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
                return RedirectToAction("MostraReservaCli");
            }
            TempData["msg"] = "<script>alert('Erro ao criar uma reservas');</script>";
            return View();
        }

        [Autenticacao]
        public ActionResult MostraReservaCli(Reserva reserva)
        {
            int IdCli = int.Parse(Session["IdCli"].ToString());
            var reservaList = reserva.MostraReservaCli(IdCli);
            return View(reservaList);
        }


    }
}
