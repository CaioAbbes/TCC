using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Pagamento
    {
        [Required(ErrorMessage = "O campo Id da pagamento é requerido.")]
        [Display(Name = "Id da pagamento")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdPag { get; set; }

        [Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        [Display(Name = "CPF do funcionário.")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]

        public decimal CPFfunc { get; set; }

        [Display(Name = "Id da comanda")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdComanda { get; set; }

        [Required(ErrorMessage = "O campo Forma de pagamentoo é requerido.")]
        [Display(Name = "Forma de pagamento")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(17, ErrorMessage = "A quantidade de caracteres do Forma de pagamento é invalido.")]
        public string FormPag { get; set; }

        [Required(ErrorMessage = "O campo Total é requerido.")]
        [Display(Name = "Total")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        public float Total { get; set; }
    }
}