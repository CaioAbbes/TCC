using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class CartaoController : Controller
    {
        // GET: Cartao
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cartao/Details/5
        public ActionResult Details(decimal Numcartao)
        {
            var cartao = new Cartao();
            var objCartao = new Cartao();
            cartao = objCartao.SelecionaComNumCartao(Numcartao);
            return View(cartao);
        }

        public ActionResult List(Cartao cartao)
        {
            var cartaoList = cartao.SelecionaCartao();
            return View(cartaoList);
        }

        // GET: Cartao/Create
        public ActionResult Create(int idCli )
        {
            var cartao = new Cartao();
            var objCartao = new Cartao();
            cartao = objCartao.SelecionaComNumCartao(idCli);
            return View(cartao);
        }

        // POST: Cartao/Create
        [HttpPost]
        public ActionResult Create(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                var objCartao = new Cartao();
                objCartao.InsertCartao(cartao);
                return RedirectToAction("List");
            }

            return View();

        }

        // GET: Cartao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cartao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cartao/Delete/5
        public ActionResult Delete(decimal Numcartao)
        {
            var cartao = new Cartao();
            var objCartao = new Cartao();
            cartao = objCartao.SelecionaComNumCartao(Numcartao);
            return View(cartao);
        }

        // POST: Cartao/Delete/5
        [HttpPost]
        public ActionResult Delete(Cartao cartao)
        {
            var objCartao = new Cartao();
            objCartao.DeleteCartao(cartao);
            return RedirectToAction("List");
        }



    }
}
