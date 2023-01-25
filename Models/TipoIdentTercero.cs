using System;
using System.Collections.Generic;

namespace OtherServices2.Models;

public partial class TipoIdentTercero
{
    public string TipoIdentTercero1 { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Tercero> Terceros { get; } = new List<Tercero>();
}
