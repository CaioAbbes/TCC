using Microsoft.Build.Framework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Clicupom
    {

        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Codigo cupom é requerido.")]
        [Display(Name = "Codigo cupom")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(6, ErrorMessage = "A quantidade de caracteres do Codigo cupom é invalido.")]
        public string CodCupom { get; set; }

        //[Required(ErrorMessage = "O campo CPF é requerido.")]
        //[Display(Name = "CPF")]
        //[RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        //public decimal CPF { get; set; }

        public Cliente Cliente { get; set; }

        [Display(Name = "Liberado")]
        public bool Liberado { get; set; }


        public void UpdateClicupom(Clicupom Clicupom)
        {
            string strQuery = string.Format("call sp_RenoCupom('{0}');", Clicupom.CodCupom);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Clicupom> SelecionaClicupom()
        {
            using (db = new ConexaoDB())
            {

                string StrQuery = string.Format("select * from tbcupom;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var ClicupomList = new List<Clicupom>();
                while (registros.Read())
                {
                    var ClicupomTemporario = new Clicupom
                    {
                        CodCupom = registros["CodCupom"].ToString(),
                        Cliente = new Cliente().SelecionaComIdCli(int.Parse(registros["IdCli"].ToString())),
                        Liberado = bool.Parse(registros["liberado"].ToString())
                    };

                    ClicupomList.Add(ClicupomTemporario);
                }
                return ClicupomList;
            }

        }


        public Clicupom SelecionaComIdClicupom(string CodCupom)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbclicupom where CodCupom = '{0}';", CodCupom);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Clicupom ClicupomListando = null;
                while (registros.Read())
                {
                    ClicupomListando = new Clicupom
                    {
                        CodCupom = registros["CodCupom"].ToString(),
                        Cliente = new Cliente().SelecionaComIdCli(int.Parse(registros["IdCli"].ToString())),
                        Liberado = bool.Parse(registros["liberado"].ToString())
                    };
                }

                return ClicupomListando;
            }

        }

    }
}