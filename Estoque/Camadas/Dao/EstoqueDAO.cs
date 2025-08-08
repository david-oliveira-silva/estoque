using Estoque.Camadas.Dao.Interface;
using Estoque.Camadas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Estoque.Camadas.Dao
{
    public class EstoqueDAO:IEstoqueDAO
    {
        private readonly string caminhoJson = "estoque.json";
        List<EstoqueModel> estoqueList = new List<EstoqueModel>();


        public EstoqueDAO() {
        
        estoqueList = carregarEstoque();
        }


        void IEstoqueDAO.adicionarEstoque(EstoqueModel estoqueModel,int quantidade)
        {
            var itemExistente = estoqueList.FirstOrDefault(e => e.produto.codigoProduto == estoqueModel.produto.codigoProduto);

            if(itemExistente != null)
            {
                estoqueModel.adicionarEstoque(quantidade);
            }
            else
            {
                estoqueModel.adicionarEstoque(quantidade);
                estoqueModel.idEstoque = EstoqueModel.proximoNumero++;
                estoqueList.Add(estoqueModel);
            }
                
            salvarArquivo();
        }

        void IEstoqueDAO.removerEstoque(EstoqueModel estoqueModel, int quantidade)
        {
            var itemExistente = estoqueList.FirstOrDefault(e => e.produto.codigoProduto == estoqueModel.produto.codigoProduto);
            if( itemExistente != null)
            {
                estoqueModel.removerEstoque(quantidade);

            }
                
            salvarArquivo();
        }

        List<EstoqueModel> IEstoqueDAO.listarEstoque()
        {
            return estoqueList;
        }

        public void salvarArquivo()
        {
            var json = JsonSerializer.Serialize(estoqueList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoJson, json);
        }

        public List<EstoqueModel> carregarEstoque()
        {

            if (!File.Exists(caminhoJson))
            {
                return new List<EstoqueModel>();
            }

            var json = File.ReadAllText(caminhoJson);
            var estoque = JsonSerializer.Deserialize<List<EstoqueModel>>(json) ?? new List<EstoqueModel>();

            if (estoque.Count == 0)
            {

                estoqueList = new List<EstoqueModel>();
            }

            if (estoque.Any())
            {
                EstoqueModel.proximoNumero = estoque.Max(e => e.idEstoque) + 1;
            }
            return estoque;


        }

        
    }
}
