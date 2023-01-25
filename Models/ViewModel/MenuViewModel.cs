namespace OtherServices2.Models.ViewModel
{
    public class MenuViewModel
    {
        public string? Descripcion { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? Accion { get; set; }
        public decimal? Esactivo { get; set; }
        public decimal? IdMenuPadre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public List<MenuViewModel> SubMenus { get; set; }
    }
}
