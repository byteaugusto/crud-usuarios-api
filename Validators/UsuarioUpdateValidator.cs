using FluentValidation;
using MinhaPrimeiraApi.DTOs;

namespace MinhaPrimeiraApi.Validators
{
    public class UsuarioUpdateValidator : AbstractValidator<UsuarioUpdateDto>
    {
        public UsuarioUpdateValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório")
                .MaximumLength(100)
                .WithMessage("O nome não pode ter mais de 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email é obrigatório")
                .EmailAddress()
                .WithMessage("Insira um formato de email válido");
        }
    }
}
