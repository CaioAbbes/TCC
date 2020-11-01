using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            var fornecedor = new Fornecedor();
            var objFornecedor = new Fornecedor();
            fornecedor = objFornecedor.RetornaIdFornecedor(id);
            return View(fornecedor);
        }

        public ActionResult List(Fornecedor fornecedor)
        {
            var fornecedorList = fornecedor.SelecionaFornecedor();
            var objFornecedor = new Fornecedor();
            objFornecedor.SelecionaFornecedor();

            return View(fornecedorList);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        public ActionResult Create(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var objFornecedor = new Fornecedor();
                objFornecedor.InsertFornecedor(fornecedor);
                return RedirectToAction("List");
            }
            return View();
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int id)
        {
            var fornecedor = new Fornecedor();
            var objFornecedor = new Fornecedor();
            fornecedor = objFornecedor.RetornaIdFornecedor(id);

            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            var objFornecedor = new Fornecedor();
            objFornecedor.UpdateFornecedor(fornecedor);
            return RedirectToAction("List");
        }

        
    }
}
