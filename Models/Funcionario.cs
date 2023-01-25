using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models2
{
    public partial class Funcionario
    {
        [Required(ErrorMessage = "Campo Requerido")]
        public string DocIdentTercero { get; set; } = null!;
        public string TipoIdentTercero { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string? Vinculacion { get; set; }
        public string? Movil { get; set; }
        public string? MaritalStatus { get; set; }

        //public string? CodOccupation { get; set; }

        public string? CodMpioDomicilio { get; set; }
        public string? BarrioDomicilio { get; set; }
        public string? DireccionDomicilio { get; set; }
        public string? TelefonoAlterno { get; set; }
        public string? Genero { get; set; }
        public string? Fax { get; set; }
        public string? TelefonoDomicilio { get; set; }

        //public string? Nombre { get; set; }

        public string? CorreoPersonal { get; set; }
        public string? CorreoCorporativo { get; set; }
        public string? CodPaisDomicilio { get; set; }
        public string? Zona { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? PostalCode { get; set; }
        public string? DocUnicoTercero { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? CodArl { get; set; }
        public string? CodFondoP { get; set; }
        public string? CodFondoCes { get; set; }
        public string? CodInstEduc { get; set; }
        public string? CodNivel { get; set; }
        public string? CodTipoVinc { get; set; }

        public virtual ICollection<Cupo> Cupos { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
        public virtual ICollection<VigenciaCupo> VigenciaCupos { get; set; }

    }
}
