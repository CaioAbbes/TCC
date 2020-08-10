using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "O campo Id do produto é requerido.")]
        [Display(Name = "Id do produto")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdProd { get; set; }
        
        [Required(ErrorMessage = "O campo Nome do produto é requerido.")]
        [StringLength(200,ErrorMessage = "A quantidade de caracteres do Nome do produto é invalido.")]
        [Display(Name = "Nome do produto")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        public string NomeProd { get; set; }

        [Required(ErrorMessage = "O campo Valor do produto é requerido.")]
        [Display(Name = "Valor do produto")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
        public float ValorProd { get; set; }

        [Required(ErrorMessage = "O campo Descrição do produto é requerido.")]
        [Display(Name = "Descrição do produto")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Descrição do produto é invalido.")]
        public string DescProd { get; set; }

        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [Display(Name = "Observação do produto")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Observação do produto é invalido.")]
        public string Observacao { get; set; }


    }
}