﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Fornecedor
    {

        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Id do fornecedor é requerido.")]
        [Display(Name = "Id do fornecedor")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "O campo Razao Social é requerido.")]
        [Display(Name = "Razao Social")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Razao Social é invalido.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo Nome do fornecedor é requerido.")]
        [Display(Name = "Nome do fornecedor")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Nome do fornecedor é invalido.")]
        public string NomeForn { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é requerido.")]
        [Display(Name = "CNPJ")]
        [StringLength(17,ErrorMessage = "A quantidade de caracteres do CNPJ é invalido.",MinimumLength = 14)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Celular do Fornecedo é requerido.")]
        [Display(Name = "Celular do Fornecedor")]
        public int Tel { get; set; }

        [RegularExpression(@"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$", ErrorMessage = "O Email do fornecedor está incorreto")]
        [Display(Name = "Email do fornecedor")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Email do fornecedorr é invalido.")]
        public string EmailForn { get; set; }

        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [Display(Name = "Complemento")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Complemento é invalido.")]
        public string Comp { get; set; }

        [Required(ErrorMessage = "O campo Numero do edifício é requerido")]
        [Display(Name = "Numero do edifício")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public int NumEdif { get; set; }

        public Endereco Endereco { get; set; }


        public void InsertFornecedor(Fornecedor fornecedor)
        {
            string strQuery = string.Format("CALL sp_InsForne('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');",fornecedor.RazaoSocial,fornecedor.NomeForn,fornecedor.Cnpj.Replace(".",string.Empty).Replace("/",string.Empty).Replace("-",string.Empty),fornecedor.Tel.ToString().Replace("(",string.Empty).Replace(")",string.Empty).Replace(" ",string.Empty),fornecedor.EmailForn, fornecedor.Endereco.Cidade,fornecedor.Endereco.CEP,fornecedor.Endereco.Logra,fornecedor.Endereco.Bairro,fornecedor.Comp,fornecedor.NumEdif);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateFornecedor(Fornecedor fornecedor)
        {
            using (db = new ConexaoDB())
            {
                string strQuery = string.Format("CALL sp_AtuaForn('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');",fornecedor.IdForn, fornecedor.RazaoSocial,fornecedor.NomeForn,fornecedor.Cnpj.Replace(".", string.Empty).Replace("/", string.Empty).Replace("-", string.Empty), fornecedor.Endereco.CEP,fornecedor.Tel.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty), fornecedor.EmailForn,fornecedor.Comp,fornecedor.NumEdif,fornecedor.Endereco.Logra,fornecedor.Endereco.Bairro,fornecedor.Endereco.Cidade);

                db.ExecutaComando(strQuery);
            }

        }

        public List<Fornecedor> SelecionaFornecedor()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbfornecedor;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var FornecedorList = new List<Fornecedor>();
                while (registros.Read())
                {
                    string email = registros["EmailForn"].ToString();
                    string comp = registros["Comp"].ToString();
                    string numedif = registros["NumEdif"].ToString();
                    var FornecedorTemporario = new Fornecedor
                    {
                        IdForn = int.Parse(registros["IdForn"].ToString()),
                        RazaoSocial = registros["RazaoSocial"].ToString(),
                        NomeForn = registros["NomeForn"].ToString(),
                        Cnpj = registros["Cnpj"].ToString(),
                        Endereco = new Endereco().RetornaPorCEP(registros["CEP"].ToString()),
                        Tel = int.Parse(registros["Tel"].ToString()),
                        EmailForn = email.Equals("") ? "Não há E-mail" : registros["EmailForn"].ToString(),
                        Comp = comp.Equals("") ? "Sem complemento" : registros["Comp"].ToString(),
                        NumEdif = numedif.Equals("") ? 0 : int.Parse(registros["NumEdif"].ToString()),
                    };
                    FornecedorList.Add(FornecedorTemporario);
                }
                return FornecedorList;
            }
        }

        public Fornecedor SelecionaComIdForn(int IdForn)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbfornecedor where IdForn = '{0}';", IdForn);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Fornecedor FornListando = null;
                while (registros.Read())
                {
                    string email = registros["EmailForn"].ToString();
                    string comp = registros["Comp"].ToString();
                    string numedif = registros["NumEdif"].ToString();
                    FornListando = new Fornecedor
                    {
                        IdForn = int.Parse(registros["IdForn"].ToString()),
                        RazaoSocial = registros["RazaoSocial"].ToString(),
                        NomeForn = registros["NomeForn"].ToString(),
                        Cnpj = registros["Cnpj"].ToString(),
                        Endereco = new Endereco().RetornaPorCEP(registros["CEP"].ToString()),
                        Tel = int.Parse(registros["Tel"].ToString()),
                        EmailForn = email.Equals("") ? "Não há E-mail" : registros["EmailForn"].ToString(),
                        Comp = comp.Equals("") ? "Sem complemento" : registros["Comp"].ToString(),
                        NumEdif = numedif.Equals("") ? 0 : int.Parse(registros["NumEdif"].ToString()),
                    };
                }

                return FornListando;
            }

        }

        public string SelecionaComNomeForn(string NomeForn)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select NomeForn from tbfornecedor where NomeForn = '{0}';", NomeForn);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Fornecedor FornListando = null;
                while (registros.Read())
                {
                    FornListando = new Fornecedor
                    {
                        NomeForn = registros["NomeForn"].ToString()
                    };
                }

                return NomeForn;
            }

        }

    }
}