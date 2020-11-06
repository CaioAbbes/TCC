﻿using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Ubiety.Dns.Core;

namespace TCC.Models
{
    public class Funcionario
    {

        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Id do funcionário é requerido.")]
        [Display(Name = "Id do funcionário")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        [Key]
        public int IdFunc { get; set; }

        [Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        [Display(Name = "CPF do funcionário.")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPFfunc { get; set; }

        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "O campo Nome do funcionário é requerido.")]
        [Display(Name = "Nome do funcionário")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome do funcionário é invalido.")]
        public string NomeFunc { get; set; }

        [Required(ErrorMessage = "O campo Data de nascimento do funcionário é requerido.")]
        [Display(Name = "Data de nascimento do funcionário")]
        [DataType(DataType.Date)]
        public DateTime DatNascFunc { get; set; }

        [Required(ErrorMessage = "O campo Cargo do funcionário é requerido.")]
        [Display(Name = "Cargo do funcionário")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(25, ErrorMessage = "A quantidade de caracteres do Cargo do funcionário é invalido.")]
        public string CargoFunc { get; set; }

        [Required(ErrorMessage = "O campo Sexo do funcionário é requerido.")]
        [Display(Name = "Sexo do funcionário")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(1, ErrorMessage = "A quantidade de caracteres do Sexo do funcionário é invalido.")]
        public string SexoFunc { get; set; }

        [Required(ErrorMessage = "O campo Celular do funcionário é requerido.")]
        [Display(Name = "Celular do funcionário")]
        //[RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Celular do Funcionário inválido")]
        public long CelFunc { get; set; }

        [Required(ErrorMessage = "O campo Email do funcionário é requerido.")]
        [RegularExpression(@"^[-a-zA-Z0-9][-.a-zA-Z0-9]@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$", ErrorMessage = "O Email do funcionário está incorreto.")]
        [Display(Name = "Email do funcionário")]
        [StringLength(60, ErrorMessage = "A quantidade de caracteres do Email do funcionário é invalido.")]
        public string EmailFunc { get; set; }

        [Required(ErrorMessage = "O campo RG do funcionário é requerido.")]
        [Display(Name = "RG do funcionário")]
        [RegularExpression(@"^(\d{1,2})(\d{3})(\d{3})(\d{1})$", ErrorMessage = "RG do funcionário invalido")]
        [StringLength(9, ErrorMessage = "A quantidade de caracteres do RG do funcionário é invalido.")]
        public string RgFunc { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite somente letras.")]
        [Display(Name = "Complemento")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Complemento é invalido.")]
        public string Comp { get; set; }

        [Required(ErrorMessage = "O campo Número do edifício é requerido.")]
        [Display(Name = "Nuúmero do edifício")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public int NumEdif { get; set; }

        public Usuario User { get; set; }


        public void InsertFuncionario(Funcionario funcionario)
        {
            string strQuery = string.Format("CALL sp_InsFuncEndUsu ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}');", funcionario.User.UsuarioText, funcionario.User.Senha, funcionario.Endereco.UF, funcionario.Endereco.Cidade, funcionario.Endereco.CEP, funcionario.Endereco.Logra, funcionario.Endereco.Bairro, funcionario.Comp, funcionario.NumEdif, funcionario.NomeFunc, funcionario.DatNascFunc.ToString("yyyy-MM-dd"), funcionario.CargoFunc, funcionario.SexoFunc, funcionario.CelFunc, funcionario.EmailFunc, funcionario.RgFunc, funcionario.CPFfunc, funcionario.Endereco.Estado, funcionario.User.TipoAcesso);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            string strQuery = string.Format("CALL sp_AtuaFunc('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}');", funcionario.IdFunc, funcionario.CPFfunc, funcionario.Endereco.CEP, funcionario.NomeFunc, funcionario.DatNascFunc.ToString("yyyy-MM-dd"), funcionario.CargoFunc, funcionario.SexoFunc, funcionario.CelFunc, funcionario.EmailFunc, funcionario.RgFunc, funcionario.Comp, funcionario.NumEdif, funcionario.Endereco.Logra, funcionario.Endereco.Bairro, funcionario.Endereco.Cidade, funcionario.Endereco.Estado, funcionario.Endereco.UF, funcionario.User.UsuarioText, funcionario.User.Senha);


            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }



        public List<Funcionario> SelecionaFuncionario()
        {
            using (db = new ConexaoDB())
            {

                string StrQuery = string.Format("select * from tbfuncionario;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                int a;
                var funcionarioList = new List<Funcionario>();
                var usuTemp = new Usuario
                {
                    IdUsuario = 0,
                    UsuarioText = "",
                    Senha = ""
                };
                while (registros.Read())
                {
                    string idUser = registros["IdUsuario"].ToString();
                    var FuncionarioTemporario = new Funcionario
                    {
                        IdFunc = int.Parse(registros["IdFunc"].ToString()),
                        Endereco = new Endereco().RetornaPorCEP(decimal.Parse(registros["CEP"].ToString())),
                        NomeFunc = registros["NomeFunc"].ToString(),
                        CPFfunc = decimal.Parse(registros["CPFfunc"].ToString()),
                        DatNascFunc = DateTime.Parse(registros["DatNascFunc"].ToString()),
                        CargoFunc = registros["CargoFunc"].ToString(),
                        SexoFunc = registros["SexoFunc"].ToString(),
                        CelFunc = Convert.ToInt64(registros["CelFunc"].ToString()),
                        EmailFunc = registros["EmailFunc"].ToString(),
                        RgFunc = registros["RgFunc"].ToString(),
                        Comp = registros["Comp"].ToString(),
                        NumEdif = int.Parse(registros["NumEdif"].ToString()),
                        User = idUser != "" ? new Usuario().RetornaPorIdUsuario(int.Parse(idUser)) : usuTemp
                    };

                    funcionarioList.Add(FuncionarioTemporario);
                }
                //db.Dispose();
                return funcionarioList;
            }

        }


        public Funcionario SelecionaComIdFunc(int IdFunc)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbfuncionario where IdFunc = '{0}';", IdFunc);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Funcionario FuncListando = null;
                while (registros.Read())
                {
                    FuncListando = new Funcionario
                    {
                        IdFunc = int.Parse(registros["IdFunc"].ToString()),
                        Endereco = new Endereco().RetornaPorCEP(decimal.Parse(registros["CEP"].ToString())),
                        User = new Usuario().RetornaPorIdUsuario(int.Parse(registros["IdUsuario"].ToString())),
                        NomeFunc = registros["NomeFunc"].ToString(),
                        CPFfunc = decimal.Parse(registros["CPFfunc"].ToString()),
                        DatNascFunc = DateTime.Parse(registros["DatNascFunc"].ToString()),
                        CargoFunc = registros["CargoFunc"].ToString(),
                        SexoFunc = registros["SexoFunc"].ToString(),
                        CelFunc = Convert.ToInt64(registros["CelFunc"].ToString()),
                        EmailFunc = registros["EmailFunc"].ToString(),
                        RgFunc = registros["RgFunc"].ToString(),
                        Comp = registros["Comp"].ToString(),
                        NumEdif = int.Parse(registros["NumEdif"].ToString())
                    };
                }

                return FuncListando;
            }

        }

        //public int PegarIdFunc(int IdFunc)
        //{
        //    using (db = new ConexaoDB())
        //    {
        //        string StrQuery = string.Format("select IdFunc from tbfuncionario where IdFunc = '{0}';", IdFunc);
        //        MySqlDataReader registros = db.RetornaRegistro(StrQuery);
        //        while (registros.Read())
        //        {
        //            IdFunc = int.Parse(registros["IdFunc"].ToString());
        //        }

        //        return IdFunc;
        //    }

        //}


    }


}
