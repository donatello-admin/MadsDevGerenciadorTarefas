using MadsDevGerenciadorTarefas.Application.ViewModels;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetByIdTarefa
{
    public class GetTarefaByIdQuery : IRequest<TarefaViewModel>
    {
        public GetTarefaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
