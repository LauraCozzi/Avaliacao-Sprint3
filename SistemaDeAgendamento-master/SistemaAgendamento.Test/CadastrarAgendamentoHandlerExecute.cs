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
    public class CadastrarAgendamentoHandlerExecute
    {
        [Fact]
        public void InclusaoDeAgendamentosNoBD()
        {
            // arrange
            var sala = new Sala(1, "Sala de teste");
            DateTime inicio = new DateTime(2021, 12, 15);
            DateTime fim = new DateTime(2021, 12, 25);
            var comando = new CadastrarAgendamento("titulo agendamento", sala, inicio, fim);

            var options = new DbContextOptionsBuilder<Infrastructure.DbContext>().UseInMemoryDatabase("DbTarefasContext").Options;
            var contexto = new Infrastructure.DbContext(options);
            var repo = new RepositorioAgendamento(contexto);

            // tratador do comando
            var handler = new CadastraAgendamentoHandler(repo);

            // act
            handler.Execute(comando);

            // assert
            var tarefa = repo.ObtemAgendamentos(t => t.Titulo == "titulo agendamento");
            Assert.NotNull(tarefa);
        }

        [Fact]
        public void LancamentoDeExcecaoParaInclusaoDeAgendamento()
        {
            // arrange
            var sala = new Sala(1, "Sala de teste");
            DateTime inicio = new DateTime(2021, 12, 15);
            DateTime fim = new DateTime(2021, 12, 25);
            var comando = new CadastrarAgendamento("titulo agendamento", sala, inicio, fim);

            var mock = new Mock<IRepositorioAgendamento>();
            mock.Setup(repositorio => repositorio.IncluirAgendamento(It.IsAny<AgendamentoModel>()))
                .Throws(new Exception("Houve um erro na inclusão do agendamento"));
            var repo = mock.Object;

            // tratador do comando
            var handler = new CadastraAgendamentoHandler(repo);

            // act
            CommandResult resultado = handler.Execute(comando);

            // assert
            Assert.False(resultado.IsSuccess);
        }
    }
}
