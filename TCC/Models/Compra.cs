using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Compra
    {

        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Número da compra é requerido.")]
        [Display(Name = "Número da compra")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int NumCompra { get; set; }

        //[Required(ErrorMessage = "O campo Codigo de barras é requerido.")]
        //[Display(Name = "Codigo de barras")]
        //[StringLength(13,ErrorMessage = "Código de barras inválido")]
        //public decimal CodigoBarras { get; set; }

        // public Ingrediente Ingrediente { get; set; }

        //public Fornecedor Fornecedor { get; set; }
        public string CodigoBarras { get; set; }

        public string NomeForn { get; set; }

        [Required(ErrorMessage = "O campo Quantidade da entratada dos ingredientes é requerido.")]
        [Display(Name = "Quantidade da entratada dos ingredientes ")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdEntraIngre { get; set; }

        [Required(ErrorMessage = "O campo Data de nascimento do funcionário é requerido.")]
        [Display(Name = "Data de nascimento do funcionário")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraChegada { get; set; }

        public Compra(int numCompra, string codigoBarras, string nomeForn, int qtdEntraIngre, DateTime dataHoraChegada)
        {
            NumCompra = numCompra;
            CodigoBarras = codigoBarras;
            NomeForn = nomeForn;
            QtdEntraIngre = qtdEntraIngre;
            DataHoraChegada = dataHoraChegada;
        }

        public Compra() { }

        public void InsertCompra(string CodigoBarras, string NomeForn, int QtdEntraIngre, DateTime DataHoraChegada)
        {
            //string strQuery = string.Format("call sp_InsCompraEstoque('{0}','{1}','{2}','{3}');", Ingrediente.CodigoBarras,Fornecedor.NomeForn,compra.QtdEntraIngre,compra.DataHoraChegada.ToString("yyyy-MM-dd HH:mm"));
            string strQuery = string.Format("call sp_InsCompraEstoque('{0}','{1}','{2}','{3}');", CodigoBarras, NomeForn, QtdEntraIngre, DataHoraChegada.ToString("yyyy-MM-dd HH:mm"));
            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }

        }



        public List<Compra> SelecionaCompra()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcompra;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var compraList = new List<Compra>();
                while (registros.Read())
                {
                    var CompraTemporaria = new Compra
                    {
                        NumCompra = int.Parse(registros["NumCompra"].ToString()),
                        CodigoBarras = new Ingrediente().SelecionaCodigoBarras(registros["CodigoBarras"].ToString()),
                        NomeForn = new Fornecedor().SelecionaComNomeForn(registros["IdForn"].ToString()),
                        QtdEntraIngre = int.Parse(registros["QtdEntraIngre"].ToString()),
                        DataHoraChegada = DateTime.Parse(registros["DataHoraChegada"].ToString())
                    };
                    compraList.Add(CompraTemporaria);
                }
                return compraList;
            }
        }

        public Compra SelecionaNumCompra(int NumCompra)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcompra where NumCompra = '{0}';", NumCompra);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Compra compraListando = null;
                while (registros.Read())
                {
                    compraListando = new Compra
                    {
                        NumCompra = int.Parse(registros["NumCompra"].ToString()),
                        CodigoBarras = new Ingrediente().SelecionaCodigoBarras(registros["CodigoBarras"].ToString()),
                        NomeForn = new Fornecedor().SelecionaComNomeForn(registros["IdForn"].ToString()),
                        QtdEntraIngre = int.Parse(registros["QtdEntraIngre"].ToString()),
                        DataHoraChegada = DateTime.Parse(registros["DataHoraChegada"].ToString())
                    };
                }

                return compraListando;
            }

        }


    }
}