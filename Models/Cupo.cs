using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models2
{
    public partial class Cupo
    {
        public Cupo()
        {
            VigenciaCupos = new HashSet<VigenciaCupo>();
        }
        public int IdCupo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Area { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public int NoCupoArea { get; set; }
        public string? DocIdentTercero { get; set; } = null!;
        
        //public DateTime FechaDesde { get; set; }
        //public DateTime FechaHasta{ get; set; }

        public virtual Funcionario DocIdentTerceroNavigation { get; set; } = null!;

        //
        public virtual ICollection<VigenciaCupo> VigenciaCupos { get; set; }
        //

    }
}
