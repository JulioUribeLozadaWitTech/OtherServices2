namespace OtherServices2.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseIdMenuPadreNavigation = new HashSet<Menu>();
        }

        public string? Descripcion { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? Accion { get; set; }
        public decimal? Esactivo { get; set; }
        public decimal? IdMenuPadre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal IdMenu { get; set; }

        public virtual Menu? IdMenuPadreNavigation { get; set; }
        public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; set; }
    }
}
