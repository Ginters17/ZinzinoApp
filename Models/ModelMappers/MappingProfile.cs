using AutoMapper;
using MyApp.Models.DomainModels;
using MyApp.Models.ViewModels;

namespace MyApp.Models.ModelMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserViewModel, User>()
                .ForMember(usr => usr.Addresses, opt => opt.MapFrom(view => new List<Address>
                {
                    new() {
                        AddressLine1 = view.AddressLine1,
                        AddressLine2 = view.AddressLine2,
                        City = view.City,
                        State = view.State,
                        ZipCode = view.ZipCode
                    }
                }));
        }
    }
}