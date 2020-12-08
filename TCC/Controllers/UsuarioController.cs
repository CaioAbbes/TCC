using System.Web.Mvc;
using System.Web.Security;
using TCC.Models;

namespace TCC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session["nomeUsuarioLogado"] != null)
            {
                //return RedirectToAction("List", "Cliente", new { username = Session["nomeUsuarioLogado"].ToString() });
               return RedirectToAction("Index", "Home");
            }

            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {

            try
            {
                bool logado = usuario.ValidaLogin();

                if (logado)
                {
                    Session["nomeUsuarioLogado"] = usuario.UsuarioText;
                    Session["NivelAcesso"] = usuario.RetornaTipoAcesso();

                    Session["IdCli"] = usuario.PegaIdCli();
                    Session["IdFunc"] = usuario.PegaIdFunc();


                    if (int.Parse(Session["NivelAcesso"].ToString()) == 5)
                    {
                        return RedirectToAction("BemvindoADM", "Home");
                    }



                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    TempData["msg"] = "<script>alert('Usuario ou senha inválida');</script>";
                    return View();
                }
            }
            catch
            {
                TempData["erro"] = "<script>alert('Erro ao fazer o login');</script>";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");

        }

        public ActionResult ErroAutenticação()
        {
            return View();
        }



    }
}