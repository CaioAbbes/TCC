using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Compra
    {
        [Required(ErrorMessage = "O campo Número da compra é requerido.")]
        [Display(Name = "Número da compra")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int NumCompra { get; set; }

        [Required(ErrorMessage = "O campo Codigo de barras é requerido.")]
        [Display(Name = "Codigo de barras")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [StringLength(13,ErrorMessage = "Código de barras inválido")]
        public decimal CodigoBarras { get; set; }

        [Display(Name = "Id do fornecedor")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "O campo Quantidade da entratada dos ingredientes é requerido.")]
        [Display(Name = "Quantidade da entratada dos ingredientes ")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdEntraIngre { get; set; }

        [Required(ErrorMessage = "O campo Data de nascimento do funcionário é requerido.")]
        [Display(Name = "Data de nascimento do funcionário")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraChegada { get; set; }
    }
}