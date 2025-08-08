using Estoque.Camadas.Dao.Interface;
using Estoque.Camadas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Camadas.Service
{
    public class EstoqueService
    {
        IEstoqueDAO estoqueDAO;

        public EstoqueService(IEstoqueDAO estoqueDAO)
        {
            this.estoqueDAO = estoqueDAO;
        }

        public void AdicionarEstoque(EstoqueModel estoqueModel, int quantidade)
        {
            if (estoqueModel == null)
            {
                throw new ArgumentNullException("Estoque não encontrado");
            }
            if (quantidade <= 0)
            {
                throw new ArgumentException("Adicione uma quantidade maior que 0");
            }

            estoqueDAO.adicionarEstoque(estoqueModel, quantidade);
        }
        public void removerEstoque(EstoqueModel estoqueModel, int quantidade)
        {
            if (estoqueModel == null)
            {
                throw new ArgumentNullException("Estoque não encontrado");
            }
            if (quantidade <= 0)
            {
                throw new ArgumentException("Adicione uma quantidade maior que 0");
            }
            var itemExiste = estoqueDAO.listarEstoque().FirstOrDefault(e => e.idEstoque == estoqueModel.idEstoque);

            if(itemExiste != null)
            {
                itemExiste.quantidadeEstoque += quantidade;
            }
            else
            {
                
                estoqueModel.quantidadeEstoque = quantidade;
                estoqueDAO.adicionarEstoque(estoqueModel, quantidade);
            }

            estoqueDAO.removerEstoque(estoqueModel, quantidade);


        }

        public List<EstoqueModel> listarEstoque()
        {
            return estoqueDAO.listarEstoque();
        }
    }
}
