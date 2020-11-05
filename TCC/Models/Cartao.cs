using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Cartao
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Número do cartão é requerido.")]
        [Display(Name = "Número do cartão")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        //[CreditCard(ErrorMessage = "Cartão inválido")]
        //[StringLength(16,ErrorMessage = "A quantidade de caracteres do cartão é invalida.",MinimumLength = 16)]
        public decimal Numcartao { get; set; }

        [Required(ErrorMessage = "O campo Código de Verificação de Cartão é requerido.")]
        [Display(Name = "Código de Verificação de Cartão")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "CVV invalido")]
        public int Cvc { get; set; }

        [Required(ErrorMessage = "O campo Nome do titular é requerido.")]
        [Display(Name = "Nome do titular")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50,ErrorMessage = "A quantidade de caracteres do Nome do titular é invalida.")]
        public string Titular { get; set; }

        [Required(ErrorMessage = "O campo Data de vencimento é requerido.")]
        [Display(Name = "Data de vencimento ")]
        //[DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime Datavalid { get; set; }

        public Cliente Cliente { get; set; }

        public void InsertCartao(Cartao cartao)
        {
            Cliente cliente = new Cliente();

            string strQuery = string.Format("call sp_InsCartao('{0}','{1}','{2}','{3}');",Cliente.PegarIdCli(cliente.IdCli),cartao.Numcartao,cartao.Cvc,cartao.Titular,cartao.Datavalid.ToString("yyyy-MM-dd"));

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }




    }
}