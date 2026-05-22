using System;
using System.Collections.Generic;

namespace EcommerceTest2.Data;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();
}
