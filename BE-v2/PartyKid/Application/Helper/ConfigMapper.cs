using AutoMapper;

namespace PartyKid;

public class ConfigMapper : Profile
{
    public ConfigMapper()
    {
        CouponConfiguration();
        AuthConfiguration();
        ServiceCategoryConfiguration();
        ServiceConfiguration();
        UserConfiguration();
        VenueConfiguration();
    }

    private void CouponConfiguration()
    {
        CreateMap<CouponType, CouponTypesResponseDTO>().ReverseMap();
        CreateMap<AddCouponTypeRequest, CouponType>().ReverseMap();
    }

    private void AuthConfiguration()
    {
        CreateMap<RegisterRequestDTO, ApplicationUser>()
        .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email))
        .ForSourceMember(x => x.Password, opt => opt.DoNotValidate())
        .ForSourceMember(x => x.ConfirmPassword, opts => opts.DoNotValidate())
        .ReverseMap();

    }

    private void UserConfiguration()
    {
        CreateMap<UserDTO, ApplicationUser>().ReverseMap();
        CreateMap<UpdateUserBindingModel, ApplicationUser>().ReverseMap();
    }

    private void ServiceCategoryConfiguration()
    {
        CreateMap<CreateServiceCategoryBindingModel, ServiceCategory>().ReverseMap();
        CreateMap<UpdateServiceCategoryBindingModel, ServiceCategory>().ReverseMap();
        CreateMap<ServiceCategory, ServiceCategoryResponseDTO>().ReverseMap();
    }

    private void ServiceConfiguration()
    {
        CreateMap<Service, ServiceResponseDTO>().ReverseMap();
        CreateMap<CreateServiceBindingModel, Service>().ReverseMap();
        CreateMap<UpdateServiceBindingModel, Service>().ReverseMap();
    }

    private void VenueConfiguration()
    {
        CreateMap<VenueResponseDTO, Venue>()
        .ForMember(x => x.District, opt => opt.MapFrom(src => src.District))
        .ForMember(x => x.VenueImages, opt => opt.MapFrom(src => src.VenueImages.Select(x => new VenueImageDTO()
        {
            ImageUrl = x.ImageUrl
        })))
        .ReverseMap();
        CreateMap<CreateVenueBindingModel, Venue>().ReverseMap();
    }
}
