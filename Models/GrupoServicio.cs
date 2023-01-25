using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models;

public partial class GrupoServicio
{
    //
    public GrupoServicio()
    {
        Servicios = new HashSet<Servicio>();
    }
    //
    [Required(ErrorMessage = "Campo Requerido")]

    public string IdGrupo { get; set; } = null!;

    [Required(ErrorMessage = "Campo Requerido")]
    public string Descripcion { get; set; } = null!;

    [Required(ErrorMessage = "Campo Requerido")]
    public string IdTipoServicio { get; set; } = null!;

    public byte[] thumbnails { get; set; }
    public DateTime? FechaRegistro { get; set; }

    //
    public virtual ICollection<Servicio> Servicios { get; } = new List<Servicio>();
    //
    public virtual TipoServicio IdTipoServicioNavigation { get; set; } = null!;

}
