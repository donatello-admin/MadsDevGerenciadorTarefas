namespace MadsDevGerenciadorTarefas.Core.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            DataCriacao = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
