using MadsDevGerenciadorTarefas.Core.Entities;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var createUsuario = new Usuario(request.Nome, request.Senha, request.Email, request.Papel);

            await _usuarioRepository.AddAsync(createUsuario);
            await _usuarioRepository.SaveChangesAsync();

            return createUsuario.Id;
        }
    }
}
