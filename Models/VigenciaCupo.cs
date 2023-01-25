using OtherServices2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models2
{
    public partial class VigenciaCupo
    {
        public int IdVigencia { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime FechaDesde { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime FechaHasta { get; set; }
        public string? Jornada { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public string DocIdentTercero { get; set; } = null!;
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdCupo { get; set; }
        public string? TipoVehiculo { get; set; }
        public string? Placa { get; set; }
        public int? IdService { get; set; }
        public int? IdPayRegister { get; set; }
        public virtual Funcionario DocIdentTerceroNavigation { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; } = null!;
        public virtual Cupo IdCupoNavigation { get; set; } = null!;
        public virtual Servicio? IdServiceNavigation { get; set; }
        public virtual PayRegister? IdPayRegisterNavigation { get; set; }
    }
}
