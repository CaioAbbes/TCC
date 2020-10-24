using MySql.Data.MySqlClient;
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

        private ConexaoDB db = new ConexaoDB();

        [Required(ErrorMessage = "O campo Id do funcionário é requerido.")]
        [Display(Name = "Id do funcionário")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        [Key]
        public int IdFunc { get; set; }

        [Required(ErrorMessage = "O campo CPF do funcionário é requerido.")]
        [Display(Name = "CPF do funcionário.")]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$", ErrorMessage = "CPF invalido.")]
        public decimal CPFfunc { get; set; }

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
        public string UF { get; set; }

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
        public string CargoFunc { get; set; }

        [Required(ErrorMessage = "O campo Sexo do funcionário é requerido.")]
        [Display(Name = "Sexo do funcionário")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(1, ErrorMessage = "A quantidade de caracteres do Sexo do funcionário é invalido.")]
        public string SexoFunc { get; set; }

        [Required(ErrorMessage = "O campo Celular do funcionário é requerido.")]
        [Display(Name = "Celular do funcionário")]
        //[RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Celular do Funcionário inválido")]
        public long CelFunc { get; set; }

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

        [Required(ErrorMessage = "O campo Usuário é requerido.")]
        [Display(Name = "Usuário")]
        public string UsuarioText { get; set; }

        [Required(ErrorMessage = "O campo Senha é requerido.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Tipo de acesso")]
        public decimal TipoAcesso { get; set; }

        public void InsertFuncionario(Funcionario funcionario)
        {
            string strQuery = string.Format("CALL sp_InsFuncEndUsu ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}');", funcionario.UsuarioText, funcionario.Senha, funcionario.UF, funcionario.Cidade, funcionario.CEP, funcionario.Logra, funcionario.Bairro, funcionario.Comp, funcionario.NumEdif, funcionario.NomeFunc, funcionario.DatNascFunc.ToString("yyyy-MM-dd"), funcionario.CargoFunc, funcionario.SexoFunc, funcionario.CelFunc, funcionario.EmailFunc, funcionario.RgFunc, funcionario.CPFfunc, funcionario.Estado, funcionario.TipoAcesso);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            string strQuery = string.Format("CALL sp_AtuaFunc('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}');",funcionario.CPFfunc,funcionario.CEP,funcionario.NomeFunc,funcionario.DatNascFunc.ToString("yyyy-MM-dd"),funcionario.CargoFunc,funcionario.SexoFunc,funcionario.CelFunc,funcionario.EmailFunc,funcionario.RgFunc,funcionario.Comp,funcionario.NumEdif,funcionario.Logra,funcionario.Bairro,funcionario.Cidade,funcionario.Estado,funcionario.UF,funcionario.UsuarioText,funcionario.Senha);


            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }



        public List<Funcionario> SelecionaFuncionario()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbfuncionario;");
                MySqlDataReader registros = db.ExecutaRegistro(StrQuery);
                var funcionarioList = new List<Funcionario>();
                while (registros.Read())
                {
                    var FuncionarioTemporario = new Funcionario
                    {
                        IdFunc = int.Parse(registros["IdFunc"].ToString()),
                        CEP = decimal.Parse(registros["CEP"].ToString()),
                        //IdUsuario = int.Parse(registros["IdUsuario"].ToString()),
                        NomeFunc = registros["NomeFunc"].ToString(),
                        CPFfunc = decimal.Parse(registros["CPFfunc"].ToString()),
                        DatNascFunc = DateTime.Parse(registros["DatNascFunc"].ToString()),
                        CargoFunc = registros["CargoFunc"].ToString(),
                        SexoFunc = registros["SexoFunc"].ToString(),
                        CelFunc = Convert.ToInt64(registros["CelFunc"].ToString()),
                        EmailFunc = registros["EmailFunc"].ToString(),
                        RgFunc = registros["RgFunc"].ToString(),
                        Comp = registros["Comp"].ToString(),
                        NumEdif = int.Parse(registros["NumEdif"].ToString())
                    };
                    funcionarioList.Add(FuncionarioTemporario);
                }
                return funcionarioList;
            }
        }

        public Funcionario SelecionaCarregado(Funcionario funcionario)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbfuncionario where IdFunc = '{0}';", funcionario.IdFunc);
                MySqlDataReader registros = db.ExecutaRegistro(StrQuery);
                Funcionario FuncListando = null;
                while (registros.Read())
                {
                    FuncListando = new Funcionario
                    {
                        IdFunc = int.Parse(registros["IdFunc"].ToString()),
                        CEP = decimal.Parse(registros["CEP"].ToString()),
                        //IdUsuario = int.Parse(registros["IdUsuario"].ToString()),
                        NomeFunc = registros["NomeFunc"].ToString(),
                        CPFfunc = decimal.Parse(registros["CPFfunc"].ToString()),
                        DatNascFunc = DateTime.Parse(registros["DatNascFunc"].ToString()),
                        CargoFunc = registros["CargoFunc"].ToString(),
                        SexoFunc = registros["SexoFunc"].ToString(),
                        CelFunc = Convert.ToInt64(registros["CelFunc"].ToString()),
                        EmailFunc = registros["EmailFunc"].ToString(),
                        RgFunc = registros["RgFunc"].ToString(),
                        Comp = registros["Comp"].ToString(),
                        NumEdif = int.Parse(registros["NumEdif"].ToString())
                    };
                }

                return FuncListando;
            }

        }


    }
}