using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TCC.Models
{
    public class Cliente
    {
        private ConexaoDB db;


        [Required(ErrorMessage = "O campo Id do cliente é requerido.")]
        [Display(Name = "Id do cliente")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        [Key]
        public  int IdCli { get; set; }

        [Required(ErrorMessage = "O campo CPF do cliente é requerido.")]
        [Display(Name = "CPF do cliente.")]
        [StringLength(14, ErrorMessage = "A quantidade de caracteres CPF é invalido.", MinimumLength = 14)]
        public string CPF { get; set; }

        public virtual Endereco Endereco { get; set; }

        [Required(ErrorMessage = "O campo Nome do cliente é requerido.")]
        [Display(Name = "Nome do cliente")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome do cliente é invalido.")]
        public string NomeCli { get; set; }

        [Required(ErrorMessage = "O campo Email do cliente é requerido.")]
        [RegularExpression(@"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$", ErrorMessage = "O Email do cliente está incorreto.")]
        [Display(Name = "Email do cliente")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres do Email do cliente é invalido.")]
        public string EmailCli { get; set; }

        [Required(ErrorMessage = "O campo Celular do cliente é requerido.")]
        [Display(Name = "Celular do cliente")]
        public long CelCli { get; set; }

        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Digite somente letras.")]
        [Display(Name = "Complemento")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Complemento é invalido.")]
        public string Comp { get; set; }

        [Required(ErrorMessage = "O campo Número do edifício é requerido.")]
        [Display(Name = "Número do edifício")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int NumEdif { get; set; }

        public virtual Usuario User { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Deve ser positivo")]
        [Display(Name = "Quantidade de pontos")]
        public float QtdPontos { get; set; }

        public string Imagem { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }



        public void InsertCliente(Cliente cliente)
        {
            string strQuery = string.Format("CALL sp_InsEnderecoCliUsu ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');", cliente.Imagem, cliente.User.UsuarioText, cliente.User.Senha, cliente.Endereco.Cidade, cliente.Endereco.CEP.Replace("-",string.Empty), cliente.Endereco.Logra, cliente.Endereco.Bairro, cliente.Comp, cliente.NumEdif, cliente.NomeCli, cliente.CPF.Replace("-",string.Empty).Replace(".",string.Empty), cliente.EmailCli, cliente.CelCli.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty));

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            string strQuery = string.Format("CALL sp_AtuaCliUsuEnd('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');", cliente.IdCli, cliente.CPF.Replace("-", string.Empty).Replace(".", string.Empty), cliente.Endereco.CEP, cliente.Endereco.Logra, cliente.Endereco.Bairro, cliente.Endereco.Cidade, cliente.User.UsuarioText, cliente.User.Senha, cliente.NumEdif, cliente.NomeCli, cliente.EmailCli, cliente.CelCli.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty), cliente.Comp);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }


        public List<Cliente> SelecionaCliente()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcliente;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var clienteList = new List<Cliente>();
                while (registros.Read())
                {
                    string idcli = registros["IdCli"].ToString();
                    string celcli = registros["CelCli"].ToString();
                    string numedif = registros["NumEdif"].ToString();
                    string qtdpontos = registros["QtdPontos"].ToString();
                    string cepString = registros["CEP"].ToString();
                    string cpf = registros["CPF"].ToString();
                    var ClienteTemporario = new Cliente
                    {
                        IdCli = idcli.Equals("") ? 0 : int.Parse(idcli),
                        NomeCli = registros["NomeCli"].ToString(),
                        CPF = cpf.Equals("") ? "Não há CPF" : registros["CPF"].ToString(),
                        EmailCli = registros["EmailCli"].ToString(),
                        Endereco = new Endereco().RetornaPorCEP(cepString),
                        CelCli = celcli.Equals("") ? 0 : Convert.ToInt64(celcli),
                        Comp = registros["Comp"].ToString(),
                        NumEdif = numedif.Equals("") ? 0 : int.Parse(numedif),
                        QtdPontos = qtdpontos.Equals("") ? 0f : float.Parse(qtdpontos),
                        User = new Usuario().RetornaPorIdUsuario(int.Parse(registros["IdUsuario"].ToString())),
                        Imagem = registros["imagecli"].ToString()
                    };

                    clienteList.Add(ClienteTemporario);
                }
                return clienteList;
            }
        }

        public Cliente SelecionaComIdCli(int IdCli)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcliente where IdCli = '{0}';", IdCli);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Cliente clienteListando = null;
                while (registros.Read())
                {
                    clienteListando = new Cliente
                    {

                        IdCli = int.Parse(registros["IdCli"].ToString()),
                        NomeCli = registros["NomeCli"].ToString(),
                        CPF = registros["CPF"].ToString(),
                        EmailCli = registros["EmailCli"].ToString(),
                        Endereco = new Endereco().RetornaPorCEP(registros["CEP"].ToString()),
                        CelCli = Convert.ToInt64(registros["CelCli"].ToString()),
                        Comp = registros["Comp"].ToString(),
                        NumEdif = int.Parse(registros["NumEdif"].ToString()),
                        User = new Usuario().RetornaPorIdUsuario(int.Parse(registros["IdUsuario"].ToString())),
                        QtdPontos = float.Parse(registros["QtdPontos"].ToString())
                    };
                }

                return clienteListando;
            }

        }


        public Cliente SelecionaIdCli(int IdCli)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select IdCli from tbcliente where IdCli = '{0}';", IdCli);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Cliente clienteListando = null;
                while (registros.Read())
                {
                    clienteListando = new Cliente
                    {
                        IdCli = int.Parse(registros["IdCli"].ToString())

                    };
                }

                return clienteListando;
            }

        }

        public Cliente SelecionaCPF(string CPF)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select CPF from tbcliente where CPF = '{0}';", CPF);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Cliente clienteListando = null;
                while (registros.Read())
                {
                    clienteListando = new Cliente
                    {
                        CPF = registros["CPF"].ToString()

                    };
                }

                return clienteListando;
            }

        }

        public List<Produto_pedido> UltimosPedidos(Cliente cliente)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("CALL sp_SelUltPedidos('{0}');", cliente.IdCli);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var prodPedList = new List<Produto_pedido>();
                while (registros.Read())
                {
                    var prodPedTemp = new Produto_pedido
                    {
                        NomeProd = registros["NomeProd"].ToString(),
                        QtdProd = int.Parse(registros["QtdProd"].ToString()),
                        ValorUnitProd = float.Parse(registros["ValorUnitProd"].ToString()),
                        DataHProdPed = DateTime.Parse(registros["DataHProdPed"].ToString()),
                        DescPedido = registros["DescPedido"].ToString(),
                        StagioProd = registros["StagioProd"].ToString()
                    };

                    prodPedList.Add(prodPedTemp);
                }

                return prodPedList;
            }
        }
    }
}