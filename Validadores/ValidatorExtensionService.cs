using FluentValidation;

namespace BackEcommerce.Validadores
{
    public static class ValidatorExtensionService
    {
        public static IServiceCollection StartValidatorExtensionService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CrearClienteValidator>();
            services.AddValidatorsFromAssemblyContaining<CrearOrdenValidator>();
            services.AddValidatorsFromAssemblyContaining<ActualizarCantidadValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            return services;
        }
    }
}
