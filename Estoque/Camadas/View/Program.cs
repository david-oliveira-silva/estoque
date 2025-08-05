using Estoque.Camadas.Controller;

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
                "3-Atualizar Produto" +
                "4-Listar Produto\n"+
                "-------------------" +
                "\n0-Sair";

            ProdutoController produtoController = new ProdutoController();

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
                        string nomeProduto = lerString("Digite o nome do produto");
                        decimal valorProduto = lerDecimal("Digite o valor do produto");
                        produtoController.cadastrarProduto(nomeProduto,valorProduto);
                        break;

                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        produtoController.listaProdutos();
                        break;



                }
            } while (opc == 0);
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
