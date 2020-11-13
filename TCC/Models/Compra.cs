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
        public decimal CodigoBarras { get; set; }

        public string NomeForn { get; set; }

        [Required(ErrorMessage = "O campo Quantidade da entratada dos ingredientes é requerido.")]
        [Display(Name = "Quantidade da entratada dos ingredientes ")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdEntraIngre { get; set; }

        [Required(ErrorMessage = "O campo Data de nascimento do funcionário é requerido.")]
        [Display(Name = "Data de nascimento do funcionário")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraChegada { get; set; }

        public Compra(int numCompra, decimal codigoBarras, string nomeForn, int qtdEntraIngre, DateTime dataHoraChegada)
        {
            NumCompra = numCompra;
            CodigoBarras = codigoBarras;
            NomeForn = nomeForn;
            QtdEntraIngre = qtdEntraIngre;
            DataHoraChegada = dataHoraChegada;
        }

        public Compra() { }

        public void InsertCompra(decimal CodigoBarras, string NomeForn, int QtdEntraIngre, DateTime DataHoraChegada)
        {
            //string strQuery = string.Format("call sp_InsCompraEstoque('{0}','{1}','{2}','{3}');", Ingrediente.CodigoBarras,Fornecedor.NomeForn,compra.QtdEntraIngre,compra.DataHoraChegada.ToString("yyyy-MM-dd HH:mm"));
            string strQuery = string.Format("call sp_InsCompraEstoque('{0}','{1}','{2}','{3}');", CodigoBarras, NomeForn, QtdEntraIngre, DataHoraChegada.ToString("yyyy-MM-dd HH:mm"));
            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }

        }
    }
}