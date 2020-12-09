using System.Web.Mvc;

namespace TCC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BemvindoADM()
        {
            return View();
        }

        public ActionResult ObrigadoPorComprar()
        {
            Session.Remove("Carrinho");
            return View();
        }


    }
}