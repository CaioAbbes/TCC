﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (int.Parse(Session["NivelAcesso"].ToString()) != 1 && int.Parse(Session["NivelAcesso"].ToString()) != 2)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Produto_Pedido/Create
        [HttpPost]
        public ActionResult Create(Produto_pedido produtoPed)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente();
                var objProdPed = new Produto_pedido();
                int IdCli = int.Parse(Session["IdCli"].ToString());
                objProdPed.InsertProdPed(produtoPed, IdCli);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o produto pedido');</script>";
            return View();
        }

        public ActionResult UltimosPedidosCli(Cliente cliente)
        {
            var pedCli = cliente.UltimosPedidos(cliente);
            return View(pedCli);
        }


        //public ActionResult AdicionaCarrinho()
        //{
        //    return View();
        //}

        //  [HttpPost]
        public ActionResult AdicionaCarrinho(int prodId, float valor, string nome)
        {
            //var car = new List<Produto_pedido>();
            //car.Add(new Produto_pedido()
            //{
            //    IdProdPed = prodId,
            //    QtdProd = 1,
            //    NomeProd = nome,
            //    ValorUnitProd = valor,
            //});
            //car = Session["Carrinho"].ToString(); 
            var cart = new List<Produto>();
            if (Session["Carrinho"] != null)
            {
                cart = (List<Produto>)Session["Carrinho"];
            }


            cart.Add(new Produto()
            {
                IdProd = prodId,
                //qtd = 1,
                NomeProd = nome,
                ValorProd = valor,
            });
            //Session["Carrinho"] = cart;
            Session.Add("Carrinho", cart);
            //if(cart != null)
            //{
            //    foreach(var item in cart)
            //    {
            //        item.IdProdPed = prodId;
            //        item.ValorUnitProd = valor;
            //        item.NomeProd = nome;
            //    }
            //}
            TempData["msg"] = "<script>alert('Item adicionado ao carrinho');</script>";
            return RedirectToAction("List", "Produto");
            // return View(carrinho.ToList());
        }

        //public ActionResult AdicionaCarrinho(Produto_pedido ped)
        //{
        //    var temprod = ped.SelecionaProdPed();
        //    Produto_pedido carrinho = Session["Carrinho"] != null ? (Produto_pedido)Session["Carrinho"] : new Produto_pedido();

        //    if (temprod.Count > 0)
        //    {
        //        temprod.FirstOrDefault(x => x.IdProdPed == ped.IdProdPed).QtdProd += 1;
        //    }
        //    else
        //    {
        //        temprod.Add(carrinho);
        //    }
        //    return View();
        //}

        //public ActionResult Carrinho()
        //{
        //    Produto_pedido carrinho = Session["Carrinho"] != null ? (Produto_pedido)Session["Carrinho"] : new Produto_pedido();

        //    return View(carrinho);
        //}

    }
}
