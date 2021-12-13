using SistemaAgendamento.Core.Commands;
using SistemaAgendamento.Core.Models;
using SistemaAgendamento.Infrastructure;

namespace SistemaAgendamento.Services.Handlers
{
    public class ObtemAgendamentoPorIdHandler
    {
        IRepositorioAgendamento _repo;

        public ObtemAgendamentoPorIdHandler(IRepositorioAgendamento repositorio)
        {
            _repo = repositorio;
        }

        public AgendamentoModel Execute(ObtemAgendamentoPorId comando)
        {
            return _repo.ObtemAgendamentoPorId(comando.IdAgendamento);
        }
    }
}
