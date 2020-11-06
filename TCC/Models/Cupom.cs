using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Cupom
    {
        private ConexaoDB db;

        [StringLength(6,ErrorMessage = "o numero de caracteres do Código do cupom é invalido ")]
        [Required(ErrorMessage = "O campo Código do cupom é requerido")]
        [Display(Name = "Código do cupom")]
        //[RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente números")]
        public string CodCupom { get; set; }

        [Required(ErrorMessage = "O campo Desconto é requerido")]
        [Display(Name = "Desconto")]
        //[RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        public float Desconto { get; set; }


        public void InsertCupom(Cupom cupom)
        {
            string strQuery = string.Format("call sp_InsCupom('{0}','{1}');",cupom.CodCupom,cupom.Desconto.ToString().Replace(",","."));

            using(db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Cupom> SelecionaCupom()
        {
            using (db = new ConexaoDB())
            {

                string StrQuery = string.Format("select * from tbcupom;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var cupomList = new List<Cupom>();
                while (registros.Read())
                {
                    var CupomTemporario = new Cupom
                    {
                        CodCupom = registros["CodCupom"].ToString(),
                        Desconto = float.Parse(registros["desconto"].ToString())
                    };

                    cupomList.Add(CupomTemporario);
                }
                return cupomList;
            }

        }


        public Cupom SelecionaComIdCupom(string CodCupom)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcupom where CodCupom = '{0}';", CodCupom);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Cupom CupomListando = null;
                while (registros.Read())
                {
                    CupomListando = new Cupom
                    {
                        CodCupom = registros["CodCupom"].ToString(),
                        Desconto = float.Parse(registros["desconto"].ToString())
                    };
                }

                return CupomListando;
            }

        }
    }
}