using MadsDevGerenciadorTarefas.Core.Enums;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public PapelEnum Papel { get; set; }
    }
}
