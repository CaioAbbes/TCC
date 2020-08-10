using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbcupom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult tbcupom(Cupom cupom)
        {
            MySqlConnection conexao = new MySqlConnection("server = localhost; user id = root; password = 12345678; database = db_rest");
            conexao.Open();
            var query = "CALL sp_InsCupom (";
            query += string.Format("'{0}'", cupom.CodCupom);
            query += string.Format(",'{0}')", cupom.Desconto);
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.ExecuteNonQuery();
            return View();
        }

        public ActionResult tbproduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult tbproduto(Produto produto)
        {
            MySqlConnection conexao = new MySqlConnection("server = localhost; user id = root; password = 12345678; database = db_rest");
            conexao.Open();
            var query = "CALL sp_InsProd (";
            query += string.Format("'{0}',",produto.IdProd);
            query += string.Format("'{0}',", produto.NomeProd);
            query += string.Format("'{0}',",produto.DescProd);
            query += string.Format("'{0}'", produto.Observacao);
            query += string.Format(",'{0}')", produto.ValorProd);
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.ExecuteNonQuery();
            return View();
        }

        public ActionResult tbusuario()
        {
            return View();
        }
        

            [HttpPost]
        public ActionResult tbusuario(Usuario usuario)
        {
                MySqlConnection conexao = new MySqlConnection("server = localhost; user id = root; password = 12345678; database = db_rest");
                conexao.Open();
                var query = "INSERT into tbusuario(Usuario,Senha,TipoAcesso) VALUES(";
                query += string.Format("'{0}',", usuario.UsuarioText);
                query += string.Format("'{0}'", usuario.Senha);
                query += string.Format(",'{0}');", usuario.TipoAcesso);
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.ExecuteNonQuery();

            return View();
        }

        public ActionResult tbendereco()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbingrediente()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult tbmesa()
        {

            return View();
        }

        [HttpPost]
        public ActionResult tbmesa(Mesa mesa)
        {
            MySqlConnection conexao = new MySqlConnection("server = localhost; user id = root; password = 12345678; database = db_rest");
            conexao.Open();
           // MySqlCommand comando = new MySqlCommand("sp_InsMesa", conexao);
           // comando.CommandType = System.Data.CommandType.StoredProcedure;
            var query = "CALL sp_InsMesa(";
            query += string.Format("'{0}'",mesa.Numlugares);
            query += string.Format(",'{0}')", mesa.TipoLugar);
            MySqlCommand comando = new MySqlCommand(query, conexao);
            //comando.Parameters.AddWithValue("VarNumlugares", string.IsNullOrEmpty(Convert.ToString(mesa.TipoLugar)));
            //comando.Parameters.AddWithValue("varTipoLugar", string.IsNullOrEmpty(Convert.ToString(mesa.TipoLugar)));
            int intReturn =  int.Parse(comando.ExecuteNonQuery().ToString());
            if (intReturn != -1)
                Response.Write("Usuário cadastrado.");
            else
                Response.Write("Limite máximo de usuários atingido.");
            return View();
        }

        public ActionResult tbfornecedor()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbfuncionario()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbcliente()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbCOMANDA()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbcartao()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbpagamento()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbnotafiscal()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult tbproduto_pedido()
        {
            return View();
        }

        [HttpPost]
        public ActionResult tbproduto_pedido(Produto_pedido pedido,Mesa mesa,Comanda comanda)
        {
            MySqlConnection conexao = new MySqlConnection("server = localhost; user id = root; password = 12345678; database = db_rest");
            conexao.Open();
            var query = "CALL sp_InsPedido (";
            query += string.Format("'{0}',",mesa.IdMesa);
            query += string.Format("'{0}'", comanda.Idcli);
            query += string.Format(",'{0}'", pedido.NomeProd);
            query += string.Format(",'{0}')",pedido.QtdProd);
            MySqlCommand comando = new MySqlCommand(query,conexao);
            int intReturn = int.Parse(comando.ExecuteNonQuery().ToString());
            if (intReturn != -1)
                Response.Write("Usuário cadastrado.");
            else
                Response.Write("Limite máximo de usuários atingido.");

            return View();
        }

        public ActionResult tbreserva()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbclicupom()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult tbsaida_ingre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult tbsaida_ingre(Saida_ingre saida)
        {
            MySqlConnection conexao = new MySqlConnection("server = localhost; user id = root; password = 12345678; database = db_rest");
            conexao.Open();
            var query = "CALL sp_InsBaixaEstoque (";
            query += string.Format("'{0}',",saida.CPFfunc);
            query += string.Format("'{0}',", saida.Nome);
            query += string.Format("'{0}',", saida.CodigoBarras);
            query += string.Format("'{0}'",saida.QtdUsada);
            query += string.Format(",'{0}')",saida.DataHoraSaida.ToString("yyyy-MM-dd H:mm"));
            MySqlCommand comando = new MySqlCommand(query, conexao);
            // comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            return View();
        }

        public ActionResult tbcompra()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}