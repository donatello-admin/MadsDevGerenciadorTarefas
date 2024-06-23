using MadsDevGerenciadorTarefas.Core.Enums;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommand : IRequest<int>
    {
        public UpdateUsuarioCommand(int id,string nome, string senha, string email, PapelEnum papel, StatusUsuarioEnum status)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Email = email;
            Papel = papel;
            Status = status;
            StatePree = "C";
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public PapelEnum Papel { get; private set; }
        public StatusUsuarioEnum Status { get; private set; }

        public string StatePree { get; private set; }
    }
}
