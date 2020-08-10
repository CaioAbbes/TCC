using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Reserva
    {
        [Required(ErrorMessage = "O campo Id da reserva é requerido.")]
        [Display(Name = "Id da reserva")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdReserva { get; set; }

        [Display(Name = "Id da mesa")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdMesa { get; set; }

        [Required(ErrorMessage = "O campo CPF é requerido.")]
        [Display(Name = "CPF")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPF { get; set; }

        [Required(ErrorMessage = "O campo Data e hora da reserva é requerido.")]
        [Display(Name = "Data e hora da reserva")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraReserva { get; set; }

        [Required(ErrorMessage = "O campo Data e hora que quero come é requerido.")]
        [Display(Name = "Data e hora que quero comer")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime HoraQueroComer { get; set; }
    }
}