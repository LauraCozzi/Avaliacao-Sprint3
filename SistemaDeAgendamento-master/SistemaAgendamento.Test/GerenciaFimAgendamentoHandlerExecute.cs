using Microsoft.EntityFrameworkCore;
using Moq;
using SistemaAgendamento.Core.Commands;
using SistemaAgendamento.Core.Models;
using SistemaAgendamento.Infrastructure;
using SistemaAgendamento.Service.Handlers;
using SistemaAgendamento.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SistemaAgendamento.Test
{
    public class GerenciaFimAgendamentoHandlerExecute
    {
        [Fact]
        // Simulação em mock para validar quantas vezes o método de atualizar o agendamento
        // foi chamado ao executar o método GerenciaFimAgendamentoHandler.Execute()
        public void DeveChamarOetodoAtualizarQuandoOsAgendamentosUltrapassaremOPrazo()
        {
            // arrange
            var sala = new Sala(1, "Sala de teste");
            List<AgendamentoModel> listaAgendamentos = new List<AgendamentoModel>
            {
                new AgendamentoModel(1, "Titulo", sala, new DateTime(2020, 12, 15), new DateTime(2020, 12, 25), StatusAgendamento.Criada),
                new AgendamentoModel(2, "Titulo", sala, new DateTime(2021, 12, 15), new DateTime(2021, 12, 25), StatusAgendamento.Criada),
                new AgendamentoModel(3, "Titulo", sala, new DateTime(2022, 12, 15), new DateTime(2022, 12, 25), StatusAgendamento.Criada),
                new AgendamentoModel(4, "Titulo", sala, new DateTime(2023, 12, 15), new DateTime(2023, 12, 25), StatusAgendamento.Criada),
                new AgendamentoModel(5, "Titulo", sala, new DateTime(2024, 12, 15), new DateTime(2024, 12, 25), StatusAgendamento.Criada),
            };

            var mock = new Mock<IRepositorioAgendamento>();
            mock.Setup(repositorio => repositorio.ObtemAgendamentos(It.IsAny<Func<AgendamentoModel, bool>>())).Returns(listaAgendamentos);
            var repo = mock.Object;

            var commando = new GerenciaFimAgendamento(new DateTime(2021, 12, 12));
            var handler = new GerenciaFimAgendamentoHandler(repo);

            // act
            handler.Execute(commando);

            // assert
            // Deve chamar o método AtualizarAgendamentos apenas uma vez para o agendamento de id = 1, em que seu prazo passou
            mock.Verify(repositorio => repositorio.AtualizarAgendamentos(It.IsAny<AgendamentoModel[]>()), Times.Once());
        }
    }
}
