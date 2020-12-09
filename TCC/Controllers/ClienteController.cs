using System;
using System.IO;
using System.Web.Mvc;
using TCC.Models;
using TCC.Autorizacoes;

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
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var clienteList = cliente.SelecionaCliente();
                return View(clienteList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os clientes');</script>";
                return View();
            }
        }



        // GET: Cliente/Details/5
        public ActionResult Details(int IdCli)
        {
            try
            {
                var cliente = new Cliente();
                var objCliente = new Cliente();
                cliente = objCliente.SelecionaComIdCli(IdCli);
                return View(cliente);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o clientes');</script>";
                return View();
            }
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
                string filename = Path.GetFileNameWithoutExtension(cliente.ImageUpload.FileName);
                string extesion = Path.GetExtension(cliente.ImageUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extesion;
                cliente.Imagem = "~/Imagens/" + filename;
                filename = Path.Combine(Server.MapPath("~/Imagens/"), filename);
                cliente.ImageUpload.SaveAs(filename);
                objCli.InsertCliente(cliente);
                return RedirectToAction("Login", "Usuario");

            }
            TempData["msg"] = "<script>alert('Erro ao criar o cliente');</script>";
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
            try
            {
                var objCli = new Cliente();
                objCli.UpdateCliente(cliente);
                //return RedirectToAction("Details", new { IdCli = cliente.IdCli });
                return RedirectToAction("Index","Home");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao editar o clientes');</script>";
                return View();
            }
        }

    }
}