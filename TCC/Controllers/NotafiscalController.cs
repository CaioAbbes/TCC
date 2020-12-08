using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class NotafiscalController : Controller
    {
        // GET: Notafiscal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Notafiscal/Details/5
        public ActionResult Details(int IdNF)
        {
            try
            {
                var notafiscal = new Notafiscal();
                var objNotafiscal = new Notafiscal();
                notafiscal = objNotafiscal.SelecionaIdNF(IdNF);
                return View(notafiscal);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar o clientes');</script>";
                return View();
            }
        }

        [Autenticacao]
        public ActionResult List(Notafiscal notafiscal)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var notafiscalList = notafiscal.SelecionaNotafiscal();
                return View(notafiscalList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar as notas fiscais');</script>";
                return View();
            }
        }
    }
}
