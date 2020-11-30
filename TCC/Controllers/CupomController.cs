using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class CupomController : Controller
    {
        // GET: Cupom
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cupom/Details/5
        public ActionResult Details(string CodCupom)
        {
            try
            {
                var cupom = new Cupom();
                var objCupom = new Cupom();
                cupom = objCupom.SelecionaComIdCupom(CodCupom);
                return View(cupom);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o cupom');</script>";
                return View();
            }
        }

        [Autenticacao]
        public ActionResult List(Cupom cupom)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var cupomList = cupom.SelecionaCupom();
                return View(cupomList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar o cupom');</script>";
                return View();
            }
        }

        [Autenticacao]
        // GET: Cupom/Create
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Cupom/Create
        [HttpPost]
        public ActionResult Create(Cupom cupom)
        {
            if (ModelState.IsValid)
            {
                var objCupom = new Cupom();
                objCupom.InsertCupom(cupom);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o cupom');</script>";
            return View();
        }

        [Autenticacao]
        public ActionResult Edit(string CodCupom)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var cupom = new Cupom();
            var objCupom = new Cupom();
            cupom = objCupom.SelecionaComIdCupom(CodCupom);
            return View(cupom);
        }

        [HttpPost]
        public ActionResult Edit(Cupom cupom)
        {
            try
            {
                var objCupom = new Cupom();
                objCupom.UpdateCupom(cupom);
                return RedirectToAction("List");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao editar o clientes');</script>";
                return View();
            }
        }



        }
}
