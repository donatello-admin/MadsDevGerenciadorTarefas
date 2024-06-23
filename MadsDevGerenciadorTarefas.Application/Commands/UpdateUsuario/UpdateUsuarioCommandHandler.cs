using MadsDevGerenciadorTarefas.Core.Entities;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UpdateUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

            usuario.UpdateStatePreeUsuario();

            await _usuarioRepository.UpdateAsync(usuario);
            await _usuarioRepository.SaveChangesAsync();

            var newUsuario = new Usuario(request.Nome, request.Senha, request.Email, request.Papel);

            await _usuarioRepository.AddAsync(newUsuario);
            await _usuarioRepository.SaveChangesAsync();


            return usuario.Id;
        }
    }
}
