using Estoque.Camadas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Camadas.Dao.Interface
{
    public interface IProdutoDAO
    {
        void cadastrarProduto(ProdutoModel produtoModel);

        void removerProduto(ProdutoModel produtoModel);

        void atualizarProduto(ProdutoModel produtoModel, string nomeProduto, decimal valorProduto);

        List<ProdutoModel> listarProduto();
        
    }
}
