using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Ingrediente
    {
        [Required(ErrorMessage = "O campo Codigo de barras é requerido.")]
        [Display(Name = "Codigo de barras")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, double.MaxValue, ErrorMessage = "Deve ser positivo")]
        [StringLength(13,ErrorMessage = "A quantidade de caracteres do Codigo de barras é invalido.",MinimumLength = 13)]
        public decimal CodigoBarras { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido.")]
        [Display(Name = "Nome")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50,ErrorMessage = "A quantidade de caracteres do Nome é invalido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Unidade de medida é requerido.")]
        [Display(Name = "Unidade de medida")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Unidade de medida é invalido.")]
        public string UniMedi { get; set; }

        [Required(ErrorMessage = "O campo Preço unitário é requerido.")]
        [Display(Name = "Preço unitário")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        public float PrecoUnit { get; set; }

        [Required(ErrorMessage = "O campo Quantidade atual é requerido.")]
        [Display(Name = "Quantidade atual")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdAtual { get; set; }

        [Display(Name = "Tempo de duração")]
       // [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(20, ErrorMessage = "A quantidade de caracteres do Tempo de duração é invalido.")]
        public string TempDura { get; set; }

        [Display(Name = "Data de validade")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }

        [Display(Name = "Marca")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres da Marca é invalido.")]
        public string Marca { get; set; }
    }
}