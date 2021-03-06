﻿using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Usuario
    {

        private ConexaoDB db;


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

        [Required(ErrorMessage = "O campo Confirmar Senha é requerido.")]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmaSenha { get; set; }

        [Required(ErrorMessage = "O campo Tipo de acesso é requerido.")]
        [Display(Name = "Tipo de acesso")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public int TipoAcesso { get; set; }

        public Usuario RetornaPorIdUsuario(int idUsu)
        {
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
                        TipoAcesso = int.Parse(registros["TipoAcesso"].ToString())
                    };

                }

                return UserListando;
            }

        }

        public bool ValidaLogin()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbusuario where Usuario = '{0}' and Senha = '{1}';", UsuarioText, Senha);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                if (registros.HasRows)
                {
                    while (registros.Read())
                    {
                        UsuarioText = registros["Usuario"].ToString();
                        Senha = registros["Senha"].ToString();

                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public int RetornaTipoAcesso()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select TipoAcesso from tbusuario where Usuario = '{0}';", UsuarioText);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                while (registros.Read())
                {
                    TipoAcesso = int.Parse(registros["TipoAcesso"].ToString());

                }
                return TipoAcesso;
            }

        }

        public int PegaIdCli()
        {

            using (db = new ConexaoDB())
            {
                string strQuery = string.Format("CALL sp_BuscaIdC('{0}');", UsuarioText);
                MySqlDataReader registros = db.RetornaRegistro(strQuery);
                Cliente clienteListando = new Cliente();
                while (registros.Read())
                {
                  
                    clienteListando = new Cliente
                    {
                        IdCli = int.Parse(registros["IdCli"].ToString())
                    };

                }
                if (clienteListando.IdCli == 0)
                {
                    return 0;
                }
                return clienteListando.IdCli;

            }
        }

        public int PegaIdFunc()
        {

            using (db = new ConexaoDB())
            {
                string strQuery = string.Format("CALL sp_BuscaIdF('{0}');", UsuarioText);
                MySqlDataReader registros = db.RetornaRegistro(strQuery);
                Funcionario funcionarioListando = new Funcionario();
                while (registros.Read())
                {
                    funcionarioListando = new Funcionario
                    {
                        IdFunc = int.Parse(registros["IdFunc"].ToString())
                    };

                }
                if (funcionarioListando.IdFunc == 0)
                {
                    return 0;
                }
                return funcionarioListando.IdFunc;

            }
        }

    }
}