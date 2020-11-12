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
            Clicupom = Clicupom.SelecionaComIdClicupom(CodCupom);
            return View(Clicupom);
        }

        public ActionResult List(CupomUsa cupomusa)
        {
            var clicupomList = cupomusa.SelecionaClicupom();

            var objClicupom = new CupomUsa();
            objClicupom.SelecionaClicupom();
            return View(clicupomList);
        }


        // GET: CliCupom/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CliCupom/Edit/5
        [HttpPost]
        public ActionResult Edit(CupomUsa cupomusa)
        {
            var objClicupom = new CupomUsa();
            objClicupom.UpdateClicupom(cupomusa);
            return RedirectToAction("List");
        }     
    }
}
