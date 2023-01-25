using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models2
{
    public partial class Vehiculo
    {
        [Required(ErrorMessage = "Campo Requerido")]
        public string DocIdentTercero { get; set; } = null!;
        public string? Placa { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Tipo { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public string Color { get; set; } = null!;
        public string? Linea { get; set; } 
        public string? Marca { get; set; }
        public bool? Principal { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? UsuarioRegistro { get; set; }
        public virtual Funcionario DocIdentTerceroNavigation { get; set; } = null!;
    }
}
