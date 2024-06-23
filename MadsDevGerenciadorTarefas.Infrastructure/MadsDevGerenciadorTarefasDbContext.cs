using MadsDevGerenciadorTarefas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MadsDevGerenciadorTarefas.Infrastructure
{
    public class MadsDevGerenciadorTarefasDbContext : DbContext
    {

        public MadsDevGerenciadorTarefasDbContext(DbContextOptions<MadsDevGerenciadorTarefasDbContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
