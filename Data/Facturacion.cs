using System;
using System.Collections.Generic;

namespace BackEcommerce.Data;

public partial class Facturacion
{
    public int Id { get; set; }

    public string Numeracion { get; set; } = null!;

    public int IdOrden { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Ordene IdOrdenNavigation { get; set; } = null!;
}
