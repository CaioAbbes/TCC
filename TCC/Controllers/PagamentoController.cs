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
            try
            {
                var pagamento = new Pagamento();
                var objPagamento = new Pagamento();
                pagamento = pagamento.SelecionaComIdPag(IdPag);
                return View(pagamento);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o pagamento');</script>";
                return View();
            }
        }

        public ActionResult List(Pagamento pagamento)
        {
            try
            {
                var pagamentoList = pagamento.SelecionaPagamento();
                return View(pagamentoList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os pagamentos');</script>";
                return View();
            }
        }

        // GET: Pagamento/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 1 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Pagamento/Create
        [HttpPost]
        public ActionResult Create(string FormPag, string CodCupom, float QtdPontos, string CPF)
        {

            if (ModelState.IsValid)
            {
                var objPagamento = new Pagamento();
                int IdCli = int.Parse(Session["IdCli"].ToString());
                objPagamento.InsertPagamento( IdCli, FormPag, CodCupom, QtdPontos, CPF); //a qtdPontos é 0 pois tem uma trigger que atua nela
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o pagamento');</script>";
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
