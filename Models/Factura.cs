using System;
using System.Collections.Generic;

namespace OtherServices2.Borrar;

public partial class Factura
{
    public string DocUnicoFact { get; set; } = null!;

    public string PrefijoFactura { get; set; } = null!;

    public int NoFactura { get; set; }

    public string CodConvenio { get; set; } = null!;

    public string NombreConvenio { get; set; } = null!;

    public string? Concepto { get; set; }

    public string? Direccion { get; set; }

    public string? Movil { get; set; }

    public string? TipoIdentTercero { get; set; }

    public string? DocIdentTercero { get; set; }

    public string? NombreTercero { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? FechaVence { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaAnulacion { get; set; }

    public string? UsuarioRegistro { get; set; }

    public string? UsuarioAnulacion { get; set; }

    public decimal? VrDcto { get; set; }

    public decimal? VrFactura { get; set; }

    public string? Observacion { get; set; }

    public string EstadoFact { get; set; } = null!;

    public string? DatoResolNum { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactName { get; set; }

    public string? ContactPhone { get; set; }

    public string? Cufe { get; set; }

    public byte[]? CufeImage { get; set; }

    public DateTime? CufeDateEmail { get; set; }

    public virtual ICollection<FacturaDet> FacturaDets { get; } = new List<FacturaDet>();

}
