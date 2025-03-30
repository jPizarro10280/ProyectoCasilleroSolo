using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class PrealertaPaquete
{
    public int Id { get; set; }

    public int PrealertaId { get; set; }

    public int PaqueteId { get; set; }

    public virtual Paquete Paquete { get; set; } = null!;

    public virtual Prealertum Prealerta { get; set; } = null!;
}
