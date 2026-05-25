using EcommerceTest2.Data;

namespace EcommerceTest2.Repositorios.Ordenes
{
    public interface IOrdenRepositorio
    {
        Task<Ordene> CrearOrden(Ordene orden, List<OrdenesDetalle> detalles);
        Task<OrdenesDetalle?> ObtenerDetalle(int idDetalle);
        Task ActualizarCantidad(OrdenesDetalle detalle, int nuevaCantidad);
        Task EliminarDetalle(OrdenesDetalle detalle);
    }
}
