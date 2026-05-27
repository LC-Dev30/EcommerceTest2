using BackEcommerce.Data;

namespace BackEcommerce.Repositorios.Facturaciones
{
    public interface IFacturacionRepositorio
    {
        Task<Ordene?> ObtenerOrdenConDetalles(int idOrden);
        Task<Facturacion> CrearFactura(Facturacion factura);
    }
}
