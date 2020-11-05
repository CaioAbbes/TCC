using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Mesa
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Id da mesa é requerido.")]
        [Display(Name = "Id da mesa")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdMesa { get; set; }

        [Required(ErrorMessage = "O campo Numero de lugares é requerido.")]
        [Display(Name = "Numero de lugares")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int Numlugares { get; set; }

        [Required(ErrorMessage = "O campo Disponivel é requerido.")]
        [Display(Name = "Disponivel")]
        public bool Disponi { get; set; }

        [Required(ErrorMessage = "O campo Tipo de lugar é requerido.")]
        [Display(Name = "Tipo de lugar")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Tipo de lugar é invalido.")]
        public string TipoLugar { get; set; }

        public void InsertMesa(Mesa mesa)
        {
            string strQuery = string.Format("call sp_InsMesa('{0}','{1}');",mesa.Numlugares,mesa.TipoLugar);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateMesa(Mesa mesa)
        {
            string strQuery = string.Format("call sp_AtuaaMesa('{0}');", mesa.IdMesa);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Mesa> SelecionaMesa()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbmesa;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var mesaList = new List<Mesa>();
                while (registros.Read())
                {
                    var MesaTemporaria = new Mesa
                    {
                        IdMesa = int.Parse(registros["IdMesa"].ToString()),
                        Numlugares = int.Parse(registros["Numlugares"].ToString()),
                        Disponi = bool.Parse(registros["Disponi"].ToString()),
                        TipoLugar = registros["TipoLugar"].ToString()
                    };
                    mesaList.Add(MesaTemporaria);
                }
                return mesaList;
            }
        }

        public Mesa SelecionaIdMesa(int IdMesa)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbmesa where IdMesa = '{0}';", IdMesa);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Mesa mesaListando = null;
                while (registros.Read())
                {
                    mesaListando = new Mesa
                    {
                        IdMesa = int.Parse(registros["IdMesa"].ToString()),
                        Numlugares = int.Parse(registros["Numlugares"].ToString()),
                        Disponi = bool.Parse(registros["Disponi"].ToString()),
                        TipoLugar = registros["TipoLugar"].ToString()
                    };
                }

                return mesaListando;
            }

        }



    }
}