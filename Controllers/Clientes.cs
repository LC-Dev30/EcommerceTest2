using EcommerceTest2.DTOs;
using EcommerceTest2.Servicios.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceTest2.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Clientes : ControllerBase
    {
        private IServicioCliente _service;
        public Clientes(IServicioCliente service)
        {
            _service = service;
        }

        [HttpPost("registrar-cliente")]
        public async Task<IActionResult> RegistrarCliente(CrearCliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                return BadRequest("Nombre es requerido");

           var serviceresult = await _service.RegistarClienteUseCase(cliente);

            if (serviceresult.StatusCode != 201)
                return Problem(detail: serviceresult.Message, statusCode: serviceresult.StatusCode);

            return Ok(serviceresult);
        }
    }
}
