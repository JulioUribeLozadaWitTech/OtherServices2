using System;
using System.Collections.Generic;

namespace OtherServices2.Borrar;

public partial class FacturaDet
{
    public int IdFacturaDet { get; set; }

    public string DocUnicoFact { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Cant { get; set; }

    public decimal VrItem { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string? MedioPago { get; set; }

    public virtual Factura DocUnicoFactNavigation { get; set; } = null!;
}
