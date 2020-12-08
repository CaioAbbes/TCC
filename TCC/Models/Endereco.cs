using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Endereco
    {

        private ConexaoDB db;


        [Required(ErrorMessage = "O campo CEP é requerido.")]
        [Display(Name = "CEP")]
        [StringLength(9, ErrorMessage = "A quantidade de caracteres do CEP é invalido.", MinimumLength = 9)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é requerido.")]
        [Display(Name = "Logradouro")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Logradouro é invalido.")]
        public string Logra { get; set; }

        [Required(ErrorMessage = "O campo Bairro é requerido.")]
        [Display(Name = "Bairro")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Bairro é invalido.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é requerido.")]
        [Display(Name = "Cidade")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Cidade é invalido.")]
        public string Cidade { get; set; }

        public Endereco RetornaPorCEP(string CEP)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbendereco where CEP = '{0}';", CEP);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Endereco EnderecoListando = null;
                while (registros.Read())
                {
                    EnderecoListando = new Endereco
                    {
                        CEP = registros["CEP"].ToString(),
                        Logra = registros["Logra"].ToString(),
                        Bairro = registros["Bairro"].ToString(),
                        Cidade = registros["Cidade"].ToString(),
                    };
                }

                return EnderecoListando;
            }

        }




    }
}