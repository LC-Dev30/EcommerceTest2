using BackEcommerce.DTOs;

namespace BackEcommerce.Servicios.Clientes
{
    public interface IServicioCliente
    {
        Task<ResponseResult> RegistarClienteUseCase(CrearClienteDto dto);
    }
}
