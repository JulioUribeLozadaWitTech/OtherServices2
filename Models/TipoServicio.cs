using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models;

public partial class TipoServicio
{
    public TipoServicio()
    {
        Servicios = new HashSet<Servicio>();
    }

    [Required(ErrorMessage = "Campo Requerido")]
    public string IdTipoServicio { get; set; } = null!;
    [Required(ErrorMessage = "Campo Requerido")]
    public string TipoServicio1 { get; set; } = null!;
    public DateTime? FechaRegistro { get; set; }
    public virtual ICollection<Servicio> Servicios { get; } = new List<Servicio>();
    public virtual ICollection<GrupoServicio> GrupoServicios { get; set; }
}
