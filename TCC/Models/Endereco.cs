using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Endereco
    {

        private ConexaoDB db = new ConexaoDB();


        [Required(ErrorMessage = "O campo CEP é requerido.")]
        [Display(Name = "CEP")]
        //[RegularExpression(@"^[0-9]{5}-[\d]{3}|(\d{8})$", ErrorMessage = "CEP invalido.")]
        public decimal CEP { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é requerido.")]
        [Display(Name = "Logradouro")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200,ErrorMessage = "A quantidade de caracteres do Logradouro é invalido.")]
        public string Logra { get; set; }

        [Required(ErrorMessage = "O campo Bairro é requerido.")]
        [Display(Name = "Bairro")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Bairro é invalido.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é requerido.")]
        [Display(Name = "Cidade")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Cidade é invalido.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é requerido.")]
        [Display(Name = "Estado")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Estado é invalido.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo UF é requerido.")]
        [Display(Name = "UF")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        public string UF { get; set; }


        public Endereco RetornaPorCEP(decimal CEP)
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
                        CEP = decimal.Parse(registros["CEP"].ToString()),
                        Logra = registros["Logra"].ToString(),
                        Bairro = registros["Bairro"].ToString(),
                        Cidade = registros["Cidade"].ToString(),
                        Estado = registros["Estado"].ToString(),
                        UF = registros["UF"].ToString()
                    };
                }

                return EnderecoListando;
            }

        }

    }
}