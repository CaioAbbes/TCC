using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Autorizacoes;
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

        [Autenticacao]
        public ActionResult List(Funcionario funcionario)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var funcionarioList = funcionario.SelecionaFuncionario();
                return View(funcionarioList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os funcionarios');</script>";
                return View();
            }
        }


        // GET: Funcionario/Details/5
        public ActionResult Details(int IdFunc)
        {
            try
            {
                var funcionario = new Funcionario();
                var objFunc = new Funcionario();
                funcionario = objFunc.SelecionaComIdFunc(IdFunc);
                return View(funcionario);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o funcionario');</script>";
                return View();
            }
        }

        // GET: Funcionario/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {

            if (ModelState.IsValid)
            {
                var objFunc = new Funcionario();
                string filename = Path.GetFileNameWithoutExtension(funcionario.ImageUpload.FileName);
                string extesion = Path.GetExtension(funcionario.ImageUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extesion;
                funcionario.Imagem = "~/Imagens/" + filename;
                filename = Path.Combine(Server.MapPath("~/Imagens/"), filename);
                funcionario.ImageUpload.SaveAs(filename);
                objFunc.InsertFuncionario(funcionario);
                return RedirectToAction("List");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o funcionario');</script>";
            return View();
        }

        // GET: Funcionario/Edit/5
        [Autenticacao]
        public ActionResult Edit(int IdFunc)
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }
            var funcionario = new Funcionario();
            var objFunc = new Funcionario();
            funcionario = objFunc.SelecionaComIdFunc(IdFunc);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            try
            {
                var objFunc = new Funcionario();
                objFunc.UpdateFuncionario(funcionario);
                return RedirectToAction("List");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao editar o funcionario');</script>";
                return View();
            }
        }

    }
}
