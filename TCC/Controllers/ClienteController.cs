using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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


            var objCli = new Cliente();
            objCli.SelecionaCliente();

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
            var cliente = new Cliente() ;
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
    }
}
