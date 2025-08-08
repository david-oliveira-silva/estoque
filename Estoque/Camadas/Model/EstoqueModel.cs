using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Camadas.Model
{
    public class EstoqueModel
    {
        public int idEstoque {  get; set; }
        public ProdutoModel produto { get; set; }
        public int quantidadeEstoque { get; set; }

        public static int proximoNumero = 1;
        public EstoqueModel() { }

        public EstoqueModel(ProdutoModel produto)
        {
            idEstoque = proximoNumero++;
            this.produto = produto;
            quantidadeEstoque = 0;
        }

        public void adicionarEstoque(int quantidade) {

            quantidadeEstoque += quantidade;
        }
        public void removerEstoque(int quantidade)
        {
            quantidadeEstoque -= quantidade;
        }
    }
}
