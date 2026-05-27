using BackEcommerce.DTOs;
using BackEcommerce.Servicios.Clientes;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEcommerce.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Clientes : ControllerBase
    {
        private IServicioCliente _service;
        private readonly IValidator<CrearClienteDto> _validator;
        public Clientes(IServicioCliente service, IValidator<CrearClienteDto> validator)
        {
            _validator = validator;
            _service = service;
        }

        [HttpPost("registrar-cliente")]
        public async Task<IActionResult> RegistrarCliente(CrearClienteDto dto)
        {
            var validarCliente = await _validator.ValidateAsync(dto);

            if (!validarCliente.IsValid)
                return BadRequest(validarCliente.Errors.Select(e => e.ErrorMessage));

            var servicio = await _service.RegistarClienteUseCase(dto);

            if (servicio.StatusCode != 201)
                return Problem(detail: servicio.Message, statusCode: servicio.StatusCode);

            return CreatedAtAction(nameof(RegistrarCliente), servicio);
        }
    }
}
