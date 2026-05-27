using BackEcommerce.DTOs;
using FluentValidation;

namespace BackEcommerce.Validadores
{
    public class ActualizarCantidadValidator : AbstractValidator<ActualizarCantidadDto>
    {
        public ActualizarCantidadValidator()
        {
            RuleFor(x => x.NuevaCantidad)
                .GreaterThan(0).WithMessage("La cantidad debe ser mayor a cero.");
        }
    }
}
