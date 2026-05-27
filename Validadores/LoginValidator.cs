using BackEcommerce.DTOs;
using FluentValidation;

namespace BackEcommerce.Validadores
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(e => e.Email)
                 .NotEmpty().WithMessage("El email es obligatorio.")
                    .EmailAddress().WithMessage("El email no tiene un formato válido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.");
        }
    }
}
