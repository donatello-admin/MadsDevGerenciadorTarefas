using MadsDevGerenciadorTarefas.Application.ViewModels;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetByIdTarefa
{
    public class GetTarefaByIdQueryHandler : IRequestHandler<GetTarefaByIdQuery, TarefaViewModel>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public GetTarefaByIdQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<TarefaViewModel> Handle(GetTarefaByIdQuery request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(request.Id);

            var tarefaViewModel = new TarefaViewModel(tarefa.Titulo,tarefa.Descricao, tarefa.DataVencimento, tarefa.Prioridade, tarefa.Status, tarefa.StatePree, tarefa.IdUsuario);

            return tarefaViewModel;
        }
    }
}
