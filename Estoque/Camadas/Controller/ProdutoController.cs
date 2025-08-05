using Estoque.Camadas.Dao;
using Estoque.Camadas.Model;
using Estoque.Camadas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Camadas.Controller
{
    public class ProdutoController
    {
        ProdutoService produtoService = new ProdutoService(new ProdutoDAO());

        public void cadastrarProduto(string nomeProduto,decimal valorProduto)
        {
            try {
            
                produtoService.cadastrarProduto(nomeProduto,valorProduto);
            
            }catch(ArgumentException ex){

                Console.WriteLine($"Erro:{ex.Message}");
            }
        }

        public void deletarProduto(ProdutoModel produtoModel)
        {
            try
            {
             produtoService.removerProduto(produtoModel);

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine($"Erro:{ex.Message}");
            }
        }

        public void atualizarProduto(ProdutoModel produtoModel,string nomeProduto, decimal valorProduto)
        {
            try
            {
                produtoService.atualizarProduto(produtoModel,nomeProduto,valorProduto);

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine($"Erro:{ex.Message}");
            }
        }

        public List<ProdutoModel> listaProdutos()
        {
            var listProduto = produtoService.listarProduto();

            foreach (var produto in listProduto) {
                Console.WriteLine($"(ID:{produto.codigoProduto}|Nome:{produto.nomeProduto}|Valor: R${produto.valorProduto})");
            }
            return listProduto;
        }
    }
}
