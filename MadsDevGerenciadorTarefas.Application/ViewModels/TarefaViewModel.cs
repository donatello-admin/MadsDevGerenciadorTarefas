using MadsDevGerenciadorTarefas.Core.Enums;

namespace MadsDevGerenciadorTarefas.Application.ViewModels
{
    public class TarefaViewModel
    {
        public TarefaViewModel(string titulo, string descricao, DateTime dataVencimento, PrioridadeEnum prioridade,StatusTarefaEnum status,string statePree, int idUsuario)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Prioridade = prioridade;
            Status = status;
            StatePree = statePree;
            IdUsuario = idUsuario;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public PrioridadeEnum Prioridade { get; private set; }
        public StatusTarefaEnum Status { get; private set; }
        public string StatePree { get; private set; }
        public int IdUsuario { get; set; }
    }
}
