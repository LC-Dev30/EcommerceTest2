using EcommerceTest2.DTOs;

namespace EcommerceTest2.Servicios.Auth
{
    public interface IServicioAuth
    {
        Task<string?> Login(LoginDto dto);
    }
}
