using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class IngredienteController : Controller
    {
        // GET: Ingrediente
        public ActionResult Index()
        {
            return View();
        }


        [Autenticacao]
        public ActionResult List(Ingrediente ingrediente)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 4 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }

                var listIngre = ingrediente.SelecionaIngrediente();
                return View(listIngre);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os ingredientes');</script>";
                return View();
            }
        }


        // GET: Ingrediente/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 4 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Ingrediente/Create
        [HttpPost]
        public ActionResult Create(Ingrediente ingrediente)
        {


            if (ModelState.IsValid)
            {
                var objIngrediente = new Ingrediente();
                objIngrediente.InsertIngrediente(ingrediente);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o ingrediente');</script>";
            return View();

        }

    }
}
