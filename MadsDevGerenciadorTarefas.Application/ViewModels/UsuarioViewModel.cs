using MadsDevGerenciadorTarefas.Core.Enums;

namespace MadsDevGerenciadorTarefas.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nome, string senha, string email, PapelEnum papel, string statePree)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Papel = papel;
            StatePree = statePree;
        }

        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public PapelEnum Papel { get; set; }
        public string StatePree { get; set; }
    }
}
