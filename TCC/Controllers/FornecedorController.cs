using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
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
        public ActionResult Details(int IdForn)
        {
            try
            {
                var fornecedor = new Fornecedor();
                var objFornecedor = new Fornecedor();
                fornecedor = objFornecedor.SelecionaComIdForn(IdForn);
                return View(fornecedor);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o fornecedor');</script>";
                return View();
            }
        }


        [Autenticacao]
        public ActionResult List(Fornecedor fornecedor)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var fornecedorList = fornecedor.SelecionaFornecedor();
                return View(fornecedorList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os fornecedores');</script>";
                return View();
            }
        }


        // GET: Fornecedor/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
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
            TempData["msg"] = "<script>alert('Erro ao criar o fornecedor');</script>";
            return View();
        }

        // GET: Fornecedor/Edit/5
        [Autenticacao]
        public ActionResult Edit(int IdForn)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var fornecedor = new Fornecedor();
            var objFornecedor = new Fornecedor();
            fornecedor = objFornecedor.SelecionaComIdForn(IdForn);

            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            try
            {
                var objFornecedor = new Fornecedor();
                objFornecedor.UpdateFornecedor(fornecedor);
                return RedirectToAction("List");
            }
            catch
            {
                Response.Write("<script>alert('Erro ao editar o fornecedor')</script>");
                return View();
            }

        }

        
    }
}
