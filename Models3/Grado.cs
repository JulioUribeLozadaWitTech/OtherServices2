using System;
using System.Collections.Generic;

namespace OtherServices2.Models3;

public partial class Grado
{
    public int IdGrado { get; set; }

    public string FuerzaMilitar { get; set; } = null!;

    public string TipoPlanta { get; set; } = null!;

    public string Grado1 { get; set; } = null!;
}
