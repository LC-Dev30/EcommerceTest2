using EcommerceTest2.Data;

namespace EcommerceTest2.Repositorios.Facturaciones
{
    public interface IFacturacionRepositorio
    {
        Task<Ordene?> ObtenerOrdenConDetalles(int idOrden);
        Task<Facturacion> CrearFactura(Facturacion factura);
    }
}
