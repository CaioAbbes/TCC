using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TCC.Models
{
    public class CupomUsa
    {

        private ConexaoDB db;

        [Required(ErrorMessage = "O Codigo cupom é requerido")]
        [Display(Name = "Codigo cupom")]
        //[RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(6, ErrorMessage = "A quantidade de caracteres do Codigo cupom é invalido.")]
        private string CodCupom { get; set; }

        private Cliente Cliente { get; set; }


        public List<CupomUsa> SelecionaCupomUsa()
        {
            using (db = new ConexaoDB())
            {

                string StrQuery = string.Format("select * from tbcupomusa;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var ClicupomList = new List<CupomUsa>();
                while (registros.Read())
                {
                    var ClicupomTemporario = new CupomUsa
                    {
                        CodCupom = registros["CodCupom"].ToString(),
                        Cliente = new Cliente().SelecionaComIdCli(int.Parse(registros["IdCli"].ToString())),
                    };

                    ClicupomList.Add(ClicupomTemporario);
                }
                return ClicupomList;
            }

        }


        public CupomUsa SelecionaComIdCupomUsa(string CodCupom)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcupomusa where CodCupom = '{0}';", CodCupom);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                CupomUsa ClicupomListando = null;
                while (registros.Read())
                {
                    ClicupomListando = new CupomUsa
                    {
                        CodCupom = registros["CodCupom"].ToString(),
                        Cliente = new Cliente().SelecionaComIdCli(int.Parse(registros["IdCli"].ToString())),
                    };
                }

                return ClicupomListando;
            }

        }

    }
}