using MadsDevGerenciadorTarefas.Application.ViewModels;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetAllUsuario
{
    public class GetAllUsuarioQueryHandler : IRequestHandler<GetAllUsuarioQuery, List<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public GetAllUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioViewModel>> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            var usuarioViewModel = usuarios
                .Select(u => new UsuarioViewModel(u.Nome,u.Senha,u.Email,u.Papel,u.StatePree))
                .ToList();

            return usuarioViewModel;
        }
    }
}
