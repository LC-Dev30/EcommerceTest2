using EcommerceTest2.Data;
using EcommerceTest2.DTOs;

namespace EcommerceTest2.Servicios.Ordenes
{
    public interface IServicioOrden
    {
        Task<Ordene> CrearOrden(CrearOrdenDto dto);
        Task<bool> ActualizarCantidad(int idDetalle, ActualizarCantidadDto dto);
        Task<bool> EliminarDetalle(int idDetalle);
    }
}
