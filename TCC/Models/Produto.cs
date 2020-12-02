using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Produto
    {
        private ConexaoDB db;

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
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Digite somente números.")]
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

        [Display(Name = "Tipo de produto")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Tipo de produto é invalido.")]
        public string TipoProd { get; set; }

        [Display(Name = "Categoria do produto")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres da Categoria do produto é invalido.")]
        public string CategoriaProd { get; set; }

        public string Imagem { get; set; }

        public void InsertProduto(Produto produto)
        {
            string strQuery = string.Format("CALL sp_InsProd('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", produto.Imagem,produto.NomeProd, produto.DescProd, produto.Observacao, produto.ValorProd.ToString().Replace(",", "."), produto.TipoProd, produto.CategoriaProd);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateProduto(Produto produto)
        {
            string strQuery = string.Format("CALL sp_AtuaProd('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", produto.IdProd, produto.NomeProd, produto.DescProd, produto.Observacao, produto.ValorProd.ToString().Replace(",", "."), produto.TipoProd, produto.CategoriaProd);

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Produto> SelecionaProduto()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbproduto;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var produtoList = new List<Produto>();
                while (registros.Read())
                {
                    string obs = registros["Observacao"].ToString();
                    var ProdutoTemporaria = new Produto
                    {
                        IdProd = int.Parse(registros["IdProd"].ToString()),
                        NomeProd = registros["NomeProd"].ToString(),
                        DescProd = registros["DescProd"].ToString(),
                        ValorProd = float.Parse(registros["ValorProd"].ToString()),
                        Observacao = obs.Equals("") ? "Sem observação" : registros["Observacao"].ToString(),
                        TipoProd = registros["TipoProd"].ToString(),
                        CategoriaProd = registros["CategoriaProd"].ToString(),
                        Imagem = registros["imageprod"].ToString()
                    };
                    produtoList.Add(ProdutoTemporaria);
                }
                return produtoList;
            }
        }

        public Produto SelecionaIdProd(int IdProd)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbproduto where IdProd = '{0}';", IdProd);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Produto ProdutoListando = null;
                while (registros.Read())
                {
                    string obs = registros["Observacao"].ToString();
                    ProdutoListando = new Produto
                    {
                        IdProd = int.Parse(registros["IdProd"].ToString()),
                        NomeProd = registros["NomeProd"].ToString(),
                        DescProd = registros["DescProd"].ToString(),
                        ValorProd = float.Parse(registros["ValorProd"].ToString()),
                        Observacao = obs.Equals("") ? "Sem observação" : registros["Observacao"].ToString(),
                        TipoProd = registros["TipoProd"].ToString(),
                        CategoriaProd = registros["CategoriaProd"].ToString(),
                        Imagem = registros["imageprod"].ToString()
                    };
                }

                return ProdutoListando;
            }

        }

        public Produto SelecionaComIdProd(int IdProd)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select IdProd from tbproduto where IdProd = '{0}';", IdProd);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Produto comandaListando = null;
                while (registros.Read())
                {
                    comandaListando = new Produto
                    {
                        IdProd = int.Parse(registros["IdProd"].ToString()),
                    };
                }

                return comandaListando;
            }

        }

        public List<Produto> BuscaProduto(string busca)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("CALL sp_Like('{0}');",busca);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var produtoList = new List<Produto>();
                while (registros.Read())
                {
                    var ProdutoTemporaria = new Produto
                    {
                        NomeProd = registros["NomeProd"].ToString(),
                        DescProd = registros["DescProd"].ToString(),
                        ValorProd = float.Parse(registros["ValorProd"].ToString()),
                        Observacao = registros["Observacao"].ToString(),
                        TipoProd = registros["TipoProd"].ToString(),
                        CategoriaProd = registros["CategoriaProd"].ToString(),
                        Imagem = registros["imageprod"].ToString()
                    };
                    produtoList.Add(ProdutoTemporaria);
                }
                return produtoList;
            }
        }




    }
}