using BackEcommerce.DTOs;
using FluentValidation;

namespace BackEcommerce.Validadores
{
    public class CrearClienteValidator : AbstractValidator<CrearClienteDto>
    {
        public CrearClienteValidator()
        {

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(40).WithMessage("El nombre no puede superar 40 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("El email no tiene un formato válido.")
                .MaximumLength(60).WithMessage("El email no puede superar 60 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
        }
    }
}
