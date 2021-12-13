using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CardapioDigital.Classes
{
    public class Produto
    {
        // Identificador do produto
        public string Codigo { get; set; }
        // Nome do produto
        public string Descricao { get; set; }
        // Valor a ser pago por 1 unidade do produto
        [JsonIgnore]
        public double ValorUnitario { get; set; }

        // Construtor
        public Produto(string codigo, string descricao, double valor)
        {
            Codigo = codigo;
            Descricao = descricao;
            ValorUnitario = valor;
        }

    }
}
