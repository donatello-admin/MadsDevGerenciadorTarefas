using MadsDevGerenciadorTarefas.Application.ViewModels;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetAllUsuario
{
    public class GetAllUsuarioQuery : IRequest<List<UsuarioViewModel>>
    {
        public GetAllUsuarioQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
