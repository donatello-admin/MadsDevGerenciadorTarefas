using MadsDevGerenciadorTarefas.Application.ViewModels;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetAllTarefa
{
    public class GetAllTarefaQueryHandler : IRequestHandler<GetAllTarefaQuery, List<TarefaViewModel>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public GetAllTarefaQueryHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<TarefaViewModel>> Handle(GetAllTarefaQuery request, CancellationToken cancellationToken)
        {
            var tarefas = await _tarefaRepository.GetAllAsync();
            var tarefaViewModel =  tarefas
                .Select(t => new TarefaViewModel(t.Titulo, t.Descricao, t.DataVencimento, t.Prioridade,t.Status,t.StatePree,t.IdUsuario))
                .ToList();

            return tarefaViewModel;
                
        }
    }
}
