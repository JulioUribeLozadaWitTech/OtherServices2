using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OtherServices2.Models.ViewModel;
using OtherServices2.Models;

namespace OtherServices2.Utiles
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly BillOtherServicesContext _context;
        private readonly IMapper _mapper;

        public MenuViewComponent(IMapper mapper, BillOtherServicesContext Context)
        {
            _mapper = mapper;
            _context = Context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IQueryable<Menu> tbMenu = _context.Set<Menu>();
            IQueryable<Menu> MenuPadre = (from m in tbMenu
                                          where m.IdMenuPadre == null
                                          select m).Distinct().AsQueryable();
            IQueryable<Menu> MenuHijos = (from m in tbMenu
                                          where m.IdMenu != m.IdMenuPadre
                                          select m).Distinct().AsQueryable();
            List<Menu> listaMenu = (from mpadre in MenuPadre
                                    select new Menu
                                    {
                                        Descripcion = mpadre.Descripcion,
                                        Accion = mpadre.Accion,
                                        Controlador = mpadre.Controlador,
                                        Esactivo = mpadre.Esactivo,
                                        FechaRegistro = mpadre.FechaRegistro,
                                        Icono = mpadre.Icono,
                                        InverseIdMenuPadreNavigation = (from mhijo in MenuHijos
                                                                        where mhijo.IdMenuPadre == mpadre.IdMenu
                                                                        select mhijo).ToList()
                                    }).ToList();
            var listaMenus = _mapper.Map<List<MenuViewModel>>(listaMenu);
            return View(listaMenus);
        }
    }
}

