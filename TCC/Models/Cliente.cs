using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Cliente
    {
        private ConexaoDB db = new ConexaoDB();


        [Required(ErrorMessage = "O campo Id do cliente é requerido.")]
        [Display(Name = "Id do cliente")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdCli { get; set; }

        [Required(ErrorMessage = "O campo CPF do cliente é requerido.")]
        [Display(Name = "CPF do cliente.")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPF { get; set; }

        [Required(ErrorMessage = "O campo CEP é requerido.")]
        [Display(Name = "CEP")]
        [RegularExpression(@"^[0-9]{5}-[\d]{3}|(\d{8})$", ErrorMessage = "CEP invalido.")]
        public decimal CEP { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é requerido.")]
        [Display(Name = "Logradouro")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Logradouro é invalido.")]
        public string Logra { get; set; }

        [Required(ErrorMessage = "O campo Bairro é requerido.")]
        [Display(Name = "Bairro")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Bairro é invalido.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é requerido.")]
        [Display(Name = "Cidade")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Cidade é invalido.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é requerido.")]
        [Display(Name = "Estado")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Estado é invalido.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo UF é requerido.")]
        [Display(Name = "UF")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        public char UF { get; set; }

        [Required(ErrorMessage = "O campo Nome do cliente é requerido.")]
        [Display(Name = "Nome do cliente")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome do cliente é invalido.")]
        public string NomeCli { get; set; }

        [Required(ErrorMessage = "O campo Email do cliente é requerido.")]
        [RegularExpression(@"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$", ErrorMessage = "O Email do fornecedor está incorreto.")]
        [Display(Name = "Email do cliente")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Email do cliente é invalido.")]
        public string EmailCli { get; set; }

        [Required(ErrorMessage = "O campo Celular do cliente é requerido.")]
        [Display(Name = "Celular do cliente")]
        [RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Celular inválido")]
        public int CelCli { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite somente letras.")]
        [Display(Name = "Complemento")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Complemento é invalido.")]
        public string Comp { get; set; }

        [Required(ErrorMessage = "O campo Número do edifício é requerido.")]
        [Display(Name = "Número do edifício")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int NumEdif { get; set; }

        [Display(Name = "Id do usuário")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo Usuário é requerido.")]
        [Display(Name = "Usuário")]
        public string UsuarioText { get; set; }

        [Required(ErrorMessage = "O campo Senha é requerido.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Range(0,float.MaxValue,ErrorMessage = "Deve ser positivo")]
        [Display(Name = "Quantidade de pontos")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        public float QtdPontos { get; set; }




     //   public HttpPostedFileBase Imagecli { get; set; } //ou string



        public void InsertCliente(Cliente cliente)
        {
            string strQuery = string.Format("CALL sp_InsEnderecoCliUsu ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}',{8},'{9}',{10},'{11}',{12},'{13}';",cliente.UsuarioText,cliente.Senha,cliente.UF,cliente.Cidade,cliente.CEP,cliente.Logra,cliente.Bairro,cliente.Comp,cliente.NumEdif,cliente.NomeCli,cliente.CPF,cliente.EmailCli,cliente.CelCli,cliente.Estado);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }
    }
}