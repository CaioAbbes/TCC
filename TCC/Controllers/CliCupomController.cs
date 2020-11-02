using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class CliCupomController : Controller
    {
        // GET: CliCupom
        public ActionResult Index()
        {
            return View();
        }

        // GET: CliCupom/Details/5
        public ActionResult Details(string CodCupom)
        {
            var Clicupom = new Clicupom();
            var objClicupom = new Clicupom();
            Clicupom = Clicupom.SelecionaComIdClicupom(CodCupom);
            return View(Clicupom);
        }

        public ActionResult List(Clicupom clicupom)
        {
            var clicupomList = clicupom.SelecionaClicupom();

            var objClicupom = new Clicupom();
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
        public ActionResult Edit(Clicupom clicupom)
        {
            var objClicupom = new Clicupom();
            objClicupom.UpdateClicupom(clicupom);
            return RedirectToAction("List");
        }     
    }
}
