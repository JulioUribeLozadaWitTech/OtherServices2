using OtherServices2.Models2;
using System;
using System.Collections.Generic;

namespace OtherServices2.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            VigenciaCupos = new HashSet<VigenciaCupo>();
        }

        public int IdService { get; set; }
        public string Codigo { get; set; } = null!;
        public string IdGrupo { get; set; } = null!;
        public string IdTipoServicio { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Valor { get; set; }

        public virtual ICollection<VigenciaCupo> VigenciaCupos { get; set; }

        //
        public virtual GrupoServicio IdGrupoNavigation { get; set; } = null!;
        public virtual TipoServicio IdTipoServicioNavigation { get; set; } = null!;
        //

    }
}
