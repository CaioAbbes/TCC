using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Fornecedor
    {
        [Required(ErrorMessage = "O campo Id do fornecedor é requerido.")]
        [Display(Name = "Id do fornecedor")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "O campo Razao Social é requerido.")]
        [Display(Name = "Razao Social")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Razao Social é invalido.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo Nome do fornecedor é requerido.")]
        [Display(Name = "Nome do fornecedor")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Nome do fornecedor é invalido.")]
        public string NomeForn { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é requerido.")]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [StringLength(14,ErrorMessage = "A quantidade de caracteres do CNPJ é invalido.")]
        public decimal Cnpj { get; set; }

        [Required(ErrorMessage = "O campo CEP é requerido.")]
        [Display(Name = "CEP")]
        [RegularExpression(@"^[0-9]{5}-[\d]{3}|(\d{8})$", ErrorMessage = "CEP invalido.")]
        public decimal CEP { get; set; }

        [Required(ErrorMessage = "O campo Celular do Fornecedo é requerido.")]
        [Display(Name = "Celular do Fornecedor")]
        [RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Celular do Fornecedor inválido")]
        public int Tel { get; set; }

        [RegularExpression(@"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$", ErrorMessage = "O Email do fornecedor está incorreto")]
        [Display(Name = "Email do fornecedor")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Email do fornecedorr é invalido.")]
        public string EmailForn { get; set; }

        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [Display(Name = "Complemento")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Complemento é invalido.")]
        public string Comp { get; set; }

        [Required(ErrorMessage = "O campo Numero do edifício é requerido")]
        [Display(Name = "Numero do edifício")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public int NumEdif { get; set; }
    }
}