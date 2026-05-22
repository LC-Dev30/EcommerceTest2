using EcommerceTest2.DTOs;
using EcommerceTest2.Servicios.Facturaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceTest2.Controllers
{
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
            try
            {
                var preview = await _servicio.GenerarFacturaAsync(dto);
                return Ok(preview);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
