using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
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
            try
            {
                var produto = new Produto();
                var objProduto = new Produto();
                produto = objProduto.SelecionaIdProd(IdProd);
                return View(produto);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o produto');</script>";
                return View();
            }
        }


        public ActionResult List(Produto produto,string busca)
        {
            try
            {
                var prodBusca = produto.BuscaProduto(busca);
                if(prodBusca.Count == 0) 
                { 
                    TempData["msgSemDado"] = "<script>alert('Nenhum produto encontrado');</script>"; 
                    return View(prodBusca);
                };
                return View(prodBusca);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os produtos');</script>";
                return View();
            }
        }

        // GET: Produto/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }




        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {

            if (ModelState.IsValid)
            {
                var objProduto = new Produto();
                string filename = Path.GetFileNameWithoutExtension(produto.ImageUpload.FileName);
                string extesion = Path.GetExtension(produto.ImageUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extesion;
                produto.Imagem = "~/Imagens/" + filename;
                filename = Path.Combine(Server.MapPath("~/Imagens/"), filename);
                produto.ImageUpload.SaveAs(filename);
                objProduto.InsertProduto(produto);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o produto');</script>";
            return View();
        }

        // GET: Produto/Edit/5
        [Autenticacao]
        public ActionResult Edit(int IdProd)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var produto = new Produto();
            var objProduto = new Produto();
            produto = objProduto.SelecionaIdProd(IdProd);
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                var objProduto = new Produto();
                objProduto.UpdateProduto(produto);
                return RedirectToAction("List");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao editar o produto');</script>";
                return View();
            }
        
        }
    }
}
