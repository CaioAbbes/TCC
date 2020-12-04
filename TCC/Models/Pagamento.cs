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
        public virtual Comanda Comanda { get; set; }

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
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float Total { get; set; }

        [Display(Name = "Número da Mesa")]
        public int IdMesa { get; set; }


        [Display(Name = "Id do Cliente")]
        public int IdCli { get; set; }


        [Display(Name = "CPF do Funcionário")]
        [StringLength(11, ErrorMessage = "A quantidade de caracteres do CPF do funcionário é invalido.", MinimumLength = 11)]
        public string CPFfunc { get; set; }


        [StringLength(6, ErrorMessage = "O numero de caracteres do Código do cupom é invalido ", MinimumLength = 6)]
        [Display(Name = "Código do cupom")]
        public string CodCupom { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Deve ser positivo")]
        [Display(Name = "Quantidade de pontos")]
        public float QtdPontos { get; set; }

        [Display(Name = "CPF do cliente")]
        [StringLength(11, ErrorMessage = "A quantidade de caracteres CPF é invalido.", MinimumLength = 11)]
        public string CPF { get; set; }

        public Pagamento(int idPag, int idComanda, string formPag, float total, int idMesa, int idCli, string cPFfunc, string codCupom, float qtdPontos, string cPF)
        {
            IdPag = idPag;
            IdComanda = idComanda;
            FormPag = formPag;
            Total = total;
            IdMesa = idMesa;
            IdCli = idCli;
            CPFfunc = cPFfunc;
            CodCupom = codCupom;
            QtdPontos = qtdPontos;
            CPF = cPF;
        }

        public Pagamento() { }

        public void InsertPagamento(int IdCli,string FormPag, string CodCupom, float QtdPontos, string CPF)
        {
            string strQuery = string.Format("call sp_InsPagaNF('{0}','{1}','{2}','{3}','{4}');", IdCli, FormPag, CodCupom, QtdPontos, CPF); 

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Pagamento> SelecionaPagamento()
        {
            using (db = new ConexaoDB())
            {

                string StrQuery = string.Format("select * from tbpagamento;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var PagamentoList = new List<Pagamento>();
                while (registros.Read())
                {
                    var PagamentoTemporario = new Pagamento
                    {
                        IdPag = int.Parse(registros["IdPag"].ToString()),
                        CPFfunc = new Funcionario().SelecionaComCPFFunc(registros["CPFfunc"].ToString()),
                        Comanda = new Comanda().SelecionaIdComanda(int.Parse(registros["IdComanda"].ToString())),
                        FormPag = registros["FormPag"].ToString(),
                        Total = float.Parse(registros["Total"].ToString())
                    };

                    PagamentoList.Add(PagamentoTemporario);
                }
                return PagamentoList;
            }

        }


        public Pagamento SelecionaComIdPag(int IdPag)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbpagamento where IdPag = '{0}';", IdPag);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Pagamento PagamentoListando = null;
                while (registros.Read())
                {
                    PagamentoListando = new Pagamento
                    {
                        IdPag = int.Parse(registros["IdPag"].ToString()),
                        CPFfunc = new Funcionario().SelecionaComCPFFunc(registros["CPFfunc"].ToString()),
                        Comanda = new Comanda().SelecionaIdComanda(int.Parse(registros["IdComanda"].ToString())),
                        FormPag = registros["FormPag"].ToString(),
                        Total = float.Parse(registros["Total"].ToString())
                    };
                }

                return PagamentoListando;
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