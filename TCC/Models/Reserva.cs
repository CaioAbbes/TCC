using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Reserva
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Número da reserva é requerido.")]
        [Display(Name = "Número da reserva")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdReserva { get; set; }

        //[Display(Name = "Id da mesa")]
        //[Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        //public int IdMesa { get; set; }

        public Mesa Mesa { get; set; }

        //[Required(ErrorMessage = "O campo Id do Cliente é requerido.")]
        //[Display(Name = "Id do Cliente")]
        //public decimal IdCli { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "O campo Data e hora da reserva é requerido.")]
        [Display(Name = "Data e hora da reserva")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataHoraReserva { get; set; }

        //[Required(ErrorMessage = "O campo Data e hora que quero come é requerido.")]
        //[Display(Name = "Data e hora que quero comer")]
        //[DataType(DataType.DateTime)]
        //public DateTime HoraQueroComer { get; set; }

        public void InsertReserva(Reserva reserva,int idCli)
        {
            string strQuery = string.Format("call sp_InsReserva('{0}','{1}','{2}','{3}');", idCli, reserva.DataHoraReserva.ToString("yyyy-MM-dd HH:mm"),reserva.Mesa.Numlugares,reserva.Mesa.TipoLugar);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Reserva> SelecionaReserva()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbreserva;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var reservaList = new List<Reserva>();
                while (registros.Read())
                {
                    var ReservaTemporaria = new Reserva
                    {
                        IdReserva = int.Parse(registros["IdReserva"].ToString()),
                        Mesa = new Mesa().SelecionaIdMesa(int.Parse(registros["IdMesa"].ToString())),
                        Cliente = new Cliente().SelecionaIdCli(int.Parse(registros["IdCli"].ToString())),
                        DataHoraReserva = DateTime.Parse(registros["DataHoraReserva"].ToString()),
                        //HoraQueroComer = DateTime.Parse(registros["DataQueroComer"].ToString())
                    };
                    reservaList.Add(ReservaTemporaria);
                }
                return reservaList;
            }
        }

        public Reserva SelecionaIdReserva(int IdReserva)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbreserva where IdReserva = '{0}';", IdReserva);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Reserva reservaListando = null;
                while (registros.Read())
                {
                    reservaListando = new Reserva
                    {
                        IdReserva = int.Parse(registros["IdReserva"].ToString()),
                        Mesa = new Mesa().SelecionaIdMesa(int.Parse(registros["IdMesa"].ToString())),
                        Cliente = new Cliente().SelecionaIdCli(int.Parse(registros["IdCli"].ToString())),
                        DataHoraReserva = DateTime.Parse(registros["DataHoraReserva"].ToString()),
                    };
                }

                return reservaListando;
            }

        }
    }
}