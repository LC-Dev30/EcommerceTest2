using EcommerceTest2.DTOs;

namespace EcommerceTest2.Repositorios.Clientes
{
    public interface IClientesRepositorio
    {
        Task<ResponseResult> RegistrarUsuario(CrearCliente cliente);
    }
}
