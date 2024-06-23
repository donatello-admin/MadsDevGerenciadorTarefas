using FluentValidation;
using MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefa;

namespace MadsDevGerenciadorTarefas.Application.Validators
{
    public class UpdateTarefaCommandValidator : AbstractValidator<UpdateTarefaCommand>
    {
        public UpdateTarefaCommandValidator()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .WithMessage("O Título deve ter ´mínimo 5 caracteres, não pode ser vazio e nem nulo.");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .WithMessage("A Dedcrição deve ter ´mínimo 5 caracteres, não pode ser vazio e nem nulo.");

            RuleFor(c => c.IdUsuario)
                .NotNull()
                .NotEmpty()
                .WithMessage("O id de usuário é obrigatorio");
        }
    }
}
