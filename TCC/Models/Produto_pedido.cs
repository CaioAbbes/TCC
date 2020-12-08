using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Produto_pedido
    {
        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Id do produto pedido é requerido.")]
        [Display(Name = "Id do produto pedido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int IdProdPed { get; set; }

       public Produto Produto { get; set; }

        public virtual Comanda Comanda { get; set; }

        public virtual Mesa Mesa { get; set; }


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

        //[Required(ErrorMessage = "O campo Valor unitário é requerido.")]
        [Display(Name = "Valor unitário")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")] 
        public float ValorUnitProd { get; set; }

        //[Required(ErrorMessage = "O campo Estágio do produto é requerido.")]
        [Display(Name = "Estágio do produto",Description = "Ex: Entregue, Em transporte, Cancelado")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres do Nome do produto é invalido.")]
        public string StagioProd { get; set; }

        //[Required(ErrorMessage = "O campo Data e hora do produto pedido é requerido.")]
        [Display(Name = "Data e hora do produto pedido")]
        //[DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime DataHProdPed { get; set; }

        [Display(Name = "Descrição do Pedido")]
        [StringLength(100, ErrorMessage = "A quantidade de caracteres da Descrição do Pedido é invalido.")]
        public string DescPedido { get; set; }


        public void InsertProdPed(string NomeProd,string DescPedido, int IdCli)
        {
            string strQuery = string.Format("call sp_InsPedido('{0}','{1}','{2}','{3}','{4}');", 0, IdCli, NomeProd, 1, DescPedido); //0, pois eh delivery, qtd sempre vai ser 1

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void InsertProdPedCart(Produto produto, int IdCli)
        {
            string strQuery = string.Format("call sp_InsPedido('{0}','{1}','{2}','{3}','{4}');", 0, IdCli, produto.NomeProd, 1, produto.DescProd); //0, pois eh delivery, qtd sempre vai ser 1

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Produto_pedido> SelecionaProdPed()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbproduto_pedido;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var prodPedList = new List<Produto_pedido>();
                while (registros.Read())
                {
                    string desc = registros["DescPedido"].ToString();
                    var ProdPedTemporario = new Produto_pedido
                    {
                        IdProdPed = int.Parse(registros["IdProdPed"].ToString()),
                        Produto = new Produto().SelecionaComIdProd(int.Parse(registros["IdProd"].ToString())),
                        Comanda = new Comanda().SelecionaIdComanda(int.Parse(registros["IdComanda"].ToString())),
                        NomeProd = registros["NomeProd"].ToString(),
                        QtdProd = int.Parse(registros["QtdProd"].ToString()),
                        ValorUnitProd = float.Parse(registros["ValorUnitProd"].ToString()),
                        StagioProd = registros["StagioProd"].ToString(),
                        DataHProdPed = DateTime.Parse(registros["DataHProdPed"].ToString()),
                        DescPedido = desc.Equals("") ? "Sem descrição" : registros["DescPedido"].ToString()
                    };



                    prodPedList.Add(ProdPedTemporario);
                }
                return prodPedList;
            }
        }

        public Produto_pedido SelecionaComIdProdPed(int IdProdPed)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbproduto_pedido where IdProdPed = '{0}';", IdProdPed);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Produto_pedido prodPedListando = null;
                while (registros.Read())
                {
                    string desc = registros["DescPedido"].ToString();
                     prodPedListando = new Produto_pedido
                    {
                        IdProdPed = int.Parse(registros["IdProdPed"].ToString()),
                        Produto = new Produto().SelecionaComIdProd(int.Parse(registros["IdProd"].ToString())),
                        Comanda = new Comanda().SelecionaIdComanda(int.Parse(registros["IdComanda"].ToString())),
                        NomeProd = registros["NomeProd"].ToString(),
                        QtdProd = int.Parse(registros["QtdProd"].ToString()),
                        ValorUnitProd = float.Parse(registros["ValorUnitProd"].ToString()),
                        StagioProd = registros["StagioProd"].ToString(),
                        DataHProdPed = DateTime.Parse(registros["DataHProdPed"].ToString()),
                        DescPedido = desc.Equals("") ? "Sem descrição" : registros["DescPedido"].ToString()
                    };
                }

                return prodPedListando;
            }

        }

    }
}