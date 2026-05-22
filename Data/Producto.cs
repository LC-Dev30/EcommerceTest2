using System;
using System.Collections.Generic;

namespace EcommerceTest2.Data;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Stock { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<OrdenesDetalle> OrdenesDetalles { get; set; } = new List<OrdenesDetalle>();
}
