using System;
using System.IO;
using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{

    public class MesaController : Controller
    {

        // GET: Mesa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mesa/Details/5
        public ActionResult Details(int IdMesa)
        {
            try
            {
                var mesa = new Mesa();
                var objMesa = new Mesa();
                mesa = objMesa.SelecionaIdMesa(IdMesa);
                return View(mesa);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar a mesa');</script>";
                return View();
            }
        }

        [Autenticacao]
        public ActionResult List(Mesa mesa)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) != 1 && int.Parse(Session["NivelAcesso"].ToString()) != 5 && int.Parse(Session["NivelAcesso"].ToString()) != 2)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var mesaList = mesa.SelecionaMesa();
                return View(mesaList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar as mesas');</script>";
                return View();
            }
        }

        // GET: Mesa/Create
        [Autenticacao]
        public ActionResult Create()
        {

            if (int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }

            var objMesa = new Mesa();
            int[] NumLugar = new int[] { 1, 2, 3, 4, 5 }; //5, pois é o maximo de cadeiras que uma mesa pode ter
            SelectList Lista = new SelectList(NumLugar);
            ViewBag.Lista = Lista;

            string[] TipoLugar = new string[] { "Coberto", "Arejado" };
            SelectList ListaTipoLugar = new SelectList(TipoLugar);
            ViewBag.ListaTipoLugar = ListaTipoLugar;

            return View(objMesa);
        }

        // POST: Mesa/Create
        [HttpPost]
        public ActionResult Create(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                var objMesa = new Mesa();
                string filename = Path.GetFileNameWithoutExtension(mesa.ImageUpload.FileName);
                string extesion = Path.GetExtension(mesa.ImageUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extesion;
                mesa.Imagem = "~/Imagens/" + filename;
                filename = Path.Combine(Server.MapPath("~/Imagens/"), filename);
                mesa.ImageUpload.SaveAs(filename);
                objMesa.InsertMesa(mesa);
                return RedirectToAction("BemvindoADM", "Home");
            }
            TempData["msg"] = "<script>alert('Erro ao criar a mesa');</script>";
            return View();
        }     
    }
}
