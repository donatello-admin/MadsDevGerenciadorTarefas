using MadsDevGerenciadorTarefas.Core.Entities;

namespace MadsDevGerenciadorTarefas.Core.Repositories
{
    public interface ITarefaRepository
    {
        public Task<List<Tarefa>> GetAllAsync();
        public Task<Tarefa> GetByIdAsync(int id);
        public Task AddAsync(Tarefa tarefa);
        public Task SaveChangesAsync();
        public Task UpdateAsync(Tarefa tarefa);
    }
}
