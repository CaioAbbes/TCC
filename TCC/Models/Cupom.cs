﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Cupom
    {
        private ConexaoDB db;

        [StringLength(6,ErrorMessage = "O numero de caracteres do Código do cupom é invalido ",MinimumLength = 6)]
        [Required(ErrorMessage = "O campo Código do cupom é requerido")]
        [Display(Name = "Código do cupom")]
        public string CodCupom { get; set; }


        [Required(ErrorMessage = "O campo Desconto é requerido")]
        [Display(Name = "Desconto")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float Desconto { get; set; }

        [Display(Name = "Total de cupons utilizados")]
        [Required(ErrorMessage = "O campo Total de cupons utilizados é requerido")]
        public int NumUtiliza { get; set; }

        [Display(Name = "Total de cupons disponiveis")]
        [Required(ErrorMessage = "O campo Total de cupons disponiveis é requerido")]
        public int TotalDispo { get; set; }

        [Display(Name = "Data e hora inicio do funcionamento do cupom")]
        [Required(ErrorMessage = "O campo Data e hora inicio do funcionamento do cupom é requerido")]
        [DataType(DataType.DateTime)]
        public DateTime DataInicio { get; set; }
        
        [Display(Name = "Data e hora termino do funcionamento do cupom")]
        [Required(ErrorMessage = "O campo Data e hora termino do funcionamento do cupom é requerido")]
        [DataType(DataType.DateTime)]
        public DateTime DataTerm { get; set; }

        [Display(Name = "Descrição do cupom")]
        [Required(ErrorMessage = "O campo Descrição do cupom é requerido")]
        [StringLength(500, ErrorMessage = "O numero de caracteres do Descrição do cupom é invalido ")]
        public string Descri { get; set; }

        [Display(Name = "Valor minimo")]
        [Required(ErrorMessage = "O campo Valor minimo é requerido")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float ValorMin { get; set; }


        public void InsertCupom(Cupom cupom)
        {
            string strQuery = string.Format("call sp_InsCupom('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", cupom.CodCupom,cupom.Desconto.ToString().Replace(",","."),cupom.NumUtiliza,cupom.TotalDispo,cupom.DataInicio.ToString("yyyy-MM-dd HH:mm"),cupom.DataTerm.ToString("yyyy-MM-dd HH:mm"), cupom.Descri,cupom.ValorMin.ToString().Replace(",","."));

            using(db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateCupom(Cupom cupom)
        {
            string strQuery = string.Format("call sp_AtuaCupom('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", cupom.CodCupom, cupom.Desconto.ToString().Replace(",", "."), cupom.NumUtiliza, cupom.TotalDispo, cupom.DataInicio.ToString("yyyy-MM-dd HH:mm"), cupom.DataTerm.ToString("yyyy-MM-dd HH:mm"), cupom.Descri, cupom.ValorMin.ToString().Replace(",", "."));

            using (db = new ConexaoDB())
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
                        Desconto = float.Parse(registros["desconto"].ToString()),
                        NumUtiliza = int.Parse(registros["numutiliza"].ToString()),
                        TotalDispo = int.Parse(registros["TotalDispo"].ToString()),
                        DataInicio = DateTime.Parse(registros["DataInicio"].ToString()),
                        DataTerm = DateTime.Parse(registros["DataTerm"].ToString()),
                        Descri = registros["Descri"].ToString(),
                        ValorMin = float.Parse(registros["ValorMin"].ToString())
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
                        Desconto = float.Parse(registros["desconto"].ToString()),
                        NumUtiliza = int.Parse(registros["numutiliza"].ToString()),
                        TotalDispo = int.Parse(registros["TotalDispo"].ToString()),
                        DataInicio = DateTime.Parse(registros["DataInicio"].ToString()),
                        DataTerm = DateTime.Parse(registros["DataTerm"].ToString()),
                        Descri = registros["Descri"].ToString(),
                        ValorMin = float.Parse(registros["ValorMin"].ToString())
                    };
                }

                return CupomListando;
            }

        }
    }
}