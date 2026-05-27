using BackEcommerce.DTOs;

namespace BackEcommerce.Servicios.Auth
{
    public interface IServicioAuth
    {
        Task<string?> Login(LoginDto dto);
    }
}
