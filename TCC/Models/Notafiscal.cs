using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Notafiscal
    {

        private ConexaoDB db;


        [Required(ErrorMessage = "O campo Id da nota fiscal é requerido.")]
        [Display(Name = "Id da nota fiscal")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdNF { get; set; }

        //[Required(ErrorMessage = "O campo CPF é requerido.")]
        //[Display(Name = "CPF")]
        //public decimal CPF { get; set; }

        public Cliente Cliente { get; set; }

        [Display(Name = "Id do pagamento")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdPag { get; set; }

        [Required(ErrorMessage = "O campo Data e hora do pagamento é requerido.")]
        [Display(Name = "Data e hora do pagamento")]
        //[DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraPag { get; set; }

        [Required(ErrorMessage = "O campo Valor total é requerido.")]
        [Display(Name = " Valor total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float ValorTotal { get; set; }


        public List<Notafiscal> SelecionaNotafiscal()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbnotafiscal;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var notafiscalList = new List<Notafiscal>();
                var cpfTemp = new Cliente
                {
                    CPF = null
                };

                while (registros.Read())
                {
                    string CPF = registros["CPF"].ToString();
                    var NotafiscalTemporaria = new Notafiscal
                    {
                        IdNF = int.Parse(registros["IdNF"].ToString()),
                        Cliente = CPF != "" ? new Cliente().SelecionaCPF(CPF) : cpfTemp,
                        IdPag = new Pagamento().SelecionaIdPag(int.Parse(registros["IdPag"].ToString())),
                        DataHoraPag = DateTime.Parse(registros["DataHoraPag"].ToString()),
                        ValorTotal = float.Parse(registros["ValorTotal"].ToString())
                    };
                    notafiscalList.Add(NotafiscalTemporaria);
                }
                return notafiscalList;
            }
        }

        public Notafiscal SelecionaIdNF(int IdNF)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbnotafiscal where IdNF = '{0}';", IdNF);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Notafiscal notafiscalListando = null;
                var cpfTemp = new Cliente
                {
                    CPF = null
                };
                while (registros.Read())
                {
                    string CPF = registros["CPF"].ToString();
                    notafiscalListando = new Notafiscal
                    {
                        IdNF = int.Parse(registros["IdNF"].ToString()),
                        Cliente = CPF != "" ? new Cliente().SelecionaCPF(CPF) : cpfTemp,
                        IdPag = new Pagamento().SelecionaIdPag(int.Parse(registros["IdPag"].ToString())),
                        DataHoraPag = DateTime.Parse(registros["DataHoraPag"].ToString()),
                        ValorTotal = float.Parse(registros["ValorTotal"].ToString())
                    };
                }

                return notafiscalListando;
            }

        }







    }
}