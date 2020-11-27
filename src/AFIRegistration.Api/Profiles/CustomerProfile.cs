using AFIRegistration.Api.Entities;
using AutoMapper;

namespace AFIRegistration.Api.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Models.CustomerRegistrationDto, Entities.Customer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => CustomerFirstName.Create(src.FirstName).Value))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => CustomerLastName.Create(src.LastName).Value))
                .ForMember(dest => dest.PolicyReferenceNumber, opt =>opt.MapFrom(src => PolicyReferenceNumber.Create(src.PolicyReferenceNumber).Value))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => CustomerDateOfBirth.Create(src.DateOfBirth).Value))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Create(src.Email).Value));
            CreateMap<Entities.Customer, Models.CustomerRegistrationDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Value))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
                .ForMember(dest => dest.PolicyReferenceNumber, opt => opt.MapFrom(src => src.PolicyReferenceNumber.Value));

            CreateMap<Entities.Customer, Models.CustomerDto>();
        }
    }
}
