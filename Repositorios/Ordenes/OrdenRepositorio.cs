using BackEcommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEcommerce.Repositorios.Ordenes
{
    public class OrdenRepositorio : IOrdenRepositorio
    {
        private readonly EcommercePracticeContext _context;

        public OrdenRepositorio(EcommercePracticeContext context)
        {
            _context = context;
        }

        public async Task<Ordene> CrearOrden(Ordene orden, List<OrdenesDetalle> detalles)
        {
            await _context.Ordenes.AddAsync(orden);
            await _context.SaveChangesAsync();

            foreach (var detalle in detalles)
            {
                detalle.IdOrden = orden.Id;
                await _context.OrdenesDetalles.AddAsync(detalle);

                var producto = await _context.Productos.FindAsync(detalle.IdProducto);
                producto.Stock -= detalle.Cantidad;
            }

            await _context.SaveChangesAsync();
            return orden;
        }

        public async Task<OrdenesDetalle?> ObtenerDetalle(int idDetalle)
        {
            return await _context.OrdenesDetalles
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(d => d.Id == idDetalle);
        }

        public async Task ActualizarCantidad(OrdenesDetalle detalle, int nuevaCantidad)
        {
            var producto = await _context.Productos.FindAsync(detalle.IdProducto);
            producto.Stock += detalle.Cantidad;   
            producto.Stock -= nuevaCantidad;       
            detalle.Cantidad = nuevaCantidad;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarDetalle(OrdenesDetalle detalle)
        {
            var producto = await _context.Productos.FindAsync(detalle.IdProducto);
            producto.Stock += detalle.Cantidad;   
            _context.OrdenesDetalles.Remove(detalle);
            await _context.SaveChangesAsync();
        }
    }
}
