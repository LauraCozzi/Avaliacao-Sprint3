using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAgendamento.Service.Handlers
{
    public class CommandResult
    {
        public bool IsSuccess { get; }

        public CommandResult(bool sucess)
        {
            IsSuccess = sucess;
        }
    }
}
