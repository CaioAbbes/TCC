using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCC.Models
{
    public class Usuario
    {

        private ConexaoDB db = new ConexaoDB();


        //[Required(ErrorMessage = "O campo Id do usuário é requerido.")]
        [Display(Name = "Id do usuário")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo Usuário é requerido.")]
        [Display(Name = "Usuário")]
        public string UsuarioText { get; set; }

        [Required(ErrorMessage = "O campo Senha é requerido.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo Tipo de acesso é requerido.")]
        [Display(Name = "Tipo de acesso")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public decimal TipoAcesso { get; set; }

        public Usuario RetornaPorIdUsuario(int idUsu)
        {
            System.Diagnostics.Debug.WriteLine(idUsu);
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbusuario where IdUsuario = '{0}';", idUsu);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Usuario UserListando = null;
                while (registros.Read())
                {
                    UserListando = new Usuario
                    {
                        IdUsuario = int.Parse(registros["IdUsuario"].ToString()),
                        UsuarioText = registros["Usuario"].ToString(),
                        Senha = registros["Senha"].ToString(),
                        TipoAcesso = decimal.Parse(registros["TipoAcesso"].ToString())
                    };

                }

                return UserListando;
            }

        }


    }
}