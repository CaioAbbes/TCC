using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Clicupom
    {
        [Required(ErrorMessage = "O campo Codigo cupom é requerido.")]
        [Display(Name = "Codigo cupom")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(6, ErrorMessage = "A quantidade de caracteres do Codigo cupom é invalido.")]
        public string CodCupom { get; set; }

        [Required(ErrorMessage = "O campo CPF é requerido.")]
        [Display(Name = "CPF")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPF { get; set; }

        [Display(Name = "Liberado")]
        public bool Liberado { get; set; }
    }
}