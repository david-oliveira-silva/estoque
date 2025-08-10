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
    public class EstoqueController
    {
        EstoqueService estoqueService = new EstoqueService(new EstoqueDAO());

        public void cadastrarEstoque(EstoqueModel estoqueModel,int quantidade) {

            try
            {
                estoqueService.AdicionarEstoque(estoqueModel, quantidade);

            }catch(ArgumentException ex) {
            
                Console.WriteLine($"Erro:{ex.Message}");
            }
        
        }
        public void removerEstoque(int codigoProduto, int quantidade)
        {
            try
            {
                estoqueService.removerEstoque(codigoProduto,quantidade);
                Console.WriteLine($"Foi removido{quantidade} produto com ID{codigoProduto} do estoque");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine($"Erro:{ex.Message}");
            }
        }

        public List<EstoqueModel> listarEstoque() { 
        var listEstoque = estoqueService.listarEstoque();
            foreach (var e in listEstoque) {
                Console.WriteLine($"(`ProdutoID:{e.produto.codigoProduto},Produto:{e.produto.nomeProduto},QuantidadeEstoque:{e.quantidadeEstoque}");
            }
            return listEstoque;

        }
    }
}
