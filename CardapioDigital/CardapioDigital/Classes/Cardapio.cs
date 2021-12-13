using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Classes
{
    public class Cardapio
    {
        public List<Produto> Menu { get; set; }

        public Cardapio()
        {
            Produto cahorroQuente = new Produto("100", "Cachorro quente", 5.7);
            Produto XCompleto = new Produto("101", "X Completo     ", 18.3);
            Produto XSalada = new Produto("102", "X Salada       ", 16.5);
            Produto Hamburguer = new Produto("103", "Hamburguer     ", 22.4);
            Produto CocaCola = new Produto("104", "Coca 2L        ", 10);
            Produto Refrigerante = new Produto("105", "Cachorro quente", 1);

            List<Produto> listaDeProdutos = new List<Produto> { cahorroQuente, XCompleto, XSalada, Hamburguer, CocaCola, Refrigerante };
            Menu = listaDeProdutos;
        }

        public void Imprimir()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ CARDÁPIO ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n");
            Console.Write("\n\tCódigo\t");
            Console.Write("\t  Produto\t");
            Console.WriteLine("\tPreço Unitário");

            foreach (Produto produto in Menu)
            {
                Console.Write("\t " + produto.Codigo + "\t");
                Console.Write("     " + produto.Descricao + "\t");
                Console.WriteLine("\t   R$ " + produto.ValorUnitario.ToString("f2"));
            }

            Console.Write("\t 999\t");
            Console.Write("     Encerrar Pedido");
            Console.WriteLine();
            Console.WriteLine();
        }

        public bool ExisteNoCardapio(string codigo)
        {
            bool existe = false;

            if (Menu.Any(produto => produto.Codigo == codigo))
            {
                existe = true;
            }

            return existe;
        }

        public Produto IdentificaPedido(string codigo)
        {
            Produto produto = null;

            foreach (Produto product in Menu)
            {
                if (product.Codigo.Equals(codigo))
                {
                    produto = product;
                }
            }

            return produto;
        }
    }
}
