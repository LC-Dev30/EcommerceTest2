using BackEcommerce.DTOs;
using BackEcommerce.Servicios.Ordenes;
using BackEcommerce.Validadores;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEcommerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesController : ControllerBase
    {
        private readonly IServicioOrden _servicio;
        private readonly IValidator<CrearOrdenDto> _validator;
        private readonly IValidator<ActualizarCantidadDto> _validatorCantidad;

        public OrdenesController(IServicioOrden servicio, IValidator<CrearOrdenDto> validator, IValidator<ActualizarCantidadDto> validatorCantidad)
        {
            _validator = validator;
            _validatorCantidad = validatorCantidad;
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenDto dto)
        {
            var ordenValidacion = await _validator.ValidateAsync(dto);
            if (!ordenValidacion.IsValid)
                return BadRequest(ordenValidacion.Errors.Select(e => e.ErrorMessage));

            var orden = await _servicio.CrearOrden(dto);
            return CreatedAtAction(nameof(CrearOrden), new { id = orden.Id }, orden);
        }

        [HttpPatch("detalle/{idDetalle}/cantidad")]
        public async Task<IActionResult> ActualizarCantidad(int idDetalle, [FromBody] ActualizarCantidadDto dto)
        {
            var cantidadValidacion = await _validatorCantidad.ValidateAsync(dto);
            if (!cantidadValidacion.IsValid)
                return BadRequest(cantidadValidacion.Errors.Select(e => e.ErrorMessage));

            var actualizarCantidad = await _servicio.ActualizarCantidad(idDetalle, dto);
            if (!actualizarCantidad) return NotFound("Detalle de orden no encontrado.");
            return NoContent();
        }

        [HttpDelete("detalle/{idDetalle}")]
        public async Task<IActionResult> EliminarDetalle(int idDetalle)
        {
            var resultado = await _servicio.EliminarDetalle(idDetalle);
            if (!resultado) return NotFound("Detalle de orden no encontrado.");
            return NoContent();
        }
    }
}
