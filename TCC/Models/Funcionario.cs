using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Funcionario
    {
        [Required(ErrorMessage = "O campo Id do funcionário é requerido.")]
        [Display(Name = "Id do funcionário")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdFunc { get; set; }

        [Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        [Display(Name = "CPF do funcionário.")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPFfunc { get; set; }

        [Required(ErrorMessage = "O campo CEP é requerido.")]
        [Display(Name = "CEP")]
        [RegularExpression(@"^[0-9]{5}-[\d]{3}|(\d{8})$", ErrorMessage = "CEP invalido.")]
        public decimal CEP { get; set; }

        [Required(ErrorMessage = "O campo Nome do funcionário é requerido.")]
        [Display(Name = "Nome do funcionário")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome do funcionário é invalido.")]
        public string NomeFunc { get; set; }

        [Required(ErrorMessage = "O campo Data de nascimento do funcionário é requerido.")]
        [Display(Name = "Data de nascimento do funcionário")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime DatNascFunc { get; set; }

        [Required(ErrorMessage = "O campo Cargo do funcionário é requerido.")]
        [Display(Name = "Cargo do funcionário")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(25, ErrorMessage = "A quantidade de caracteres do Cargo do funcionário é invalido.")]
        public string CargoFunc { get; set;}

        [Required(ErrorMessage = "O campo Sexo do funcionário é requerido.")]
        [Display(Name = "Sexo do funcionário")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(1,ErrorMessage = "A quantidade de caracteres do Sexo do funcionário é invalido.")]
        public char SexoFunc { get; set; }

        [Required(ErrorMessage = "O campo Celular do funcionário é requerido.")]
        [Display(Name = "Celular do funcionário")]
        [RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Celular do Funcionário inválido")]
        public int CelFunc { get; set; }

        [Required(ErrorMessage = "O campo Email do funcionário é requerido.")]
        [RegularExpression(@"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$", ErrorMessage = "O Email do funcionário está incorreto.")]
        [Display(Name = "Email do funcionário")]
        [StringLength(60, ErrorMessage = "A quantidade de caracteres do Email do funcionário é invalido.")]
        public string EmailFunc { get; set; }

        [Required(ErrorMessage = "O campo RG do funcionário é requerido.")]
        [Display(Name = "RG do funcionário")]
        [RegularExpression(@"^(\d{1,2})(\d{3})(\d{3})(\d{1})$", ErrorMessage = "RG do funcionário invalido")]
        [StringLength(9, ErrorMessage = "A quantidade de caracteres do RG do funcionário é invalido.")]
        public string RgFunc { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite somente letras.")]
        [Display(Name = "Complemento")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Complemento é invalido.")]
        public string Comp { get; set; }

        [Required(ErrorMessage = "O campo Número do edifício é requerido.")]
        [Display(Name = "Nuúmero do edifício")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public int NumEdif { get; set; }

        [Display(Name = "Id do usuário")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdUsuario { get; set; }

    }
}