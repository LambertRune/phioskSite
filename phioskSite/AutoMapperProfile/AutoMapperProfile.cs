using AutoMapper;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.ViewModels;

namespace PhioskSite.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Phone, PhoneVM>();
            CreateMap<Order, OrderVM>();
            //.ForMember(dest => dest.InvoiceDate, opt => opt.MapFrom(src => src.InvoiceDate))
            //.ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate))
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }

    }
}
