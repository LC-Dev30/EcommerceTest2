using BackEcommerce.DTOs;
using BackEcommerce.Servicios.Facturaciones;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEcommerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FacturacionController : ControllerBase
    {
        private readonly IServicioFacturacion _servicio;

        public FacturacionController(IServicioFacturacion servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> GenerarFactura([FromBody] CrearFacturaDto dto)
        {
            var preview = await _servicio.GenerarFacturaAsync(dto);
            if (preview == null) return BadRequest("No se pudu generar la factura correctamente.");
            return Ok(preview);
        }
    }
}
