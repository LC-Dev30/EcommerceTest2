namespace BackEcommerce.DTOs
{
    public class CrearOrdenDto
    {
        public int IdCliente { get; set; }
        public List<OrdenDetalleDto> Detalles { get; set; }
    }
}
