using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Factura
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int PaqueteId { get; set; }

    public DateTime FechaEmision { get; set; }

    public decimal MontoTotal { get; set; }

    public decimal Impuestos { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Paquete Paquete { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
