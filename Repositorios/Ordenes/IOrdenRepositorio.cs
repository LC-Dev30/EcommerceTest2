using EcommerceTest2.Data;

namespace EcommerceTest2.Repositorios.Ordenes
{
    public interface IOrdenRepositorio
    {
        Task<Ordene> CrearOrdenAsync(Ordene orden, List<OrdenesDetalle> detalles);
        Task<OrdenesDetalle?> ObtenerDetalleAsync(int idDetalle);
        Task ActualizarCantidadAsync(OrdenesDetalle detalle, int nuevaCantidad);
        Task EliminarDetalleAsync(OrdenesDetalle detalle);
    }
}
