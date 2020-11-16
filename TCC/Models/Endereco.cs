using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace TCC.Models
{
    public class Endereco
    {

        private ConexaoDB db;


        [Required(ErrorMessage = "O campo CEP é requerido.")]
        [Display(Name = "CEP")]
        [Remote("BuscaCEP", "Cliente",ErrorMessage = "CEP não encontrado")]
        [StringLength(8,ErrorMessage = "A quantidade de caracteres do CEP é invalido.",MinimumLength = 8)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é requerido.")]
        [Display(Name = "Logradouro")]
        [StringLength(200,ErrorMessage = "A quantidade de caracteres do Logradouro é invalido.")]
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

        [Required(ErrorMessage = "O campo Estado é requerido.")]
        [Display(Name = "Estado")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Estado é invalido.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo UF é requerido.")]
        [Display(Name = "UF")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        public string UF { get; set; }


        public List<Endereco> BuscaCEP(string cep)
        {
            var CepObj = new Endereco();
            var CepList = new List<Endereco>();
            var url = "https://ws.apicep.com/busca-cep/api/cep.json?code=" + cep;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            string json = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            JsonCepObject cepJson = javaScriptSerializer.Deserialize<JsonCepObject>(json);


            CepObj.CEP = cepJson.code.Replace("-",string.Empty);
            CepObj.Logra = cepJson.address;
            CepObj.Bairro = cepJson.district;
            CepObj.Cidade = cepJson.city;
            CepObj.Estado = cepJson.state;

            //CEP = decimal.Parse(cepJson.code.Replace("-", string.Empty));
            //Logra = cepJson.address;
            //Bairro = cepJson.district;
            //Cidade = cepJson.city;
            //Estado = cepJson.state;

            CepList.Add(CepObj);

            return CepList;
        }

        public class JsonCepObject
        {
            public string code { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string address { get; set; }

        }


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
                        CEP = registros["CEP"].ToString(),
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