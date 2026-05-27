using BackEcommerce.DTOs;
using FluentValidation;

namespace BackEcommerce.Validadores
{
    public class CrearOrdenValidator : AbstractValidator<CrearOrdenDto> 
    {
        public CrearOrdenValidator()
        {
            RuleFor(x => x.IdCliente)
              .GreaterThan(0).WithMessage("El cliente es obligatorio.");

            RuleFor(x => x.Detalles)
                .NotNull().WithMessage("Los detalles son obligatorios.")
                .Must(d => d.Count >= 2).WithMessage("La orden debe tener al menos dos productos.");

            RuleForEach(x => x.Detalles).ChildRules(detalle =>
            {
                detalle.RuleFor(x => x.IdProducto)
                    .GreaterThan(0).WithMessage("El producto es obligatorio.");

                detalle.RuleFor(x => x.Cantidad)
                    .GreaterThan(0).WithMessage("La cantidad debe ser mayor a cero.");
            });
        }
    }
}
