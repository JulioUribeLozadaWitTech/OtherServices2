using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtherServices2.Models2;

public partial class ServicePortal
{
    public int IdServicePortal { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    public string? ServiceName { get; set; }


    public string? ServiceThumbnail { get; set; }
    //public byte[]? ServiceThumbnail { get; set; }


    public string? ServiceDescription { get; set; }

    public string? TypeProcedure { get; set; }

    public string? TypeProcedureThumb { get; set; }

    public bool? Cost { get; set; }

    public string? TypeCostThumb { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    public int TimeMinute { get; set; }

    public string? TypeTimeThumb { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    public string WhenToDo { get; set; } = null!;

    public string? WhenToDoThumb { get; set; }

    public bool? Parameter { get; set; }

    public bool? LoginRequired { get; set; }

    public string? Href { get; set; }

    public short? OrderList { get; set; }
}
