using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Notafiscal
    {
        [Required(ErrorMessage = "O campo Id da nota fiscal é requerido.")]
        [Display(Name = "Id da nota fiscal")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdNF { get; set; }

        [Required(ErrorMessage = "O campo CPF é requerido.")]
        [Display(Name = "CPF")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPF { get; set; }

        [Display(Name = "Id do pagamento")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdPag { get; set; }

        [Required(ErrorMessage = "O campo Data e hora do pagamento é requerido.")]
        [Display(Name = "Data e hora do pagamento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraPag { get; set; }

        [Required(ErrorMessage = "O campo Valor total é requerido.")]
        [Display(Name = " Valor total")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        public float ValorTotal { get; set; }







    }
}