using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            bool logado = usuario.ValidaLogin();

            if (logado)
            {
                Session["nomeUsuarioLogado"] = usuario.UsuarioText;
                Session["NivelAcesso"] = usuario.RetornaTipoAcesso();
                return RedirectToAction("Index", "Home");
            }

            else
            {
                //TempData["ErroLogin"] = "Senha ou Usuario inválido";
                //ModelState.AddModelError(string.Empty, TempData["ErroLogin"].ToString());
                TempData["msg"] = "<script>alert('Usuario ou senha inválida');</script>";
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


        //public ActionResult VoltarPag()
        //{
        //    return Redirect(Request.UrlReferrer.ToString());
        //}


    }
}