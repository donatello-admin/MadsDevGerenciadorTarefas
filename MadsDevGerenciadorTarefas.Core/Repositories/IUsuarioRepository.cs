using MadsDevGerenciadorTarefas.Core.Entities;

namespace MadsDevGerenciadorTarefas.Core.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<List<Usuario>> GetAllAsync();
        public Task<Usuario> GetByIdAsync(int id);
        public Task AddAsync(Usuario usuario);
        public Task SaveChangesAsync();
        public Task UpdateAsync(Usuario usuario);
    }
}
