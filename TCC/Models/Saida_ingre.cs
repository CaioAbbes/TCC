using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Saida_ingre
    {
        [Required(ErrorMessage = "O campo Id saida ingrediente é requerido.")]
        [Display(Name = "Id saida ingrediente")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdSaidaIngre { get; set; }

        [Required(ErrorMessage = "O campo Codigo de barras é requerido.")]
        [Display(Name = "Codigo de barras")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
       // [StringLength(13,ErrorMessage = "A quantidade de caracteres do Codigo de barras é invalido.",MinimumLength = 13)]
        public decimal CodigoBarras { get; set; }

        [Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        [Display(Name = "CPF do funcionário.")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPFfunc { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido.")]
        [Display(Name = "Nome ")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome é invalido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Quantidade usada é requerido.")]
        [Display(Name = "Quantidade usada")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdUsada { get; set; }

        [Required(ErrorMessage = "O campoData e hora da saida é requerido.")]
        [Display(Name = "Data e hora da saida")]
        [DisplayFormat(DataFormatString = "mm/DD/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraSaida { get; set; }
    }
}