using MadsDevGerenciadorTarefas.Core.Entities;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefaFinish
{
    
    public class UpdateTarefaFinishCommandHandler : IRequestHandler<UpdateTarefaFinishCommand, int>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public UpdateTarefaFinishCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<int> Handle(UpdateTarefaFinishCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

            tarefa.UpdateStatePree();
            await _tarefaRepository.UpdateAsync(tarefa);
            await _tarefaRepository.SaveChangesAsync();

            var newTarefa = new Tarefa(tarefa.Titulo, tarefa.Descricao, tarefa.DataVencimento, tarefa.Prioridade, tarefa.IdUsuario);
            
            newTarefa.UpdateStatusTarefa();

            await _tarefaRepository.AddAsync(newTarefa);

            await _tarefaRepository.SaveChangesAsync();

            return tarefa.Id;
        }
    }
}
