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
            var cupom = new Cupom();
            var objCupom = new Cupom();
            cupom = objCupom.SelecionaComIdCupom(CodCupom);
            return View(cupom);
        }

        [Autenticacao]
        public ActionResult List(Cupom cupom)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var cupomList = cupom.SelecionaCupom();
            return View(cupomList);
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
            var objCupom = new Cupom();
            objCupom.UpdateCupom(cupom);
            return RedirectToAction("List");
        }



        }
}
