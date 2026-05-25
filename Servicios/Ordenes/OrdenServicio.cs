using EcommerceTest2.Data;
using EcommerceTest2.DTOs;
using EcommerceTest2.Repositorios.Ordenes;

namespace EcommerceTest2.Servicios.Ordenes
{
    public class OrdenServicio : IServicioOrden
    {
        private readonly IOrdenRepositorio _repositorio;

        public OrdenServicio(IOrdenRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Ordene> CrearOrden(CrearOrdenDto dto)
        {
            if (dto.Detalles == null || dto.Detalles.Count < 2)
                throw new ArgumentException("La orden debe tener al menos dos productos.");

            var orden = new Ordene
            {
                IdCliente = dto.IdCliente,
                FechaCreacion = DateTime.Now
            };

            var detalles = dto.Detalles.Select(d => new OrdenesDetalle
            {
                IdProducto = d.IdProducto,
                Cantidad = d.Cantidad
            }).ToList();

            return await _repositorio.CrearOrden(orden, detalles);
        }

        public async Task<bool> ActualizarCantidad(int idDetalle, ActualizarCantidadDto dto)
        {
            if (dto.NuevaCantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            var detalle = await _repositorio.ObtenerDetalle(idDetalle);
            if (detalle == null) return false;

            await _repositorio.ActualizarCantidad(detalle, dto.NuevaCantidad);
            return true;
        }

        public async Task<bool> EliminarDetalle(int idDetalle)
        {
            var detalle = await _repositorio.ObtenerDetalle(idDetalle);
            if (detalle == null) return false;

            await _repositorio.EliminarDetalle(detalle);
            return true;
        }
    }
}
