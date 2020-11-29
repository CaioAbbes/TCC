using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pagamento/Details/5
        public ActionResult Details(int IdPag)
        {
            var pagamento = new Pagamento();
            var objPagamento = new Pagamento();
            pagamento = pagamento.SelecionaComIdPag(IdPag);
            return View(pagamento);
        }

        public ActionResult List(Pagamento pagamento)
        {
            var pagamentoList = pagamento.SelecionaPagamento();
            return View(pagamentoList);
        }

        // GET: Pagamento/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 3 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Pagamento/Create
        [HttpPost]
        public ActionResult Create(int IdMesa, string CPFfunc, string FormPag, string CodCupom, float QtdPontos, string CPF)
        {

            if (ModelState.IsValid)
            {
                var objPagamento = new Pagamento();
                objPagamento.InsertPagamento(IdMesa, 0, CPFfunc, FormPag, null, 0, CPF);
                return RedirectToAction("List");
            }

            return View();
        }

        // GET: Pagamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pagamento/Edit/5
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

        // GET: Pagamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pagamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
