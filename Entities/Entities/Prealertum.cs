using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Prealertum
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string NumeroSeguimiento { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Peso { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<PrealertaPaquete> PrealertaPaquetes { get; set; } = new List<PrealertaPaquete>();

    public virtual Usuario Usuario { get; set; } = null!;
}
