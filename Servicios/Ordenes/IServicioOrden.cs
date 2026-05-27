using BackEcommerce.Data;
using BackEcommerce.DTOs;

namespace BackEcommerce.Servicios.Ordenes
{
    public interface IServicioOrden
    {
        Task<Ordene> CrearOrden(CrearOrdenDto dto);
        Task<bool> ActualizarCantidad(int idDetalle, ActualizarCantidadDto dto);
        Task<bool> EliminarDetalle(int idDetalle);
    }
}
