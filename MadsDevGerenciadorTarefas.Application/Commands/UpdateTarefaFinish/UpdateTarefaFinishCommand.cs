using MadsDevGerenciadorTarefas.Core.Enums;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefaFinish
{
    public class UpdateTarefaFinishCommand : IRequest<int>
    {
        public UpdateTarefaFinishCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
