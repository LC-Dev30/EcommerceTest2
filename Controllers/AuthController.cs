using BackEcommerce.DTOs;
using BackEcommerce.Servicios.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServicioAuth _servicio;
        private readonly IValidator<LoginDto> _validator;

        public AuthController(IServicioAuth servicio, IValidator<LoginDto> validator)
        {
            _validator = validator;
            _servicio = servicio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var validacionLogin = await _validator.ValidateAsync(dto);
            if (!validacionLogin.IsValid)
                return BadRequest(validacionLogin.Errors.Select(e => e.ErrorMessage));
                

            var token = await _servicio.Login(dto);

            if (token == null)
                return Unauthorized("Credenciales incorrectas.");

            return Ok(new { token });
        }
    }
}
