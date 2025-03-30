using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Paquete
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Estado { get; set; } = null!;

    public decimal? MontoTotal { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<PrealertaPaquete> PrealertaPaquetes { get; set; } = new List<PrealertaPaquete>();

    public virtual Usuario Usuario { get; set; } = null!;
}
