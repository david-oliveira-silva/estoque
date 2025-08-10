using Estoque.Camadas.Controller;
using Estoque.Camadas.Model;

namespace Estoque.Camadas.View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menu =
                "[PRODUTO]\n" +
                "1-Cadastro Produto\n" +
                "2-Remover Produto\n" +
                "3-Atualizar Produto\n" +
                "4-Listar Produto\n" +
                "[Estoque]\n" +
                "5- Adicionar produto Estoque\n" +
                "6- Remover produto Estoque\n" +
                "7- Listar Estoque\n"+
                "-------------------" +
                "\n0-Sair";

            ProdutoController produtoController = new ProdutoController();
            EstoqueController estoqueController = new EstoqueController();

            int opc;
            do
            {

                Console.WriteLine(menu);
                while (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Opção invalida, tente novamente:");
                }

                switch (opc)
                {
                    case 0:
                        produtoController.listaProdutos();
                        break;
                    case 1:
                        Console.Clear();

                        string nomeProduto = lerString("Digite o nome do produto");
                        decimal valorProduto = lerDecimal("Digite o valor do produto");
                        produtoController.cadastrarProduto(nomeProduto,valorProduto);
                        break;

                    case 2:
                        Console.Clear();
                        produtoController.listaProdutos();
                        int codigoProdutoRemover = lerInt("Digite o codigo do produto remover");
                        var produtoSelecionado = produtoController.listaProdutos().FirstOrDefault(p => p.codigoProduto == codigoProdutoRemover);
                        produtoController.deletarProduto(produtoSelecionado);
                        break;
                    case 3:

                        Console.Clear();
                        produtoController.listaProdutos();

                        int codigoProdutoAtualizado = lerInt("Digite o codigo do produto que deseja atualizar");
                        
                        string nomeProdutoAtualizado = lerString("Digite o nome do produto");
                        decimal valorProdutoAtualizado = lerDecimal("Digite o valor do produto");
                        
                        var produtoSelecionadoAtualizar = produtoController.listaProdutos().FirstOrDefault(p => p.codigoProduto == codigoProdutoAtualizado);
                        produtoController.atualizarProduto(produtoSelecionadoAtualizar,nomeProdutoAtualizado,valorProdutoAtualizado);
                        break;
                    case 4:
                        Console.Clear();

                        produtoController.listaProdutos();
                        break;
                    case 5:
                        Console.Clear();
                        produtoController.listaProdutos();
                        int codigoProdutoSelecionado = lerInt("digite o código do produto que deseja adicionar no estoque");

                        int quantidadeAdicionar = lerInt("Digite a quantidade que deseja adiconar no estoque");
                        var produtoEstoque = produtoController.listaProdutos().FirstOrDefault(p => p.codigoProduto == codigoProdutoSelecionado);
                        if (produtoEstoque == null)
                        {
                            Console.WriteLine("Produto não encontrado!");
                            break;
                        }
                        var estoqueSelecionado = estoqueController.listarEstoque().FirstOrDefault(e => e.produto.codigoProduto == codigoProdutoSelecionado);

                        if (estoqueSelecionado != null)
                        {
                            estoqueController.cadastrarEstoque(estoqueSelecionado, quantidadeAdicionar);
                        }
                        else
                        {
                            
                            var novoEstoque = new EstoqueModel(produtoEstoque);
                            estoqueController.cadastrarEstoque(novoEstoque, quantidadeAdicionar);
                        }

                        break;
                    case 6:
                        int codigoRemover = lerInt("digite o codigo do produto que deseja remover");
                        
                        int quantidadeRemover = lerInt("digite a quantidade que deseja remover");
                        estoqueController.removerEstoque(codigoRemover, quantidadeRemover);
                        break;
                    case 7:
                        Console.Clear();
                        estoqueController.listarEstoque();
                        break;



                }
            } while (opc != 0);
        }
        static string lerString(string mensagem)
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine();
        }

        static int lerInt(string mensagem)
        {

            int valor;
            Console.WriteLine(mensagem);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Opção invalida, tente novamente:");
            }

            return valor;

        }
        static decimal lerDecimal(string mensagem)
        {

            decimal valor;
            Console.WriteLine(mensagem);
            while (!decimal.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Opção invalida, tente novamente:");
            }

            return valor;

        }


    }
}
