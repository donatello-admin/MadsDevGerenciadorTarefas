using MadsDevGerenciadorTarefas.Core.Enums;

namespace MadsDevGerenciadorTarefas.Application.InputModels
{
    public class CreateUsuarioInputModel
    {
        public string Nome { get; private set; }
        public Guid Senha { get; private set; }
        public string Email { get; private set; }
        public PapelEnum Papel { get; private set; }
    }
}
