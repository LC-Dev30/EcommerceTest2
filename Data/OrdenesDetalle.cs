using System;
using System.Collections.Generic;

namespace EcommerceTest2.Data;

public partial class OrdenesDetalle
{
    public int Id { get; set; }

    public int IdOrden { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Ordene IdOrdenNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
