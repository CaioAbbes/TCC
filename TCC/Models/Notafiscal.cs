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

        [Required(ErrorMessage = "O campo CPF é requerido.")]
        [Display(Name = "CPF")]
        public decimal CPF { get; set; }

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
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
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
                    CPF = 0
                };
                decimal cpf = decimal.Parse(registros["CPF"].ToString());
                while (registros.Read())
                {
                    var NotafiscalTemporaria = new Notafiscal
                    {
                        IdNF = int.Parse(registros["IdNF"].ToString()),
                       // CPF = new Cliente().SelecionaCPF(decimal.Parse(registros["CPF"].ToString())),
                       //CPF = cpf != 0 ? new Cliente().SelecionaCPF(cpf) : cpfTemp,
                        IdPag = new Pagamento().SelecionaIdPag(int.Parse(registros["IdPag"].ToString())),
                        DataHoraPag = DateTime.Parse(registros["DataHoraPag"].ToString()),
                        ValorTotal = float.Parse(registros["ValorTotal"].ToString())
                    };
                    notafiscalList.Add(NotafiscalTemporaria);
                }
                return notafiscalList;
            }
        }

        public Mesa SelecionaIdMesa(int IdMesa)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbmesa where IdMesa = '{0}';", IdMesa);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Mesa mesaListando = null;
                while (registros.Read())
                {
                    mesaListando = new Mesa
                    {
                        IdMesa = int.Parse(registros["IdMesa"].ToString()),
                        Numlugares = int.Parse(registros["Numlugares"].ToString()),
                        Disponi = bool.Parse(registros["Disponi"].ToString()),
                        TipoLugar = registros["TipoLugar"].ToString()
                    };
                }

                return mesaListando;
            }

        }







    }
}