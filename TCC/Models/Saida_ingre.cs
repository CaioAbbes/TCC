using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Saida_ingre
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Id saida ingrediente é requerido.")]
        [Display(Name = "Id saida ingrediente")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdSaidaIngre { get; set; }

        [Required(ErrorMessage = "O campo Codigo de barras é requerido.")]
        [Display(Name = "Codigo de barras")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        // [StringLength(13,ErrorMessage = "A quantidade de caracteres do Codigo de barras é invalido.",MinimumLength = 13)]
        public decimal CodigoBarras { get; set; }

        [Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        [Display(Name = "CPF do funcionário.")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPFfunc { get; set; }

        

        [Required(ErrorMessage = "O campo Nome é requerido.")]
        [Display(Name = "Nome ")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome é invalido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Quantidade usada é requerido.")]
        [Display(Name = "Quantidade usada")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdUsada { get; set; }

        [Required(ErrorMessage = "O campoData e hora da saida é requerido.")]
        [Display(Name = "Data e hora da saida")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraSaida { get; set; }

        public Saida_ingre(int idSaidaIngre, decimal cPFfunc, string nome, int qtdUsada, DateTime dataHoraSaida)
        {
            IdSaidaIngre = idSaidaIngre;
            CPFfunc = cPFfunc;
            Nome = nome;
            QtdUsada = qtdUsada;
            DataHoraSaida = dataHoraSaida;
        }

        public Saida_ingre() { }

        public void InsertSaidaIngre(decimal cPFfunc, string nome, int qtdUsada, DateTime dataHoraSaida)
        {
            string strQuery = string.Format("CALL sp_InsBaixaEstoque ('{0}','{1}','{2}','{3}');", cPFfunc, nome, qtdUsada, dataHoraSaida.ToString("yyyy-MM-dd HH:mm"));

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }

        }


        public List<Saida_ingre> SelecionaSaida()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbsaida_ingre;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var saidaList = new List<Saida_ingre>();
                while (registros.Read())
                {
                    var SaidaTemporaria = new Saida_ingre
                    {
                        IdSaidaIngre = int.Parse(registros["IdSaidaIngre"].ToString()),
                        CodigoBarras = new Ingrediente().SelecionaCodigoBarras(decimal.Parse(registros["CodigoBarras"].ToString())),
                        CPFfunc = new Funcionario().SelecionaComCPFFunc(decimal.Parse(registros["CPFfunc"].ToString())),
                        Nome = new Ingrediente().SelecionaNome(registros["Nome"].ToString()),
                        QtdUsada = int.Parse(registros["QtdUsada"].ToString()),
                        DataHoraSaida = DateTime.Parse(registros["DataHoraSaida"].ToString())
                    };
                    saidaList.Add(SaidaTemporaria);
                }
                return saidaList;
            }
        }

        public Saida_ingre SelecionaIdSaida(int IdSaida)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbsaida_ingre where IdSaidaIngre = '{0}';", IdSaida);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Saida_ingre saidaListando = null;
                while (registros.Read())
                {
                    saidaListando = new Saida_ingre
                    {
                        IdSaidaIngre = int.Parse(registros["IdSaidaIngre"].ToString()),
                        CodigoBarras = new Ingrediente().SelecionaCodigoBarras(decimal.Parse(registros["CodigoBarras"].ToString())),
                        CPFfunc = new Funcionario().SelecionaComCPFFunc(decimal.Parse(registros["CPFfunc"].ToString())),
                        Nome = new Ingrediente().SelecionaNome(registros["Nome"].ToString()),
                        QtdUsada = int.Parse(registros["QtdUsada"].ToString()),
                        DataHoraSaida = DateTime.Parse(registros["DataHoraSaida"].ToString())
                    };
                }

                return saidaListando;
            }

        }


    }
}