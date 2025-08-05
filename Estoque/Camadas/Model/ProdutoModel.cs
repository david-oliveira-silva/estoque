using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Camadas.Model
{
    public class ProdutoModel
    {
        public string nomeProduto {  get; set; }
        public decimal valorProduto {  get; set; }

        public int codigoProduto {  get; set; }

        public static int proximoNumero = 1;
        public ProdutoModel() { }

        public ProdutoModel(string nomeProduto,decimal valorProduto)
        {
            codigoProduto = proximoNumero++;
            this.nomeProduto = nomeProduto;
            this.valorProduto = valorProduto;
        }
    }
}
