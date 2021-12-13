using System;

namespace SistemaAgendamento.Core.Commands
{
    public class GerenciaFimAgendamento
    {
        public GerenciaFimAgendamento(DateTime data)
        {
            DataHoraAtual = data;
        }

        public DateTime DataHoraAtual { get; }
    }
}
