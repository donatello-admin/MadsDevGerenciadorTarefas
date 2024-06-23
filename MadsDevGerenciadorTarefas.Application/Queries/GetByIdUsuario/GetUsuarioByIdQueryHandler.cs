using MadsDevGerenciadorTarefas.Application.ViewModels;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Queries.GetByIdUsuario
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public GetUsuarioByIdQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

            var usuarioViewModel = new UsuarioViewModel(usuario.Nome, usuario.Senha, usuario.Email, usuario.Papel, usuario.StatePree);

            return usuarioViewModel;
        }
    }
}
