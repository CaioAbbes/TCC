﻿using System.Collections.Generic;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class Produto_PedidoController : Controller
    {
        // GET: Produto_Pedido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto_Pedido/Details/5
        public ActionResult Details(int IdProdPed)
        {
            try
            {
                var produtoPed = new Produto_pedido();
                var objProdutoPed = new Produto_pedido();
                produtoPed = objProdutoPed.SelecionaComIdProdPed(IdProdPed);
                return View(produtoPed);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o produto pedido');</script>";
                return View();
            }
        }

        public ActionResult List(Produto_pedido ProdPed)
        {
            try
            {
                var prodPedList = ProdPed.SelecionaProdPed();
                return View(prodPedList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os produtos pedidos');</script>";
                return View();
            }
        }

        // GET: Produto_Pedido/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 1 && int.Parse(Session["NivelAcesso"].ToString()) != 2 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Produto_Pedido/Create
        [HttpPost]
        public ActionResult Create(string nomeProd, string decPedido)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente();
                var objProdPed = new Produto_pedido();
                int IdCli = int.Parse(Session["IdCli"].ToString());
                objProdPed.InsertProdPed(nomeProd, decPedido, IdCli);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o produto pedido');</script>";
            return View();
        }

        [HttpPost]
        public ActionResult FazCompra()
        {
            var ListaProds = (List<Produto>)Session["Carrinho"];
            foreach (var item in ListaProds)
            {
                Produto produto = new Produto();
                produto.NomeProd = item.NomeProd;
                produto.Qtd = item.Qtd;
                produto.DescProd = item.DescProd;
                var objProdPed = new Produto_pedido();
                int IdCli = int.Parse(Session["IdCli"].ToString());
                objProdPed.InsertProdPedCart(produto, IdCli);
            }

            return RedirectToAction("Create", "Pagamento");
        }



        [Autenticacao]
        public ActionResult UltimosPedidosCli(Cliente cliente)
        {
            var pedCli = cliente.UltimosPedidos(cliente);
            return View(pedCli);
        }


        public ActionResult AdicionaCarrinho(int prodId, float valor, string nome, string imagem)
        {
            var cart = new List<Produto>();
            if (Session["Carrinho"] != null)
            {
                cart = (List<Produto>)Session["Carrinho"];
            }


            cart.Add(new Produto()
            {
                IdProd = prodId,
                NomeProd = nome,
                ValorProd = valor,
                Imagem = imagem
            });
            Session.Add("Carrinho", cart);
            return RedirectToAction("List", "Produto");
        }

        public ActionResult RemoveCarrinho(int id)
        {
            List<Produto> cart = (List<Produto>)Session["Carrinho"];
            cart.RemoveAt(isExist(id));
            Session.Add("Carrinho", cart);
            return RedirectToAction("List", "Produto");
        }

        public ActionResult RemoveTodosCarrinho()
        {
            List<Produto> cart = (List<Produto>)Session["Carrinho"];
            cart.Clear();
            Session.Add("Carrinho", cart);
            return RedirectToAction("List", "Produto");
        }

        private int isExist(int id)
        {
            List<Produto> cart = (List<Produto>)Session["Carrinho"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].IdProd.Equals(id))
                    return i;
            return -1;
        }



    }
}
