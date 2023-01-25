using AutoMapper;
using OtherServices2.Models.ViewModel;
using OtherServices2.Models;

namespace OtherServices2.Utiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Menu, MenuViewModel>()
           .ForMember(destino => destino.SubMenus,
           opt => opt.MapFrom(origen => origen.InverseIdMenuPadreNavigation));
        }
    }
}
