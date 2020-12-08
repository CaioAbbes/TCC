using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class CartaoController : Controller
    {
        // GET: Cartao
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cartao/Details/5
        public ActionResult Details(decimal Numcartao)
        {
            try
            {
                var cartao = new Cartao();
                var objCartao = new Cartao();
                cartao = objCartao.SelecionaComNumCartao(Numcartao);
                return View(cartao);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o cartão');</script>";
                return View();
            }
        }

        [Autenticacao]
        public ActionResult List(Cartao cartao)
        {
            try
            {
                if (int.Parse(Session["NivelAcesso"].ToString()) == 1 || int.Parse(Session["NivelAcesso"].ToString()) == 2 || int.Parse(Session["NivelAcesso"].ToString()) == 3 || int.Parse(Session["NivelAcesso"].ToString()) == 4 || int.Parse(Session["NivelAcesso"].ToString()) == 5)
                {
                    return RedirectToAction("ErroAutenticação", "Usuario");
                }
                var cartaoList = cartao.SelecionaCartao();
                return View(cartaoList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar o cartão');</script>";
                return View();
            }
        }

        // GET: Cartao/Create
        public ActionResult Create(int idCli)
        {
            var cartao = new Cartao();
            var objCartao = new Cartao();
            cartao = objCartao.SelecionaComNumCartao(idCli);
            return View(cartao);
        }

        // POST: Cartao/Create
        [HttpPost]
        public ActionResult Create(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                var objCartao = new Cartao();
                int IdCli = int.Parse(Session["IdCli"].ToString());
                objCartao.InsertCartao(cartao, IdCli);
                return RedirectToAction("List","Produto");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o cartão');</script>";
            return View();
        }


        // GET: Cartao/Delete/5
        public ActionResult Delete(decimal Numcartao)
        {
            var cartao = new Cartao();
            var objCartao = new Cartao();
            cartao = objCartao.SelecionaComNumCartao(Numcartao);
            return View(cartao);
        }

        // POST: Cartao/Delete/5
        [HttpPost]
        public ActionResult Delete(Cartao cartao)
        {
            try
            {
                var objCartao = new Cartao();
                objCartao.DeleteCartao(cartao);
                return RedirectToAction("List");
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao deletar o cartão');</script>";
                return View();
            }
        }
    }
}
