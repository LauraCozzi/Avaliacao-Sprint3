using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardapioDigital.Classes
{
    public class Pedido
    {
        // Valor total a ser pago pelo pedido da mesa
        public double Total { get; set; }
        // Lista com os produtos pedidos pela mesa
        [JsonProperty("Itens")]
        public List<Produto> ListaDoPedido { get; set; }
        // Lista com as quantidades dos respectivos produtos pedidos pela mesa
        [JsonIgnore]
        public List<int> Quantidade { get; set; }

        // Construtores
        public Pedido(List<int> quantidade, List<Produto> listaDosProdutosPedidos)
        {
            ListaDoPedido = listaDosProdutosPedidos;
            Quantidade = quantidade;
            CalculaTotalPedido();
        }

        public Pedido()
        {
            ListaDoPedido = null;
            Quantidade = null;
            Total = 0;
        }

        // Calcula o valor total do pedido a partir do produto e sua quantidade pedida
        public void CalculaTotalPedido()
        {
            for (int i = 0; i < ListaDoPedido.Count; i++)
            {
                Total += ListaDoPedido[i].ValorUnitario * Quantidade[i];
            }
        }
    }
}
