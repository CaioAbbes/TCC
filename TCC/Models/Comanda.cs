using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Comanda
    {

        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Id da comanda é requerido.")]
        [Display(Name = "Id da comanda")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        private int IdComanda { get; set; }

        [Display(Name = "Id do cliente")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        private Cliente Cliente { get; set; }

        [Display(Name = "Id da mesa")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        private Mesa Mesa { get; set; }

        [Required(ErrorMessage = "O campo Status da comanda é requerido")]
        [Display(Name = "Status da comanda")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        private string StatsComan { get; set; }

        [Required(ErrorMessage = "O campo Data e hora da comanda é requerido")]
        [Display(Name = "Data e hora da comanda")]
        [DisplayFormat(DataFormatString = "mm/DD/yyyy")]
        [DataType(DataType.DateTime)]
        private DateTime DataHComan { get; set; }

                public Comanda SelecionaIdComanda(int IdComanda)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select IdComanda from tbcomanda where IdComanda = '{0}';", IdComanda);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Comanda comandaListando = null;
                while (registros.Read())
                {
                    comandaListando = new Comanda
                    {
                        IdComanda = int.Parse(registros["IdComanda"].ToString())
                    };
                }

                return comandaListando;
            }

        }


    }
}