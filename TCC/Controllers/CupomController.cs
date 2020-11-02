using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult List(Cupom cupom)
        {
            var cupomList = cupom.SelecionaCupom();
            var objCupom = new Cupom();
            objCupom.SelecionaCupom();
            return View(cupomList);
        }

        // GET: Cupom/Create
        public ActionResult Create()
        {
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

        // GET: Cupom/Edit/5


    
    }
}
