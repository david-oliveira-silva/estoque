using Estoque.Camadas.Dao.Interface;
using Estoque.Camadas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Estoque.Camadas.Dao
{
    public class ProdutoDAO : IProdutoDAO
    {
        string caminhoJson = "produto.json";
        List<ProdutoModel> produtoList = new List<ProdutoModel>();  

        public ProdutoDAO() {
            produtoList = carregarProdutos();
        }
        void IProdutoDAO.cadastrarProduto(ProdutoModel produtoModel)
        {
            produtoList.Add(produtoModel);
            salvarArquivo();
        }
        void IProdutoDAO.removerProduto(ProdutoModel produtoModel)
        {
            produtoList.Remove(produtoModel);
        }
        void IProdutoDAO.atualizarProduto(ProdutoModel produtoModel, string nomeProduto, decimal valorProduto)
        {    

            var produtoExistente = produtoList.FirstOrDefault(p => p.codigoProduto == produtoModel.codigoProduto);

            produtoExistente.nomeProduto = nomeProduto;
            produtoExistente.valorProduto = valorProduto;

            salvarArquivo() ;
        }

       
        List<ProdutoModel> IProdutoDAO.listarProduto()
        {
            return produtoList;
        }


        public void salvarArquivo()
        {
            var json = JsonSerializer.Serialize(produtoList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoJson,json);
        }

        public List<ProdutoModel> carregarProdutos() {

            if (!File.Exists(caminhoJson))
            {
                return new List<ProdutoModel>();
            }

            var json = File.ReadAllText(caminhoJson);
            var produto = JsonSerializer.Deserialize<List<ProdutoModel>>(json) ?? new List<ProdutoModel>();

            if (produto.Count == 0) { 
            
                produtoList = new List<ProdutoModel>();
            }
    
            produto.Max(p => p.codigoProduto + 1);
            return produto;

                
        
        }
        
    }
}
