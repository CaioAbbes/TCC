using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Pagamento
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Id da pagamento é requerido.")]
        [Display(Name = "Id da pagamento")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        private int IdPag { get; set; }

        private Mesa Mesa { get; set; }

        private Cliente Cliente { get; set; }

        private Funcionario Funcionario { get; set; }

        private Cupom Cupom { get; set; }

        //[Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        //[Display(Name = "CPF do funcionário.")]
        //public decimal CPFfunc { get; set; }


        [Display(Name = "Id da comanda")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        private int IdComanda { get; set; }

        [Required(ErrorMessage = "O campo Forma de pagamentoo é requerido.")]
        [Display(Name = "Forma de pagamento")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(17, ErrorMessage = "A quantidade de caracteres do Forma de pagamento é invalido.")]
        private string FormPag { get; set; }

        [Required(ErrorMessage = "O campo Total é requerido.")]
        [Display(Name = "Total")]
        private float Total { get; set; }


        private int IdMesa { get; set; }

        private int IdCli { get; set; }

        private decimal CPFfunc { get; set; }

        private string CodCupom { get; set; }

        private float QtdPontos { get; set; }
        private decimal CPF { get; set; }

        public void InsertPagamento(int IdMesa, int IdCli, decimal CPFfunc, string FormPag, string CodCupom, float QtdPontos, decimal CPF)
        {
            string strQuery = string.Format("call sp_InsPagaNF('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", IdMesa, 0, CPFfunc, FormPag, CodCupom, QtdPontos, CPF);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }



        public int SelecionaIdPag(int IdPag)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select IdPag from tbpagamento where IdPag = '{0}';", IdPag);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Pagamento pagamentoListando = null;
                while (registros.Read())
                {
                    pagamentoListando = new Pagamento
                    {
                        IdPag = int.Parse(registros["IdPag"].ToString())
                    };
                }

                return IdPag;
            }

        }
    }
}