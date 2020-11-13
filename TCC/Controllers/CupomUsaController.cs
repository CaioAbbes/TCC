using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var Clicupom = new CupomUsa();
            var objClicupom = new CupomUsa();
            Clicupom = Clicupom.SelecionaComIdCupomUsa(CodCupom);
            return View(Clicupom);
        }

        public ActionResult List(CupomUsa cupomusa)
        {
            var clicupomList = cupomusa.SelecionaCupomUsa();
            var objClicupom = new CupomUsa();
            objClicupom.SelecionaCupomUsa();
            return View(clicupomList);
        }
    
    }
}
