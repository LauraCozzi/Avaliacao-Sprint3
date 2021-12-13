using CardapioDigital.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardapioDigital
{
    class Program
    {
        // Indica as mesas que podem ser escolhidas
        public static int[] mesas = new int[] { 1, 2, 3, 4 };
        public static Cardapio cardapio = new Cardapio();

        static void Main(string[] args)
        {
            bool exibeMenu = true;
            while (exibeMenu)
            {
                exibeMenu = Menu();
            }
        }

        private static bool Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PEDIDOS ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine(" \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
            Console.WriteLine("║ 1 EFETUAR PEDIDO                              ║    ");
            Console.WriteLine("║ 2 SAIR                                        ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");
            Console.Write(" DIGITE UMA OPÇÃO : ");

            switch (Console.ReadLine())
            {
                case "1":
                    PegaNumeroMesa();
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }

        // Método responsável pela conversão do objeto pedido para o formato json (Serialização) e sua impressão 
        public static void Json(Pedido pedido)
        {
            //var javascriptSerializer = new JavaScriptSerializer();
            //var json = javascriptSerializer.Serialize(pedido);
            var json = JsonConvert.SerializeObject(pedido, Formatting.Indented);
            Console.WriteLine("\n\n" + json + "\n\n");
        }

        // Método responsável pela impressão na tela do usuário dos produtos pedidos pela mesa e seu valor total
        public static void MostrarPedido(int mesa, Pedido pedido)
        {
            Console.Clear();
            int ordem = 1;
            Console.WriteLine("\nA mesa " + mesa + ", pediu os seguintes itens: \n");
            foreach (Produto produto in pedido.ListaDoPedido)
            {
                Console.WriteLine(ordem + " - " + produto.Descricao);
                ordem++;
            }
            Console.WriteLine("\nCom valor total de R$ " + pedido.Total.ToString("f2"));

            // arruma a descrição para tirar os espaços desncessários
            foreach (Produto produto in pedido.ListaDoPedido)
            {
                produto.Descricao = produto.Descricao.Trim();
            }
            pedido.Total = double.Parse(pedido.Total.ToString("N2"));

            Json(pedido);
            Console.WriteLine("\n" + "TECLE [ENTER] PARA FINALIZAR" + "\n\n");
            Console.ReadKey();
        }

        // Método responsável por pegar o numero da mesa do pedido 
        public static void PegaNumeroMesa()
        {
            int numeroDaMesa;
            bool continuar = true;
            Pedido pedido;

            while (continuar)
            {
                Console.Write("\n QUAL O NÚMERO DA MESA? ");
                numeroDaMesa = int.Parse(Console.ReadLine());

                if (mesas.Contains(numeroDaMesa))
                {
                    pedido = PegarPedido();
                    MostrarPedido(numeroDaMesa, pedido);
                    continuar = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" NÚMERO DE MESA INVÁLIDO! SÓ EXISTEM AS MESAS 1, 2, 3 e 4.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        // Método responsável por pegar todos os pedidos da mesa
        public static Pedido PegarPedido()
        {
            List<Produto> listaDeProdutos = new List<Produto>();
            List<int> listaQuantidade = new List<int>();
            Pedido pedido;
            Produto produto;
            bool existePedido = false;
            int quantidade;
            string codigo;

            while (true)
            {
                Console.WriteLine(" Qual  o item (Codigo) do pedido abaixo?");
                cardapio.Imprimir();
                Console.Write(" Informe o Codigo: ");
                codigo = Console.ReadLine();
                existePedido = cardapio.ExisteNoCardapio(codigo);

                if (existePedido)
                {
                    produto = cardapio.IdentificaPedido(codigo);
                    Console.Write(" Informe o Quantidade: ");
                    quantidade = int.Parse(Console.ReadLine());
                    Console.WriteLine(" Adicionando pedido...");
                    System.Threading.Thread.Sleep(2 * 1000);
                    listaDeProdutos.Add(produto);
                    listaQuantidade.Add(quantidade);
                }
                else if (codigo == "999")
                {
                    Console.WriteLine(" Finalizando pedido...");
                    System.Threading.Thread.Sleep(2 * 1000);
                    pedido = new Pedido(listaQuantidade, listaDeProdutos);
                    return pedido;
                }
                else
                {
                    Console.WriteLine("\n CÓDIGO INVÁLIDO");
                    System.Threading.Thread.Sleep(2 * 1000);
                    continue;
                }
            }
        }
    }
}
