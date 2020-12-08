using System.Web.Mvc;
using TCC.Autorizacoes;
using TCC.Models;

namespace TCC.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pagamento/Details/5
        public ActionResult Details(int IdPag)
        {
            try
            {
                var pagamento = new Pagamento();
                var objPagamento = new Pagamento();
                pagamento = pagamento.SelecionaComIdPag(IdPag);
                return View(pagamento);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao detalhar o pagamento');</script>";
                return View();
            }
        }

        public ActionResult List(Pagamento pagamento)
        {
            try
            {
                var pagamentoList = pagamento.SelecionaPagamento();
                return View(pagamentoList);
            }
            catch
            {
                TempData["msg"] = "<script>alert('Erro ao listar os pagamentos');</script>";
                return View();
            }
        }

        // GET: Pagamento/Create
        [Autenticacao]
        public ActionResult Create()
        {
            if (int.Parse(Session["NivelAcesso"].ToString()) != 1 && int.Parse(Session["NivelAcesso"].ToString()) != 5)
            {
                return RedirectToAction("ErroAutenticação", "Usuario");
            }

            var objPagamento = new Pagamento();
            string[] TiposdePag = new string[] { "Cartão de crédito", "Cartão de débito", "Dinheiro"}; 
            SelectList Lista = new SelectList(TiposdePag);
            ViewBag.Lista = Lista;

            var cupom = new Cupom();
            var ListaCupom = cupom.SelecionaCupom();
            SelectList ListaDeCupom = new SelectList(ListaCupom, "CodCupom", "CodCupom");
            ViewBag.ListaCupom = ListaDeCupom;
                                           
            return View(objPagamento);
        }

        // POST: Pagamento/Create
        [HttpPost]
        public ActionResult Create(string FormPag, string CodCupom, float QtdPontos, string CPF)
        {

            if (ModelState.IsValid)
            {
                var objPagamento = new Pagamento();
                int IdCli = int.Parse(Session["IdCli"].ToString());
                objPagamento.InsertPagamento( IdCli, FormPag, CodCupom, QtdPontos, CPF);
                //return RedirectToAction("UltimosPedidosCli","Produto_Pedido", new { IdCli = Session["IdCli"].ToString()});
                return RedirectToAction("ObrigadoPorComprar", "Home");
            }
            TempData["msg"] = "<script>alert('Erro ao criar o pagamento');</script>";
            return View();
        }
    }
}
