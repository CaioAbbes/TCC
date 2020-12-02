using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Ingrediente
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Codigo de barras é requerido.")]
        [Display(Name = "Codigo de barras")]
        [StringLength(13,ErrorMessage = "A quantidade de caracteres do CodigoBarras é invalido.",MinimumLength = 13)]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido.")]
        [Display(Name = "Nome")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50,ErrorMessage = "A quantidade de caracteres do Nome é invalido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Unidade de medida é requerido.")]
        [Display(Name = "Unidade de medida")]
        //[RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Unidade de medida é invalido.")]
        public string UniMedi { get; set; }

        [Required(ErrorMessage = "O campo Preço unitário é requerido.")]
        [Display(Name = "Preço unitário")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        public float PrecoUnit { get; set; }

        [Required(ErrorMessage = "O campo Quantidade atual é requerido.")]
        [Display(Name = "Quantidade atual")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdAtual { get; set; }

        [Display(Name = "Tempo de duração")]
       // [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(20, ErrorMessage = "A quantidade de caracteres do Tempo de duração é invalido.")]
        public string TempDura { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataValidade { get; set; }

        [Display(Name = "Marca")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres da Marca é invalido.")]
        public string Marca { get; set; }


        public void InsertIngrediente(Ingrediente ingrediente)
        {
            string strQuery = string.Format("call sp_InsEstoque('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", ingrediente.CodigoBarras, ingrediente.Nome, ingrediente.UniMedi, ingrediente.PrecoUnit.ToString().Replace(",", "."), ingrediente.QtdAtual, ingrediente.Marca, ingrediente.DataValidade);
            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }

        }

        public List<Ingrediente> SelecionaIngrediente()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("SELECT * FROM tbingrediente;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var ingredienteList = new List<Ingrediente>();
                while (registros.Read())
                {
                    string date = registros["DataValidade"].ToString();
                    string tempdura = registros["TempDura"].ToString();
                    string marca = registros["Marca"].ToString();
                    var IngredienteTemporario = new Ingrediente
                    {
                        CodigoBarras = registros["CodigoBarras"].ToString(),
                        Nome = registros["Nome"].ToString(),
                        UniMedi = registros["UniMedi"].ToString(),
                        PrecoUnit = float.Parse(registros["PrecoUnit"].ToString()),
                        QtdAtual = int.Parse(registros["QtdAtual"].ToString()),
                        TempDura =  tempdura.Equals("") ? "Não há tempo de duração" : registros["TempDura"].ToString(),
                        DataValidade = date.Equals("") ? (DateTime?) null : DateTime.Parse(registros["DataValidade"].ToString()),
                        Marca = marca.Equals("") ? "Não há marca" : registros["Marca"].ToString()
                    };
                    ingredienteList.Add(IngredienteTemporario);
                }
                return ingredienteList;
            }
        }




        public string SelecionaCodigoBarras(string CodigoBarras)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select CodigoBarras from tbingrediente where CodigoBarras = '{0}';", CodigoBarras);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Ingrediente ingredientesListando = null;
                while (registros.Read())
                {
                    ingredientesListando = new Ingrediente
                    {
                        CodigoBarras = registros["CodigoBarras"].ToString()
                    };
                }

                return CodigoBarras;
            }

        }

        public string SelecionaNome(string Nome)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select Nome from tbingrediente where Nome = '{0}';", Nome);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Ingrediente ingredientesListando = null;
                while (registros.Read())
                {
                    ingredientesListando = new Ingrediente
                    {
                        Nome = registros["Nome"].ToString()
                    };
                }

                return Nome;
            }

        }
    }
}