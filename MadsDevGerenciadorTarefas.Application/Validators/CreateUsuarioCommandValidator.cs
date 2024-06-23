using FluentValidation;
using MadsDevGerenciadorTarefas.Application.Commands.CreateUsuario;
using System.Text.RegularExpressions;

namespace MadsDevGerenciadorTarefas.Application.Validators
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Nome não pode ser vazio e nem nulo.");

            RuleFor(c => c.Senha)
                .Must(ValidaPassword)
                .WithMessage("Senha deve contér 8 caracteres, uma maíuscula, uma minuscula, um número e um caractere especial.");

            RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido");
        }

        public bool ValidaPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=].*$)");

            return regex.IsMatch(password);
        }
    }
}
