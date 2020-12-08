using System;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class Saida_ingreController : Controller
    {
        // GET: Saida_ingre
        public ActionResult Index()
        {
            return View();
        }

        // GET: Saida_ingre/Details/5
        public ActionResult Details(int IdSaidaIngre)
        {
            try
            {
                var saida = new Saida_ingre();
                var objSaida = new Saida_ingre();
                saida = objSaida.SelecionaIdSaida(IdSaidaIngre);
                return View(saida);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar a saida do ingrediente');</script>";
                return View();
            }
        }


        [Autenticacao]
        public ActionResult List(Saida_ingre saida)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 4 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var saidaList = saida.SelecionaSaida();
                return View(saidaList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar as saidas do ingrediente');</script>";
                return View();
            }
        }

        // GET: Saida_ingre/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 4 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Saida_ingre/Create
        [HttpPost]
        public ActionResult Create(string cPFfunc, string nome, int qtdUsada, DateTime dataHoraSaida)
        {
            if (ModelState.IsValid)
            {
                var objSaida = new Saida_ingre();
                objSaida.InsertSaidaIngre(cPFfunc, nome, qtdUsada, dataHoraSaida);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar a saida do ingrediente');</script>";
            return View();
        }
    }
}
