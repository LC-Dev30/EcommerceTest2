using EcommerceTest2.DTOs;

namespace EcommerceTest2.Servicios.Clientes
{
    public interface IServicioCliente
    {
        Task<ResponseResult> RegistarClienteUseCase(CrearCliente cliente);
    }
}
