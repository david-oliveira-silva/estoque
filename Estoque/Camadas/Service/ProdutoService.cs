using Estoque.Camadas.Dao.Interface;
using Estoque.Camadas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Camadas.Service
{
    public class ProdutoService
    {
        IProdutoDAO produtoDAO;

        public ProdutoService(IProdutoDAO produtoDAO)
        {
            this.produtoDAO = produtoDAO;
        }

        public void cadastrarProduto(string nomeProduto, decimal valorProduto)
        {
            var novoProduto = new ProdutoModel(nomeProduto, valorProduto);


            if (string.IsNullOrEmpty(nomeProduto))
            {

                throw new ArgumentException("Nome inválido");
            }

            if (valorProduto < 0)
            {
                throw new ArgumentException("Valor não pode ser negativo");
            }

            produtoDAO.cadastrarProduto(novoProduto);
        }

        public void removerProduto(ProdutoModel produtoModel)
        {
            if (produtoModel == null)
            {
                throw new ArgumentNullException("Produto não encontrado");
            }
            produtoDAO.removerProduto(produtoModel);
        }

        public void atualizarProduto(ProdutoModel produtoModel,string nomeProduto,decimal valorProduto)
        {

            if(produtoModel == null)
            {
                throw new ArgumentNullException("Produto não encontrado");
            }
            produtoModel.nomeProduto = nomeProduto;
            produtoModel.valorProduto = valorProduto;

            if (string.IsNullOrEmpty(nomeProduto))
            {

                throw new ArgumentException("Nome inválido");
            }

            if (valorProduto < 0)
            {
                throw new ArgumentException("Valor não pode ser negativo");
            }
            produtoDAO.atualizarProduto(produtoModel,nomeProduto,valorProduto);
        }

        public List<ProdutoModel> listarProduto() { 
        return produtoDAO.listarProduto();
        }
    }
}
