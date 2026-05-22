using EcommerceTest2.DTOs;

namespace EcommerceTest2.Servicios.Facturaciones
{
    public interface IServicioFacturacion
    {
        Task<FacturaPreviewDto> GenerarFacturaAsync(CrearFacturaDto dto);
    }
}
