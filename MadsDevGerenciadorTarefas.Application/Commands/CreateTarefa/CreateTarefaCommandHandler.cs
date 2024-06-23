using MadsDevGerenciadorTarefas.Core.Entities;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.CreateTarefa
{
    public class CreateTarefaCommandHandler : IRequestHandler<CreateTarefaCommand, int>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public CreateTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<int> Handle(CreateTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefaCommand = new Tarefa(request.Titulo, request.Descricao, request.DataVencimento,request.Prioridade,request.IdUsuario);

            await _tarefaRepository.AddAsync(tarefaCommand);
            await _tarefaRepository.SaveChangesAsync();
                
            return tarefaCommand.Id;

        }
    }
}
