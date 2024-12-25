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
        }

    }
}
