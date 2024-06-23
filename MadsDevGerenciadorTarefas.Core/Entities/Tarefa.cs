
using MadsDevGerenciadorTarefas.Core.Enums;

namespace MadsDevGerenciadorTarefas.Core.Entities
{
    public class Tarefa : EntityBase
    {
        public Tarefa(string titulo, string descricao, DateTime dataVencimento, PrioridadeEnum prioridade, int idUsuario)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Prioridade = prioridade;
            Status = StatusTarefaEnum.NaoConcluida;
            StatePree = "C";
            IdUsuario = idUsuario;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public PrioridadeEnum Prioridade { get; private set; }
        public StatusTarefaEnum Status { get; private set; }
        public string StatePree { get; private set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public void Update(string titulo, string descricao, DateTime dataVencimento, PrioridadeEnum prioridade, StatusTarefaEnum status,int idUsuario)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Prioridade = prioridade;
            Status = status;
            IdUsuario = idUsuario;
            StatePree = "C";
        }

        public void UpdateStatePree()
        {
            StatePree = "A";
        }

        public void UpdateStatusTarefa()
        {
            Status = StatusTarefaEnum.Concluida;
        }

    }
}
