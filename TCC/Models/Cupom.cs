using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Cupom
    {
        [StringLength(6,ErrorMessage = "o numero de caracteres do Código do cupom é invalido ")]
        [Required(ErrorMessage = "O campo Código do cupom é requerido")]
        [Display(Name = "Código do cupom")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente números")]
        public string CodCupom { get; set; }

        [Required(ErrorMessage = "O campo Desconto é requerido")]
        [Display(Name = "Desconto")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        public float Desconto { get; set; }
    }
}