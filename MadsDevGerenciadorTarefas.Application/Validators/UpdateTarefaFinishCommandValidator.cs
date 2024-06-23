using FluentValidation;
using MadsDevGerenciadorTarefas.Application.Commands.UpdateTarefaFinish;

namespace MadsDevGerenciadorTarefas.Application.Validators
{
    public class UpdateTarefaFinishCommandValidator : AbstractValidator<UpdateTarefaFinishCommand>
    {
        public UpdateTarefaFinishCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id da tarefa é obrigatório");
        }
    }
}
