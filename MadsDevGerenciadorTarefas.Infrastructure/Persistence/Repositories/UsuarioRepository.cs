using Dapper;
using MadsDevGerenciadorTarefas.Core.Entities;
using MadsDevGerenciadorTarefas.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MadsDevGerenciadorTarefas.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MadsDevGerenciadorTarefasDbContext _dbContext;
        private readonly string _ConnectionString;

        public UsuarioRepository(MadsDevGerenciadorTarefasDbContext dbContext,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _ConnectionString = configuration.GetConnectionString("MadsDevGerenciadorTarefasCs");
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _dbContext.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
           var usuarios = await _dbContext.Usuarios.ToListAsync();

            return usuarios;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            var usuario = await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Id == id);

            return usuario;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            using(var connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                var script = "Update Usuarios SET Nome = @nome, Senha = @senha, Email =@email, Papel = @papel WHERE Id = @id";

              await connection.ExecuteAsync(script, new { Nome = usuario.Nome, Senha = usuario.Senha, Email = usuario.Email, Papel = usuario.Papel, usuario.Id });
            }
        }
    }
}
