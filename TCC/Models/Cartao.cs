using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Cartao
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Número do cartão é requerido.")]
        [Display(Name = "Número do cartão")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        private decimal Numcartao { get; set; }

        [Required(ErrorMessage = "O campo Código de Verificação de Cartão é requerido.")]
        [Display(Name = "Código de Verificação de Cartão")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "CVV invalido")]
        private int Cvc { get; set; }

        [Required(ErrorMessage = "O campo Nome do titular é requerido.")]
        [Display(Name = "Nome do titular")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50,ErrorMessage = "A quantidade de caracteres do Nome do titular é invalida.")]
        private string Titular { get; set; }

        [Required(ErrorMessage = "O campo Data de vencimento é requerido.")]
        [Display(Name = "Data de vencimento ")]
        //[DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date)]
        private DateTime Datavalid { get; set; }
        
        private  Cliente Cliente { get; set; }

        public void InsertCartao(Cartao cartao)
        {
            string strQuery = string.Format("call sp_InsCartao('{0}','{1}','{2}','{3}','{4}');",2,cartao.Numcartao,cartao.Cvc,cartao.Titular,cartao.Datavalid.ToString("yyyy-MM-dd HH:mm"));

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void DeleteCartao(Cartao cartao)
        {
            string strQuery = string.Format("call sp_DelCartao('{0}','{1}');", 2,cartao.Numcartao);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Cartao> SelecionaCartao()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcartao;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var cartaoList = new List<Cartao>();
                while (registros.Read())
                {
                    var CartaoTemporario = new Cartao
                    {
                        Numcartao = decimal.Parse(registros["Numcartao"].ToString()),
                        Cvc = int.Parse(registros["cvc"].ToString()),
                        Titular = registros["titular"].ToString(),
                        Datavalid = DateTime.Parse(registros["datavalid"].ToString()),
                        Cliente = new Cliente().SelecionaIdCli(int.Parse(registros["IdCli"].ToString()))
                    };
                    cartaoList.Add(CartaoTemporario);
                }
                return cartaoList;
            }
        }

        public Cartao SelecionaComNumCartao(decimal Numcartao)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcartao where Numcartao = '{0}';", Numcartao);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Cartao cartaoListando = null;
                while (registros.Read())
                {
                    cartaoListando = new Cartao
                    {
                        Numcartao = decimal.Parse(registros["Numcartao"].ToString()),
                        Cvc = int.Parse(registros["cvc"].ToString()),
                        Titular = registros["titular"].ToString(),
                        Datavalid = DateTime.Parse(registros["datavalid"].ToString()),
                        Cliente = new Cliente().SelecionaIdCli(int.Parse(registros["IdCli"].ToString()))
                    };
                }

                return cartaoListando;
            }

        }



    }
}