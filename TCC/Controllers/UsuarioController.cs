using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                return RedirectToAction("List", "Cliente");
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
                //return RedirectToAction("List", "Cliente", new { username = usuario.UsuarioText});
                return RedirectToAction("List", "Cliente");
            }
            else
            {
                return RedirectToAction("Create", "Cliente");
            }
        }


    }
}