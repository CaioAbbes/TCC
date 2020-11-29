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
        [StringLength(10, ErrorMessage = "A quantidade de caracteres do CEP é invalido.", MinimumLength = 10)]
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

        ////[Required(ErrorMessage = "O campo Estado é requerido.")]
        //[Display(Name = "Estado")]
        //[RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        //[StringLength(100, ErrorMessage = "A quantidade de caracteres do Estado é invalido.")]
        //public string Estado { get; set; }

        ////[Required(ErrorMessage = "O campo UF é requerido.")]
        //[Display(Name = "UF")]
        //[RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        //public string UF { get; set; }


        //public List<Endereco> BuscaCEP(string cep)
        //{
        //    var CepObj = new Endereco();
        //    var CepList = new List<Endereco>();
        //    // var url = "https://ws.apicep.com/busca-cep/api/cep.json?code=" + cep;
        //    var url = string.Format("https://viacep.com.br/ws/{0}/json/", cep);
        //    //var url = string.Format("https://viacep.com.br/ws/{0}/json/?callback=?",cep);
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

        //    string json = string.Empty;
        //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    using (Stream stream = response.GetResponseStream())
        //    using (StreamReader reader = new StreamReader(stream))
        //    {
        //        json = reader.ReadToEnd();
        //    }

        //    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        //    JsonCepObject cepJson = javaScriptSerializer.Deserialize<JsonCepObject>(json);

        //    CepObj.CEP = cepJson.cep.Replace("-", string.Empty);
        //    CepObj.Logra = cepJson.logradouro;
        //    CepObj.Bairro = cepJson.bairro;
        //    CepObj.Cidade = cepJson.localidade;
        //    CepObj.UF = cepJson.uf;

        //    CepList.Add(CepObj);
        //    return CepList;
        //}

        //public class JsonCepObject
        //{
        //    public string cep { get; set; }
        //    public string logradouro { get; set; }
        //    public string bairro { get; set; }
        //    public string localidade { get; set; }
        //    public string uf { get; set; }
        //}


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
                    };
                }

                return EnderecoListando;
            }

        }




    }
}