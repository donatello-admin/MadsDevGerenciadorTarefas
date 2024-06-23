using FluentValidation.AspNetCore;
using FluentValidation;
using MadsDevGerenciadorTarefas.Application.Commands.CreateTarefa;
using MadsDevGerenciadorTarefas.Application.Commands.CreateUsuario;
using MadsDevGerenciadorTarefas.Core.Repositories;
using MadsDevGerenciadorTarefas.Infrastructure;
using MadsDevGerenciadorTarefas.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MadsDevGerenciadorTarefas.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("MadsDevGerenciadorTarefasCs");
builder.Services.AddDbContext<MadsDevGerenciadorTarefasDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddScoped<ITarefaRepository,TarefaRepository>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTarefaCommandValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateTarefaCommand));
builder.Services.AddMediatR(typeof(CreateUsuarioCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
