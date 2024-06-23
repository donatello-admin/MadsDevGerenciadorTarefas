using MadsDevGerenciadorTarefas.Core.Enums;
using MediatR;

namespace MadsDevGerenciadorTarefas.Application.Commands.CreateTarefa
{
    public class CreateTarefaCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public PrioridadeEnum Prioridade { get; set; }
        //public StatusTarefaEnum Status { get; private set; }
        //public string StatePree { get; private set; }
        public int IdUsuario { get; set; }
    }
}
