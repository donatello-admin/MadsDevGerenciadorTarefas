using MadsDevGerenciadorTarefas.Core.Enums;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefa
{
    public class UpdateTarefaCommand : IRequest<int>
    {
        public UpdateTarefaCommand(int id,string titulo, string descricao, DateTime dataVencimento, PrioridadeEnum prioridade, int idUsuario)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Prioridade = prioridade;
            IdUsuario = idUsuario;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public PrioridadeEnum Prioridade { get; private set; }
        public StatusTarefaEnum Status { get; private set; }
        //public string StatePree { get; private set; }
        public int IdUsuario { get; set; }
    }
}
