using BackEcommerce.DTOs;

namespace BackEcommerce.Servicios.Facturaciones
{
    public interface IServicioFacturacion
    {
        Task<FacturaPreviewDto> GenerarFacturaAsync(CrearFacturaDto dto);
    }
}
