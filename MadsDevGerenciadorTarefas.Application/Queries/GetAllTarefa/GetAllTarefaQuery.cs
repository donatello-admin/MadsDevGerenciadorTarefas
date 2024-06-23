using MadsDevGerenciadorTarefas.Application.ViewModels;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetAllTarefa
{
    public class GetAllTarefaQuery : IRequest<List<TarefaViewModel>>
    {
        public GetAllTarefaQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
