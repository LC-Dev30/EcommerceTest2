using BackEcommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEcommerce.Repositorios.Facturaciones
{
    public class FacturacionRepositorio : IFacturacionRepositorio
    {
        private readonly EcommercePracticeContext _context;

        public FacturacionRepositorio(EcommercePracticeContext context)
        {
            _context = context;
        }

        public async Task<Ordene?> ObtenerOrdenConDetalles(int idOrden)
        {
            return await _context.Ordenes
                .Include(o => o.IdClienteNavigation)
                .Include(o => o.OrdenesDetalles)
                    .ThenInclude(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(o => o.Id == idOrden);
        }

        public async Task<Facturacion> CrearFactura(Facturacion factura)
        {
            await _context.Facturacions.AddAsync(factura);
            await _context.SaveChangesAsync();
            return factura;
        }
    }
}
