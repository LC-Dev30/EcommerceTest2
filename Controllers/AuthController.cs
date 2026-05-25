using EcommerceTest2.DTOs;
using EcommerceTest2.Servicios.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceTest2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServicioAuth _servicio;

        public AuthController(IServicioAuth servicio)
        {
            _servicio = servicio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _servicio.Login(dto);

            if (token == null)
                return Unauthorized("Credenciales incorrectas.");

            return Ok(new { token });
        }
    }
}
