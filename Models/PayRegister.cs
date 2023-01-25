using OtherServices2.Models2;

namespace OtherServices2.Models
{
    public class PayRegister
    {
        //
        public PayRegister()
        {
            VigenciaCupos = new HashSet<VigenciaCupo>();
        }
        //

        public int IdPayRegister { get; set; }
        public DateTime PayDate { get; set; }
        public string? PayNumber { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; } = null!;

        //
        public virtual ICollection<VigenciaCupo> VigenciaCupos { get; set; }
        //
    }
}

