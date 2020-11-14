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
        public int IdPag { get; set; }

        public virtual Mesa Mesa { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public virtual Cupom Cupom { get; set; }

        //[Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        //[Display(Name = "CPF do funcionário.")]
        //public decimal CPFfunc { get; set; }


        [Display(Name = "Id da comanda")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdComanda { get; set; }

        [Required(ErrorMessage = "O campo Forma de pagamentoo é requerido.")]
        [Display(Name = "Forma de pagamento")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(17, ErrorMessage = "A quantidade de caracteres do Forma de pagamento é invalido.")]
        public string FormPag { get; set; }

        [Required(ErrorMessage = "O campo Total é requerido.")]
        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}",ApplyFormatInEditMode = true)]
        public float Total { get; set; }


        public int IdMesa { get; set; }

        public int IdCli { get; set; }

        public decimal CPFfunc { get; set; }

        public string CodCupom { get; set; }

        public float QtdPontos { get; set; }

        public decimal CPF { get; set; }

        public void InsertPagamento(int IdMesa, int IdCli, decimal CPFfunc, string FormPag, string CodCupom, float QtdPontos, decimal CPF)
        {
            string strQuery = string.Format("call sp_InsPagaNF('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", IdMesa, 0, CPFfunc, FormPag, null, QtdPontos, CPF);

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