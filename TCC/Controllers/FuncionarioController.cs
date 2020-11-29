using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(Funcionario funcionario)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var funcionarioList = funcionario.SelecionaFuncionario();
            return View(funcionarioList);

        }


        // GET: Funcionario/Details/5
        public ActionResult Details(int IdFunc)
        {
            var funcionario = new Funcionario();
            var objFunc = new Funcionario();
            funcionario = objFunc.SelecionaComIdFunc(IdFunc);
            return View(funcionario);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            if (ModelState.IsValid)
            {
                var objFunc = new Funcionario();
                objFunc.InsertFuncionario(funcionario);
                return RedirectToAction("List");
            }
            return View();
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int IdFunc)
        {
            var funcionario = new Funcionario();
            var objFunc = new Funcionario();
            funcionario = objFunc.SelecionaComIdFunc(IdFunc);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var objFunc = new Funcionario();
            objFunc.UpdateFuncionario(funcionario);
            return RedirectToAction("List");
        }

    }
}
