using System.ComponentModel;
using AutoMapper;

namespace PartyKid;

public class ConfigMapper : Profile
{
    public ConfigMapper()
    {
        //Auth
        AuthConfiguration();

        //Coupon
        CouponConfiguration();

        //District
        DistrictConfiguration();

        //Food
        FoodConfiguration();

        //Venue
        VenueConfiguration();

        //Service
        ServiceConfiguration();
        ServiceCategoryConfiguration();
        ServicePackageConfiguration();

        //User
        UserConfiguration();


    }

    private void CouponConfiguration()
    {
        CreateMap<CouponType, CouponTypesResponseDTO>().ReverseMap();
        CreateMap<AddCouponTypeRequest, CouponType>().ReverseMap();
        CreateMap<Coupon, CouponResponseDTO>()
            .ForMember(x => x.CouponType, opt => opt.MapFrom(src => src.CouponType))
            .ReverseMap();
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
        CreateMap<Service, ServiceResponseDTO>()
            .ForMember(x => x.ServiceCategory, opt => opt.MapFrom(src => src.ServiceCategory))
            .ReverseMap();

        CreateMap<CreateServiceBindingModel, Service>()
            .ForMember(x => x.ServiceCategoryId, opt => opt.MapFrom(src => src.ServiceCategoryId))
            .ReverseMap();

        CreateMap<UpdateServiceBindingModel, Service>().ReverseMap();
    }

    private void VenueConfiguration()
    {
        CreateMap<VenueImage, VenueImageDTO>().ReverseMap();
        CreateMap<VenueResponseDTO, Venue>()
            .ForMember(x => x.District, opt => opt.MapFrom(src => src.District))
            .ForMember(x => x.VenueImages, opt => opt.MapFrom(src => src.VenueImages.Select(x => new VenueImageDTO()
            {
                ImageUrl = x.ImageUrl
            })))
            .ReverseMap();

        CreateMap<AddVenueBindingModel, Venue>()
            .ForMember(x => x.DistrictId, opt => opt.MapFrom(src => src.DisctrictId))
            .ForMember(x => x.OpenHour, opt => opt.MapFrom(src => TimeSpan.Parse(src.OpenHour)))
            .ForMember(x => x.CloseHour, opt => opt.MapFrom(src => TimeSpan.Parse(src.CloseHour)))
            .ReverseMap();

        CreateMap<UpdateVenueBindingModel, Venue>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.DistrictId, opt => opt.MapFrom(src => src.DisctrictId))
            .ForMember(x => x.OpenHour, opt => opt.MapFrom(src => TimeSpan.Parse(src.OpenHour)))
            .ForMember(x => x.CloseHour, opt => opt.MapFrom(src => TimeSpan.Parse(src.CloseHour)))
            .ReverseMap();
    }

    private void DistrictConfiguration()
    {
        CreateMap<AddDistrictBindingModel, District>().ReverseMap();
        CreateMap<District, DistrictResponseDTO>()
            .ForMember(x => x.Venues, opt => opt.MapFrom(src => src.Venues.Select(x => new VenueResponseDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Address = x.Address
            })))
            .ReverseMap();
        CreateMap<UpdateDistrictBindingModel, District>().ReverseMap();
        CreateMap<District, DistrictDTO>().ReverseMap();
    }

    private void ServicePackageConfiguration()
    {
        CreateMap<CreateServicePackageBindingModel, ServicePackage>().ReverseMap();
        CreateMap<ServicePackage, ServicePackageResponseDTO>()
            .ForMember(x => x.Status, opt => opt.MapFrom(src => nameof(src.Status)))
            .ForMember(x => x.Images, opt => opt.MapFrom(src => src.Images.Select(x => new ServicePackageImageDTO()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl
            })))
            .ReverseMap();
    }

    private void FoodConfiguration()
    {
        CreateMap<CreateFoodCategoryBindingModel, FoodCategory>().ReverseMap();
        CreateMap<FoodCategory, FoodCategoryResponseDTO>().ReverseMap();
        CreateMap<CreateFoodBindingModel, Food>()
            .ForMember(x => x.FoodCategoryId, opt => opt.MapFrom(src => src.FoodCategoryId))
            .ReverseMap();
        CreateMap<UpdateFoodCategoryBindingModel, FoodCategory>()
            .ReverseMap()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
    }
}
