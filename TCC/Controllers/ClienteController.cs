using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using TCC.Models;

namespace TCC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(Cliente cliente)
        {
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                var objCli = new Cliente();
                objCli.InsertCliente(cliente);
                return RedirectToAction("List");

            }

            return View();

        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int IdCli)
        {
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

        public ActionResult BuscaCEP(Endereco endereco)
        {

            var endList = Endereco.BuscaCEP(endereco.CEP);
            //var end = endList.Select(t => new { t.CEP, t.Logra, t.Bairro, t.Cidade, t.UF}).Where(p => p.CEP == endereco.CEP);
            ViewBag.End = endList;



            //var end = Endereco.BuscaCEP(endereco.CEP).Select(t => new { t.CEP, t.Logra, t.Bairro, t.Cidade, t.UF}).Where(p => p.CEP == cliente.Endereco.CEP);
            //return Json(end, JsonRequestBehavior.AllowGet);

            return Json(endList, JsonRequestBehavior.AllowGet);

            //Endereco end = new Endereco()
            //{
            //    CEP = cliente.Endereco.CEP,
            //    Logra = cliente.Endereco.Logra,
            //    Bairro = cliente.Endereco.Bairro,
            //    Cidade = cliente.Endereco.Cidade,
            //    UF = cliente.Endereco.UF

            //};
            //var endList = end.BuscaCEP(end.CEP);


            //return Json(endList.All(a => a.CEP == endereco.CEP), JsonRequestBehavior.AllowGet);



            //var endList = end.BuscaCEP(endereco.CEP);

            //if (end.CEP != 0)
            //{
            //    CepExists = true;
            //}

            //else
            //{
            //    CepExists = false;
            //}

            //return View(end);

            //return Json(end, JsonRequestBehavior.AllowGet);

        }
    }
}
