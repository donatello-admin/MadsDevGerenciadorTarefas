using MadsDevGerenciadorTarefas.Core.Entities;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefa
{
    public class UpdateTarefaCommandHandler : IRequestHandler<UpdateTarefaCommand, int>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public UpdateTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<int> Handle(UpdateTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

            tarefa.UpdateStatePree();
            await _tarefaRepository.UpdateAsync(tarefa);
            await _tarefaRepository.SaveChangesAsync();

            var newTarefa = new Tarefa(request.Titulo, request.Descricao, request.DataVencimento, request.Prioridade, request.IdUsuario);
            await _tarefaRepository.AddAsync(newTarefa);

            await _tarefaRepository.SaveChangesAsync();

            return tarefa.Id;
        }
    }
}
