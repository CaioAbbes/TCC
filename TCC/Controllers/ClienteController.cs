﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using TCC.Models;
using TCC.Autorizacoes;
using System.Configuration;

namespace TCC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {

            if (Session["usuarioLogadoID"] == null)
            {
                Session["nomeUsuarioLogado"] = "visitante";
            }

            return View();
        }

        [Autenticacao]
        public ActionResult List(Cliente cliente)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var clienteList = cliente.SelecionaCliente();
            return View(clienteList);
        }



        // GET: Cliente/Details/5
        public ActionResult Details(int IdCli)
        {
            var cliente = new Cliente();
            var objCliente = new Cliente();
            cliente = objCliente.SelecionaComIdCli(IdCli);
            return View(cliente);
        }

        // GET: Cliente/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 1)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }

            return View();
        }


        // POST: Cliente/Create
        [HttpPost]
        //[AuthCliente]
        public ActionResult Create(Cliente cliente)
        {

            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            //if (cliente.ImageUpload == null || cliente.ImageUpload.ContentLength == 0)
            //{
            //    ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
            //}
            //else if (!imageTypes.Contains(cliente.ImageUpload.ContentType))
            //{
            //    ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
            //}

            //if (cliente.Imagecli != null && cliente.Imagecli.ContentLength > 0)
            //{
            //    string caminho = Path.Combine(Server.MapPath("~/Imagens/"), cliente.Imagecli.FileName);
            //    cliente.Imagecli.SaveAs(caminho);
            //    cliente.Imagem = cliente.Imagecli.FileName;
            //}
            //if (cliente.Imagecli != null && cliente.Imagecli.ContentLength > 0)
            //{
            //    using (var binaryReader = new BinaryReader(cliente.Imagecli.InputStream))
            //    {
            //        cliente.ConteudoFoto = binaryReader.ReadBytes(cliente.Imagecli.ContentLength);
            //    }
            //}
            if (ModelState.IsValid)
            {


                var objCli = new Cliente();
                //using (var binaryReader = new BinaryReader(cliente.ImageUpload.InputStream))
                //    cliente.Imagem = binaryReader.ReadBytes(cliente.ImageUpload.ContentLength);

                objCli.InsertCliente(cliente);
                return RedirectToAction("List");
            }
            return View();

        }


        // GET: Cliente/Edit/5
        [Autenticacao]
        public ActionResult Edit(int IdCli)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 1 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }

            var cliente = new Cliente();
            var objCliente = new Cliente();
            cliente = objCliente.SelecionaComIdCli(IdCli);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            var objCli = new Cliente();
            objCli.UpdateCliente(cliente);
            return RedirectToAction("List");
        }




        //public ActionResult BuscaCEP(Endereco endereco)
        //{

        //    if (endereco.CEP != null)
        //    {

        //        var endList = endereco.BuscaCEP(endereco.CEP);

        //        var end = endList.Select(t => new { t.CEP, t.Logra, t.Bairro, t.Cidade, t.UF }).Where(p => p.CEP == endereco.CEP);
        //        foreach (var item in endList)
        //        {
        //            ViewBag.Cep = item.CEP;
        //            ViewBag.Logra = item.Logra;
        //            ViewBag.Bairro = item.Bairro;
        //            ViewBag.Cidade = item.Cidade;
        //            ViewBag.UF = item.UF;
        //        }



        //        return Json(endList, JsonRequestBehavior.AllowGet);

        //    }
        //    else
        //    {
        //        return View();
        //    }

        //    Endereco end = new Endereco()
        //    {
        //        CEP = cliente.Endereco.CEP,
        //        Logra = cliente.Endereco.Logra,
        //        Bairro = cliente.Endereco.Bairro,
        //        Cidade = cliente.Endereco.Cidade,
        //        UF = cliente.Endereco.UF

        //    };
        //    var endList = end.BuscaCEP(end.CEP);
        //    var end = Endereco.BuscaCEP(endereco.CEP).Select(t => new { t.CEP, t.Logra, t.Bairro, t.Cidade, t.UF }).Where(p => p.CEP == cliente.Endereco.CEP);
        //    return Json(end, JsonRequestBehavior.AllowGet);

        //    return Json(endList.ForEach, JsonRequestBehavior.AllowGet);
        //    return Json(endList.All(a => a.CEP == endereco.CEP), JsonRequestBehavior.AllowGet);


        //    foreach (var item in endList)
        //    {
        //        item.CEP = endereco.CEP;
        //        item.Cidade = endereco.Cidade;
        //        item.Logra = endereco.Logra;
        //        item.Bairro = endereco.Bairro;
        //        item.UF = endereco.UF;
        //    }
        //    var endList = end.BuscaCEP(endereco.CEP);

        //    if (end.CEP != 0)
        //    {
        //        CepExists = true;
        //    }

        //    else
        //    {
        //        CepExists = false;
        //    }

        //    return View(end);

        //    return Json(end, JsonRequestBehavior.AllowGet);

        //}


        //var img = cliente.Imagem.Split(',')[1];
        //var img = cliente.Imagem.ToString().Split(',')[1];

        //HttpFileCollectionBase hfc = Request.Files;
        //for (int i = 0; i < hfc.Count; i++)
        //{
        //    HttpPostedFileBase hpf = hfc[i];
        //    if (hpf.ContentLength > 0)
        //    {
        //        //Pega o nome do arquivo
        //        string nome = System.IO.Path.GetFileName(hpf.FileName);
        //        //Pega a extensão do arquivo
        //        string extensao = Path.GetExtension(hpf.FileName);
        //        //Gera nome novo do Arquivo numericamente
        //        string filename = string.Format("{0:00000000000000}", GerarID());
        //        //Caminho a onde será salvo
        //        hpf.SaveAs(Server.MapPath("~/Imagens/") + filename + i
        //        + extensao);

        //        //pega o arquivo já carregado
        //        string pth = Server.MapPath("~/Imagens/")
        //        + filename + i + extensao;

        //string imgName = Path.GetFileName(cliente.Imagem);
        //string imgTxt = Path.GetExtension(imgName);
        //if (imgTxt == ".jpg" || imgTxt == ".png" || imgTxt == ".jpeg")
        //{
        //    string imgPath = Path.Combine(Server.MapPath("Imagens"), imgName);
        //    cliente.Imagecli.SaveAs(imgPath);
        //}

        //var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
        //var fileName = Path.GetFileName(cliente.Imagem);
        //var ext = Path.GetExtension(cliente.Imagem);
        //if (allowedExtensions.Contains(ext))
        //{
        //    string name = Path.GetFileNameWithoutExtension(fileName);
        //    var path = Path.Combine(Server.MapPath("~/Imagens"), cliente.Imagem);


    }
}