using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class CupomUsaController : Controller
    {
        // GET: CliCupom
        public ActionResult Index()
        {
            return View();
        }

        // GET: CliCupom/Details/5
        public ActionResult Details(string CodCupom)
        {
            try
            {
                var Clicupom = new CupomUsa();
                var objClicupom = new CupomUsa();
                Clicupom = Clicupom.SelecionaComIdCupomUsa(CodCupom);
                return View(Clicupom);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o cupom usado');</script>";
                return View();
            }
        }

        [Autenticacao]
        public ActionResult List(CupomUsa cupomusa)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var clicupomList = cupomusa.SelecionaCupomUsa();
                return View(clicupomList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar o cupom usado');</script>";
                return View();
            }
        }
    
    }
}
