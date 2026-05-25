using EcommerceTest2.DTOs;
using EcommerceTest2.Servicios.Ordenes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceTest2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesController : ControllerBase
    {
        private readonly IServicioOrden _servicio;

        public OrdenesController(IServicioOrden servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenDto dto)
        {
            try
            {
                var orden = await _servicio.CrearOrden(dto);
                return CreatedAtAction(nameof(CrearOrden), new { id = orden.Id }, orden);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("detalle/{idDetalle}/cantidad")]
        public async Task<IActionResult> ActualizarCantidad(int idDetalle, [FromBody] ActualizarCantidadDto dto)
        {
            try
            {
                var resultado = await _servicio.ActualizarCantidad(idDetalle, dto);
                if (!resultado) return NotFound("Detalle de orden no encontrado.");
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
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
