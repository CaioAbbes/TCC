using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCC.Models
{
    public class Compra
    {

        private ConexaoDB db;

        [Required(ErrorMessage = "O campo Número da compra é requerido.")]
        [Display(Name = "Número da compra")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int NumCompra { get; set; }

        [Required(ErrorMessage = "O campo Codigo de barras é requerido.")]
        [Display(Name = "Codigo de barras")]
        [StringLength(13, ErrorMessage = "A quantidade de caracteres do CodigoBarras é invalido.", MinimumLength = 13)]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "O campo Nome do Fornecedor é requerido.")]
        [Display(Name = "Nome do Fornecedor")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome do cliente é invalido.")]
        public string NomeForn { get; set; }

        [Required(ErrorMessage = "O campo Quantidade da entratada dos ingredientes é requerido.")]
        [Display(Name = "Quantidade da entratada dos ingredientes ")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdEntraIngre { get; set; }

        [Required(ErrorMessage = "O campo Data e hora da chegada é requerido.")]
        [Display(Name = "Data e hora da chegada")]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraChegada { get; set; }
        
        [Display(Name = "Nome dos ingredientes ")]
        [Required(ErrorMessage = "O campo Nome dos ingredientes é requerido.")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres do Nome do cliente é invalido.")]
        public string NomeIngre { get; set; }

        [Required(ErrorMessage = "O campo Unidade de medida é requerido.")]
        [Display(Name = "Unidade de medida")]
        [StringLength(200, ErrorMessage = "A quantidade de caracteres da Unidade de medida é invalido.")]
        public string UniMedi { get; set; }

        [Required(ErrorMessage = "O campo Preço unitário é requerido.")]
        [Display(Name = "Preço unitário")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public float PrecoUnit { get; set; }

        [Required(ErrorMessage = "O campo Quantidade atual é requerido.")]
        [Display(Name = "Quantidade atual")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite somente números.")]
        [Range(0, int.MaxValue, ErrorMessage = "Deve ser positivo")]
        public int QtdAtual { get; set; }

        [Display(Name = "Tempo de duração")]
        [StringLength(20, ErrorMessage = "A quantidade de caracteres do Tempo de duração é invalido.")]
        public string TempDura { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataValidade { get; set; }

        [Display(Name = "Marca")]
        [RegularExpression(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$", ErrorMessage = "Digite somente letras.")]
        [StringLength(50, ErrorMessage = "A quantidade de caracteres da Marca é invalido.")]
        public string Marca { get; set; }

        public Compra(int numCompra, string codigoBarras, string nomeForn, int qtdEntraIngre, DateTime dataHoraChegada, string nomeIngre, string uniMedi, float precoUnit, int qtdAtual, string tempDura, DateTime? dataValidade, string marca)
        {
            NumCompra = numCompra;
            CodigoBarras = codigoBarras;
            NomeForn = nomeForn;
            QtdEntraIngre = qtdEntraIngre;
            DataHoraChegada = dataHoraChegada;
            NomeIngre = nomeIngre;
            UniMedi = uniMedi;
            PrecoUnit = precoUnit;
            QtdAtual = qtdAtual;
            TempDura = tempDura;
            DataValidade = dataValidade;
            Marca = marca;
        }

        public Compra() { }

        public void InsertCompra(string CodigoBarras, string NomeForn, int QtdEntraIngre, DateTime DataHoraChegada, string nomeIngre, string uniMedi, float precoUnit, string marca, DateTime? dataValidade, string tempDura)
        {
            string strQuery = string.Format("call sp_InsCompraEstoque('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}');", CodigoBarras, NomeForn, QtdEntraIngre, DataHoraChegada.ToString("yyyy-MM-dd HH:mm"), nomeIngre, uniMedi, precoUnit.ToString().Replace(",", "."), marca, dataValidade?.ToString("yyyy-MM-dd"), tempDura);
            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }

        }



        public List<Compra> SelecionaCompra()
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcompra;");
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                var compraList = new List<Compra>();
                while (registros.Read())
                {
                    var CompraTemporaria = new Compra
                    {
                        NumCompra = int.Parse(registros["NumCompra"].ToString()),
                        CodigoBarras = new Ingrediente().SelecionaCodigoBarras(registros["CodigoBarras"].ToString()),
                        NomeForn = new Fornecedor().SelecionaComNomeForn(registros["IdForn"].ToString()),
                        QtdEntraIngre = int.Parse(registros["QtdEntraIngre"].ToString()),
                        DataHoraChegada = DateTime.Parse(registros["DataHoraChegada"].ToString())
                    };
                    compraList.Add(CompraTemporaria);
                }
                return compraList;
            }
        }

        public Compra SelecionaNumCompra(int NumCompra)
        {
            using (db = new ConexaoDB())
            {
                string StrQuery = string.Format("select * from tbcompra where NumCompra = '{0}';", NumCompra);
                MySqlDataReader registros = db.RetornaRegistro(StrQuery);
                Compra compraListando = null;
                while (registros.Read())
                {
                    compraListando = new Compra
                    {
                        NumCompra = int.Parse(registros["NumCompra"].ToString()),
                        CodigoBarras = new Ingrediente().SelecionaCodigoBarras(registros["CodigoBarras"].ToString()),
                        NomeForn = new Fornecedor().SelecionaComNomeForn(registros["IdForn"].ToString()),
                        QtdEntraIngre = int.Parse(registros["QtdEntraIngre"].ToString()),
                        DataHoraChegada = DateTime.Parse(registros["DataHoraChegada"].ToString())
                    };
                }

                return compraListando;
            }

        }


    }
}