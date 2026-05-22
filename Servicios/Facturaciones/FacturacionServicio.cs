using EcommerceTest2.Data;
using EcommerceTest2.DTOs;
using EcommerceTest2.Repositorios.Facturaciones;

namespace EcommerceTest2.Servicios.Facturaciones
{
    public class FacturacionServicio : IServicioFacturacion
    {
        private readonly IFacturacionRepositorio _repositorio;

        public FacturacionServicio(IFacturacionRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<FacturaPreviewDto> GenerarFacturaAsync(CrearFacturaDto dto)
        {
            var orden = await _repositorio.ObtenerOrdenConDetalles(dto.IdOrden);

            if (orden == null)
                throw new ArgumentException("La orden no existe.");

            if (!orden.OrdenesDetalles.Any())
                throw new ArgumentException("La orden no tiene productos.");

            var numeracion = $"FAC-{DateTime.Now:yyyyMMdd}-{orden.Id:D4}";

            var factura = new Facturacion
            {
                Numeracion = numeracion,
                IdOrden = orden.Id,
                FechaCreacion = DateTime.Now
            };

            await _repositorio.CrearFactura(factura);

            var detalles = orden.OrdenesDetalles.Select(d => new FacturaDetalleDto
            {
                NombreProducto = d.IdProductoNavigation.Nombre,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Subtotal = d.Cantidad * d.PrecioUnitario
            }).ToList();

            return new FacturaPreviewDto
            {
                Numeracion = numeracion,
                IdOrden = orden.Id,
                NombreCliente = orden.IdClienteNavigation.Nombre,
                FechaCreacion = factura.FechaCreacion ?? DateTime.Now,
                Detalles = detalles,
                Total = detalles.Sum(d => d.Subtotal)
            };
        }
    }
}
