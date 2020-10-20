using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class ConexaoDB : IDisposable
    {
        private readonly MySqlConnection conexao;

        public ConexaoDB()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string StrQuery)
        {
            var vComando = new MySqlCommand
            {

                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader ExecutaRegistro(string StrQuery)
        {
            var vComando = new MySqlCommand
            {

                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return vComando.ExecuteReader();
        }

        public string ExecutaDado(string StrQuery)
        {
            var vComando = new MySqlCommand
            {

                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };

            string result;
            result = (string)vComando.ExecuteScalar();

            if (result == null)
            {
                return result = "";
                // ou esse -> return "";
            }

            return result;
        }

        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}