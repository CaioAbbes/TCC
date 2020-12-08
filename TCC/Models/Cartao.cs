using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Cartao
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Número do cartão é requerido.")]
        [Display(Name = "Número do cartão")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public string Numcartao { get; set; }

        [Required(ErrorMessage = "O campo Código de Verificação de Cartão é requerido.")]
        [Display(Name = "CVC")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "CVC invalido")]
        public int Cvc { get; set; }

        [Required(ErrorMessage = "O campo Nome do titular é requerido.")]
        [Display(Name = "Nome do titular")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50,ErrorMessage = "A quantidade de caracteres do Nome do titular é invalida.")]
        public string Titular { get; set; }

        [Required(ErrorMessage = "O campo Vencimento é requerido.")]
        [Display(Name = "Vencimento")]
        [DisplayFormat(DataFormatString = "{0:MM/yy}", ApplyFormatInEditMode = true)]

        public DateTime Datavalid { get; set; }
        
       
        public virtual Cliente Cliente { get; set; } //nesse ele chumba com o id Do usuario cadastrado


        public void InsertCartao(Cartao cartao, int idCli)
        {
            string strQuery = string.Format("call sp_InsCartao('{0}','{1}','{2}','{3}','{4}');", idCli, cartao.Numcartao,cartao.Cvc,cartao.Titular,cartao.Datavalid.ToString("yyyy-MM-01").Replace("/",string.Empty));

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void DeleteCartao(Cartao cartao, int idCli)
        {
            string strQuery = string.Format("call sp_DelCartao('{0}','{1}');", idCli, cartao.Numcartao);

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
                        Numcartao = registros["Numcartao"].ToString(),
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
                        Numcartao = registros["Numcartao"].ToString(),
                        Cvc = int.Parse(registros["cvc"].ToString()),
                        Titular = registros["titular"].ToString(),
                        Datavalid = DateTime.Parse(registros["datavalid"].ToString()),
                        Cliente = new Cliente().SelecionaIdCli(int.Parse(registros["IdCli"].ToString()))
                    };
                }

                return cartaoListando;
            }

        }

        public List<Cartao> SelecionaComNumCartaoCli(int idCli)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcartao where IdCli = '{0}';", idCli);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var cartaoList = new List<Cartao>();
                while (registros.Read())
                {
                   var cartaoListando = new Cartao
                    {
                        Numcartao = registros["Numcartao"].ToString(),
                        Cvc = int.Parse(registros["cvc"].ToString()),
                        Titular = registros["titular"].ToString(),
                        Datavalid = DateTime.Parse(registros["datavalid"].ToString()),
                        Cliente = new Cliente().SelecionaIdCli(int.Parse(registros["IdCli"].ToString()))
                    };
                    cartaoList.Add(cartaoListando);
                }

                return cartaoList;
            }

        }



    }
}