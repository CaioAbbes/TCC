using System;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        // GET: Compra/Details/5
        [Autenticacao]
        public ActionResult Details(int NumCompra)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            try
            {

                var compra = new Compra();
                var objCompra = new Compra();
                compra = objCompra.SelecionaNumCompra(NumCompra);
                return View(compra);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar a compra');</script>";
                return View();
            }
        }

        [Autenticacao]
        public ActionResult List(Compra compra)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            try
            {
                var compraList = compra.SelecionaCompra();
                return View(compraList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar a compra');</script>";
                return View();
            }
        }


        // GET: Compra/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }

            var objFornecedor = new Fornecedor();
            var ListaFornecedor = objFornecedor.SelecionaFornecedor();
            SelectList Lista = new SelectList(ListaFornecedor, "NomeForn", "NomeForn");
            ViewBag.Lista = Lista;
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult Create(string CodigoBarras, string NomeForn, int QtdEntraIngre, DateTime DataHoraChegada, string nomeIngre, string uniMedi, float precoUnit, string marca, DateTime? dataValidade, string tempDura)
        {
            if (ModelState.IsValid)
            {
                var objCompra = new Compra();
                objCompra.InsertCompra(CodigoBarras, NomeForn, QtdEntraIngre, DataHoraChegada, nomeIngre, uniMedi, precoUnit, marca, dataValidade, tempDura);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar a compra');</script>";
            return View();
        }
    }
}
