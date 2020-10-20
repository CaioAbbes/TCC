using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Mesa
    {
        [Required(ErrorMessage = "O campo Id da mesa é requerido.")]
        [Display(Name = "Id da mesa")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdMesa { get; set; }

        [Required(ErrorMessage = "O campo Numero de lugares é requerido.")]
        [Display(Name = "Numero de lugares")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int Numlugares { get; set; }

        [Required(ErrorMessage = "O campo Disponivel é requerido.")]
        [Display(Name = "Disponivel")]
        public bool Disponi { get; set; }

        [Required(ErrorMessage = "O campo Tipo de lugar é requerido.")]
        [Display(Name = "Tipo de lugar")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Tipo de lugar é invalido.")]
        public string TipoLugar { get; set; }
    }
}