using MinhaPrimeiraApi.DTOs;
using FluentValidation;

namespace MinhaPrimeiraApi.Validators
{
    public class UsuarioCreateValidator : AbstractValidator<UsuarioCreateDto>
    {
        public UsuarioCreateValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty().
                WithMessage("O nome é obrigatório")
                .MaximumLength(100).WithMessage("O nome não pode ter mais de 100 caracteres");
            
            RuleFor(x => x.Email)
                .NotEmpty().
                WithMessage("O email é obrigatório")
                .EmailAddress()
                .WithMessage("Insira um formato de email válido");
        }
    }
}
