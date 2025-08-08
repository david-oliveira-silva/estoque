using Estoque.Camadas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Camadas.Dao.Interface
{
    public interface IEstoqueDAO
    {
        void adicionarEstoque(EstoqueModel estoqueModel, int quantidade);

        void removerEstoque(EstoqueModel estoqueModel, int quantidade);

        List<EstoqueModel> listarEstoque();
    }
}
