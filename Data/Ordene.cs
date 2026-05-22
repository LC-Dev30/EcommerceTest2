using System;
using System.Collections.Generic;

namespace EcommerceTest2.Data;

public partial class Ordene
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Facturacion> Facturacions { get; set; } = new List<Facturacion>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<OrdenesDetalle> OrdenesDetalles { get; set; } = new List<OrdenesDetalle>();
}
