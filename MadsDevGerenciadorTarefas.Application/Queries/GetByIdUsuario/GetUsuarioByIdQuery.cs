using MadsDevGerenciadorTarefas.Application.ViewModels;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetByIdUsuario
{
    public class GetUsuarioByIdQuery : IRequest<UsuarioViewModel>
    {
        public GetUsuarioByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
