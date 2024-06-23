using Dapper;
using MadsDevGerenciadorTarefas.Core.Entities;
using MadsDevGerenciadorTarefas.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MadsDevGerenciadorTarefas.Infrastructure.Persistence.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly MadsDevGerenciadorTarefasDbContext _dbContext;
        private readonly string _ConnectionString;

        public TarefaRepository(MadsDevGerenciadorTarefasDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _ConnectionString = configuration.GetConnectionString("MadsDevGerenciadorTarefasCs");
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            await _dbContext.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Tarefa>> GetAllAsync()
        {
            var tarefas = await _dbContext.Tarefas.ToListAsync();
            
            return tarefas;
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            var tarefa = await _dbContext.Tarefas.SingleOrDefaultAsync(t => t.Id == id);

            return tarefa;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            using(var connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                var script = "UPDATE Tarefas SET Titulo = @titulo, Descricao = @descricao, DataVencimento = @dataVencimento,Prioridade = @prioridade,Status = @status, IdUsuario = @idusuario WHERE Id =@id ";

                await connection.ExecuteAsync(script, new { Titulo = tarefa.Titulo, Descricao = tarefa.Descricao, DataVencimento = tarefa.DataVencimento, Prioridade = tarefa.Prioridade, Status = tarefa.Status, IdUsuario = tarefa.IdUsuario, tarefa.Id });

            }
        }
    }
}
