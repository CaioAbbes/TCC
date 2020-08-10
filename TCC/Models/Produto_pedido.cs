using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Produto_pedido
    {
        [Required(ErrorMessage = "O campo Id do produto pedido é requerido.")]
        [Display(Name = "Id do produto pedido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdProdPed { get; set; }

        [Display(Name = "Id do produto")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdProd { get; set; }

        [Display(Name = "Id da comanda")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdComanda { get; set; }

        [Required(ErrorMessage = "O campo Nome do produto é requerido.")]
        [Display(Name = "Nome do produto")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Nome do produto é invalido.")]
        public string NomeProd { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de produto é requerido.")]
        [Display(Name = "Quantidade de produto")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdProd { get; set; }

        [Required(ErrorMessage = "O campo Valor unitário é requerido.")]
        [Display(Name = "Valor unitário")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")] 
        public float ValorUnitProd { get; set; }

        [Required(ErrorMessage = "O campo Estágio do produto é requerido.")]
        [Display(Name = "Estágio do produto",Description = "Ex: Entregue, Em transporte, Cancelado")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Nome do produto é invalido.")]
        public string StagioProd { get; set; }

        [Required(ErrorMessage = "O campo Data e hora do produto pedido é requerido.")]
        [Display(Name = "Data e hora do produto pedido")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime DataHProdPed { get; set; }

    }
}