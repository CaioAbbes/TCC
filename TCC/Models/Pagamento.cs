﻿using MySql.Data.MySqlClient;
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
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float Total { get; set; }


        public int IdMesa { get; set; }

        public int IdCli { get; set; }

        public decimal CPFfunc { get; set; }

        public string CodCupom { get; set; }

        public float QtdPontos { get; set; }

        public decimal CPF { get; set; }

        public Pagamento(int idPag, int idComanda, string formPag, float total, int idMesa, int idCli, decimal cPFfunc, string codCupom, float qtdPontos, decimal cPF)
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

        public void InsertPagamento(int IdMesa, int IdCli, decimal CPFfunc, string FormPag, string CodCupom, float QtdPontos, decimal CPF)
        {
            string strQuery = string.Format("call sp_InsPagaNF('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", IdMesa, 0, CPFfunc, FormPag, null, 0, CPF);

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
                        CPFfunc = new Funcionario().SelecionaComCPFFunc(decimal.Parse(registros["CPFfunc"].ToString())),
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
                        CPFfunc = new Funcionario().SelecionaComCPFFunc(decimal.Parse(registros["CPFfunc"].ToString())),
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