namespace EcommerceTest2.DTOs
{
    public class FacturaPreviewDto
    {
        public string Numeracion { get; set; }
        public int IdOrden { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<FacturaDetalleDto> Detalles { get; set; }
        public decimal Total { get; set; }
    }
}
