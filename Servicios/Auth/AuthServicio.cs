using BackEcommerce.Configuracion;
using BackEcommerce.Data;
using BackEcommerce.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEcommerce.Servicios.Auth
{
    public class AuthServicio : IServicioAuth
    {
        private readonly EcommercePracticeContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthServicio(EcommercePracticeContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string?> Login(LoginDto dto)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == dto.Email && c.Password == dto.Password);

            if (cliente == null) return null;

            bool passwordValido = BCrypt.Net.BCrypt.Verify(dto.Password, cliente.Password);
            if (!passwordValido) return null;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, cliente.Id.ToString()),
                new Claim(ClaimTypes.Email, cliente.Email),
                new Claim(ClaimTypes.Name, cliente.Nombre)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
