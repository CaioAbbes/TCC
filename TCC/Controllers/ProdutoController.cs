using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto/Details/5
        public ActionResult Details(int IdProd)
        {
            var produto = new Produto();
            var objProduto = new Produto();
            produto = objProduto.SelecionaIdProd(IdProd);
            return View(produto);
        }


        public ActionResult List(Produto produto)
        {
            var produtoList = produto.SelecionaProduto();

            var objProduto = new Produto();
            objProduto.SelecionaProduto();

            return View(produtoList);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }




        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var objProduto = new Produto();
                objProduto.InsertProduto(produto);
                return RedirectToAction("List");
            }

            return View();
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int IdProd)
        {
            var produto = new Produto();
            var objProduto = new Produto();
            produto = objProduto.SelecionaIdProd(IdProd);
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            var objProduto = new Produto();
            objProduto.UpdateProduto(produto);
            return RedirectToAction("List");
        
        }
    }
}
