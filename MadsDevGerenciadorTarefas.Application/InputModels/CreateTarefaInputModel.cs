using MadsDevGerenciadorTarefas.Core.Enums;

namespace MadsDevGerenciadorTarefas.Application.InputModels
{
    public class CreateTarefaInputModel
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public PrioridadeEnum Prioridade { get; private set; }
        public bool Concluida { get; private set; }
        public int IdUsuario { get; set; }

    }
}
