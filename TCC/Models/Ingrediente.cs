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
        [Range(0, double.MaxValue, ErrorMessage = "Deve ser positivo")]
        private decimal CodigoBarras { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido.")]
        [Display(Name = "Nome")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50,ErrorMessage = "A quantidade de caracteres do Nome é invalido.")]
        private string Nome { get; set; }

        [Required(ErrorMessage = "O campo Unidade de medida é requerido.")]
        [Display(Name = "Unidade de medida")]
        //[RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Unidade de medida é invalido.")]
        private string UniMedi { get; set; }

        [Required(ErrorMessage = "O campo Preço unitário é requerido.")]
        [Display(Name = "Preço unitário")]
        //[RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        private float PrecoUnit { get; set; }

        [Required(ErrorMessage = "O campo Quantidade atual é requerido.")]
        [Display(Name = "Quantidade atual")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        private int QtdAtual { get; set; }

        [Display(Name = "Tempo de duração")]
       // [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(20, ErrorMessage = "A quantidade de caracteres do Tempo de duração é invalido.")]
        private string TempDura { get; set; }

        [Display(Name = "Data de validade")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        private DateTime DataValidade { get; set; }

        [Display(Name = "Marca")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres da Marca é invalido.")]
        private string Marca { get; set; }


        public void InsertIngrediente(Ingrediente ingrediente)
        {
            string strQuery = string.Format("call sp_InsEstoque('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');",ingrediente.CodigoBarras,ingrediente.Nome,ingrediente.UniMedi,ingrediente.PrecoUnit.ToString().Replace(",", "."), ingrediente.QtdAtual,ingrediente.Marca,ingrediente.DataValidade.ToString("yyyy-MM-dd HH:mm"),ingrediente.TempDura);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }

        }


        public decimal SelecionaCodigoBarras(decimal CodigoBarras)
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
                        CodigoBarras = decimal.Parse(registros["CodigoBarras"].ToString())
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