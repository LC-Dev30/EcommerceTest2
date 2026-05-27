using BackEcommerce.Data;
using BackEcommerce.DTOs;

namespace BackEcommerce.Repositorios.Clientes
{
    public interface IClientesRepositorio
    {
        Task<ResponseResult> RegistrarCliente(Cliente cliente);
        Task<InformacionCliente?> ObtenerClientePorEmail(string email);
    }
}
