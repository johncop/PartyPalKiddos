﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace PartyKid;

public class ConfigMapper : Profile
{
    public ConfigMapper()
    {
        //Auth
        AuthConfiguration();

        //Booking
        BookingConfiguration();

        //Coupon
        CouponConfiguration();
        CouponTypeConfiguration();

        //Combo
        ComboConfiguration();

        //District
        DistrictConfiguration();

        //Food
        FoodCategoryConfiguration();
        FoodConfiguration();

        //User
        UserConfiguration();

        //Service
        ServiceConfiguration();
        ServiceCategoryConfiguration();
        ServicePackageConfiguration();

        //Venue
        VenueConfiguration();

        //Timeslot
        TimeSlotConfiguration();
    }

    private void AuthConfiguration()
    {
        CreateMap<RegisterRequestDTO, ApplicationUser>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email))
            .ForSourceMember(x => x.Password, opt => opt.DoNotValidate())
            .ForSourceMember(x => x.ConfirmPassword, opts => opts.DoNotValidate())
            .ReverseMap();
    }

    private void BookingConfiguration()
    {
        CreateMap<Booking, BookingResponseDTO>()
        .ForMember(x => x.Venue, opt => opt.MapFrom(src => src.BookingTimeSlots.Select(x => x.TimeSlot.Venue).FirstOrDefault()))
        .ForMember(x => x.BookingDetail, opt => opt.MapFrom(src => new BookingDetailResponseDTO()
        {
            Combos = src.BookingDetails.Where(x => x.Combo != null).Select(x => new ComboBookingResponseDTO()
            {
                Id = x.ComboId.HasValue ? x.ComboId.Value : 0,
                Name = x.Combo != null ? x.Combo.Name : "",
                Price = x.Combo != null ? x.Combo.Price : 0,
                Quantity = x.ComboQuantity.HasValue ? x.ComboQuantity.Value : 0
            }).ToList(),
            Foods = src.BookingDetails.Where(x => x.Food != null).Select(x => new FoodBookingResponseDTO()
            {
                Id = x.FoodId.HasValue ? x.FoodId.Value : 0,
                Name = x.Food != null ? x.Food.Name : "",
                Price = x.Food != null && x.Food.Price.HasValue ? x.Food.Price.Value : 0,
                Quantity = x.FoodQuantity.HasValue ? x.FoodQuantity.Value : 0
            }).ToList(),
            Services = src.BookingDetails.Where(x => x.Service != null).Select(x => new ServiceBookingResponseDTO()
            {
                Id = x.ServiceId.HasValue ? x.ServiceId.Value : 0,
                Name = x.Service != null ? x.Service.Name : "",
                Price = x.Service != null ? x.Service.Price : 0,
                Quantity = x.ServiceQuantity.HasValue ? x.ServiceQuantity.Value : 0
            }).ToList(),
            ServicePackages = src.BookingDetails.Where(x => x.ServicePackage != null).Select(x => new ServiceBookingResponseDTO()
            {
                Id = x.ServicePackageId.HasValue ? x.ServicePackageId.Value : 0,
                Name = x.ServicePackage != null ? x.ServicePackage.Name : "",
                Price = x.ServicePackage != null ? x.ServicePackage.Price : 0,
                Quantity = x.ServicePackageQuantity.HasValue ? x.ServicePackageQuantity.Value : 0
            }).ToList()
        }));

        CreateMap<CreateBookingBindingModel, Booking>()
            .ForMember(x => x.BookingTimeSlots, opt => opt.Ignore());

        CreateMap<UpdateBookingBindingModel, Booking>()
            .ForMember(x => x.Id, opt => opt.MapFrom((src, dest) => dest.Id))
            .ForMember(x => x.BookingDate, opt => opt.MapFrom((src, dest) => src.BookingDate ?? dest.BookingDate))
            .ForMember(x => x.NumberOfKids, opt => opt.MapFrom((src, dest) => src.NumberOfKids.HasValue ? src.NumberOfKids.Value : dest.NumberOfKids))
            .ForMember(x => x.NumberOfAdults, opt => opt.MapFrom((src, dest) => src.NumberOfAdults.HasValue ? src.NumberOfAdults.Value : dest.NumberOfAdults))
            .ForMember(x => x.BookingStatus, opt => opt.MapFrom((src, dest) => src.BookingStatus ?? dest.BookingStatus))
            .ForMember(x => x.BookingTimeSlots, opt => opt.Ignore())
            .ForMember(x => x.BookingDetails, opt => opt.Ignore());
    }

    private void CouponConfiguration()
    {
        CreateMap<CouponType, CouponTypesResponseDTO>().ReverseMap();
        CreateMap<AddCouponTypeRequest, CouponType>().ReverseMap();
        CreateMap<Coupon, CouponResponseDTO>()
            .ForMember(x => x.CouponType, opt => opt.MapFrom(src => src.CouponType))
            .ReverseMap();

        CreateMap<UpdateCouponBindingModel, Coupon>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description))
            .ForMember(x => x.DiscountAmount, opt => opt.MapFrom((src, dest) => src.DiscountAmount.HasValue ? src.DiscountAmount.Value : dest.DiscountAmount))
            .ForMember(x => x.ConditionAmount, opt => opt.MapFrom((src, dest) => src.ConditionAmount.HasValue ? src.ConditionAmount.Value : dest.ConditionAmount))
            .ForMember(x => x.Quantity, opt => opt.MapFrom((src, dest) => src.Quantity.HasValue ? src.Quantity.Value : dest.Quantity))
            .ForMember(x => x.AvailableDate, opt => opt.MapFrom((src, dest) => src.AvailableDate ?? dest.AvailableDate))
            .ForMember(x => x.ExpiredDate, opt => opt.MapFrom((src, dest) => src.ExpiredDate ?? dest.ExpiredDate))
            .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status ?? dest.Status))
            .ForMember(x => x.CouponTypeId, opt => opt.MapFrom((src, dest) => src.CouponTypeId.HasValue ? src.CouponTypeId.Value : dest.CouponTypeId));
    }

    private void CouponTypeConfiguration()
    {
        CreateMap<CouponType, CouponTypesResponseDTO>();
        CreateMap<AddCouponTypeRequest, CouponType>();

        CreateMap<UpdateCouponTypeRequest, CouponType>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Name) ? src.Name : dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description));


    }

    private void ComboConfiguration()
    {
        CreateMap<Combo, ComboResponseDTO>()
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(x => x.Foods, opt => opt.MapFrom(src => src.ComboFoods.Where(cf => !cf.Food.IsDeleted)));

        CreateMap<AddComboBindingModel, Combo>()
            .ForMember(x => x.ComboFoods, opt => opt.Ignore());

        CreateMap<UpdateComboBindingModel, Combo>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Name) ? src.Name : dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Description) ? src.Description : dest.Description))
            .ForMember(x => x.Price, opt => opt.MapFrom((src, dest) => src.Price.HasValue ? src.Price.Value : dest.Price))
            .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status.HasValue ? src.Status.Value : dest.Status))
            .ForMember(x => x.ImageUrl, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.ImageUrl) ? src.ImageUrl : dest.ImageUrl))
            .ForMember(x => x.ComboFoods, opt => opt.Ignore());

        CreateMap<VenueCombo, ComboDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ComboId))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Combo.Name))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Combo.Price))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Combo.Description))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.Combo.ImageUrl));
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

        CreateMap<UpdateDistrictBindingModel, District>()
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description))
            .ReverseMap();
        CreateMap<District, DistrictDTO>().ReverseMap();
    }

    private void FoodCategoryConfiguration()
    {
        CreateMap<CreateFoodCategoryBindingModel, FoodCategory>().ReverseMap();
        CreateMap<FoodCategory, FoodCategoryResponseDTO>().ReverseMap();
        CreateMap<UpdateFoodCategoryBindingModel, FoodCategory>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description));
    }

    private void FoodConfiguration()
    {
        CreateMap<Food, FoodResponseDTO>().ReverseMap();
        CreateMap<UpdateFoodBindingModel, Food>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description))
            .ForMember(x => x.ImageUrl, opt => opt.MapFrom((src, dest) => src.ImageUrl ?? dest.ImageUrl))
            .ForMember(x => x.Price, opt => opt.MapFrom((src, dest) => src.Price.HasValue ? src.Price.Value : dest.Price))
            .ForMember(x => x.FoodCategoryId, opt => opt.MapFrom((src, dest) => src.FoodCategoryId.HasValue ? src.FoodCategoryId.Value : dest.FoodCategoryId));

        CreateMap<CreateFoodBindingModel, Food>()
            .ForMember(x => x.FoodCategoryId, opt => opt.MapFrom(src => src.FoodCategoryId))
            .ReverseMap();

        CreateMap<ComboFood, FoodResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.FoodId))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Food.Name))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Food.Price))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Food.Description))
            .ForMember(x => x.ImageUrl, opt => opt.MapFrom(src => src.Food.ImageUrl))
            .ForMember(x => x.FoodCategory, opt => opt.MapFrom(src => src.Food.FoodCategory));


        CreateMap<BookingDetail, FoodBookingResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.FoodId))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Food.Price))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Food.Name))
            .ForMember(x => x.Quantity, opt => opt.MapFrom(src => src.FoodQuantity));

        CreateMap<VenueFood, FoodResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.FoodId))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Food.Description))
            .ForMember(x => x.ImageUrl, opt => opt.MapFrom(src => src.Food.ImageUrl))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Food.Price))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Food.Name))
            .ForMember(x => x.FoodCategory, opt => opt.MapFrom(src => src.Food.FoodCategory));
    }

    private void UserConfiguration()
    {
        CreateMap<ApplicationUser, UserDTO>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(src => src.LastName + " " + src.FirstName))
            .ForMember(x => x.DisplayName, opt => opt.MapFrom(src => src.LastName + " " + src.FirstName))
            .ReverseMap();

        CreateMap<UpdateUserBindingModel, ApplicationUser>().ReverseMap();
        CreateMap<IdentityRole<int>, RolesResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));
    }

    private void ServiceCategoryConfiguration()
    {
        CreateMap<CreateServiceCategoryBindingModel, ServiceCategory>();
        CreateMap<UpdateServiceCategoryBindingModel, ServiceCategory>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description));

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

        CreateMap<UpdateServiceBindingModel, Service>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => src.Name ?? dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => src.Description ?? dest.Description))
            .ForMember(x => x.Image, opt => opt.MapFrom((src, dest) => src.Image ?? dest.Image))
            .ForMember(x => x.Price, opt => opt.MapFrom((src, dest) => src.Price.HasValue ? src.Price.Value : dest.Price))
            .ForMember(x => x.ServiceCategoryId, opt => opt.MapFrom((src, dest) => src.ServiceCategoryId.HasValue ? src.ServiceCategoryId.Value : dest.ServiceCategoryId));

        CreateMap<Service, ServiceBookingResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
            .ReverseMap();

        CreateMap<ServicePackageDetail, ServiceResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ServiceId))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Service.Name))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Service.Price))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Service.Description))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.Service.Image))
            .ForMember(x => x.ServiceCategory, opt => opt.MapFrom(src => src.Service.ServiceCategory));

        CreateMap<VenueService, ServiceResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ServiceId))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Service.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Service.Description))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Service.Price))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.Service.Image))
            .ForMember(x => x.ServiceCategory, opt => opt.MapFrom(src => src.Service.ServiceCategory))
            .ReverseMap();

        CreateMap<Service, SearchItemResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.Image));
    }

    private void ServicePackageConfiguration()
    {
        CreateMap<CreateServicePackageBindingModel, ServicePackage>()
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(x => x.Images, opt => opt.Ignore())
            .ForMember(x => x.Services, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateServicePackageBindingModel, ServicePackage>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Name) ? src.Name : dest.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Description) ? src.Description : dest.Description))
            .ForMember(x => x.Price, opt => opt.MapFrom((src, dest) => src.Price.HasValue ? src.Price.Value : dest.Price))
            .ForMember(x => x.Images, opt => opt.Ignore())
            .ForMember(x => x.Services, opt => opt.Ignore())
            .ForMember(x => x.Status, opt => opt.MapFrom((src, dest) => src.Status.HasValue ? src.Status.Value : dest.Status));

        CreateMap<ServicePackageImage, ServicePackageImageDTO>();
        CreateMap<ServicePackage, ServicePackageResponseDTO>()
            .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(x => x.Images, opt => opt.MapFrom(src => src.Images.Select(x => new ServicePackageImageDTO()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl
            })))
            .ForMember(x => x.Services, opt => opt.MapFrom(src => src.Services))
            .ReverseMap();

        CreateMap<VenueServicePackage, ServicePackageDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ServicePackageId))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.ServicePackage.Name))
            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.ServicePackage.Price))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.ServicePackage.Description))
            .ForMember(x => x.Images, opt => opt.MapFrom(src => src.ServicePackage.Images.Select(x => new ServicePackageImageDTO()
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl
            })))
            .ReverseMap();
    }

    private void VenueConfiguration()
    {
        CreateMap<VenueImage, VenueImageDTO>().ReverseMap();
        CreateMap<Venue, VenueResponseDTO>()
            .ForMember(x => x.District, opt => opt.MapFrom(src => src.District))
            .ForMember(x => x.VenueImages, opt => opt.MapFrom(src => src.VenueImages.Select(x => new VenueImageDTO()
            {
                ImageUrl = x.ImageUrl
            })))
            .ForMember(x => x.Foods, opt => opt.MapFrom(src => src.VenueFoods))
            .ForMember(x => x.Combos, opt => opt.MapFrom(src => src.VenueCombos))
            .ForMember(x => x.Services, opt => opt.MapFrom(src => src.VenueServices))
            .ForMember(x => x.ServicePackages, opt => opt.MapFrom(src => src.VenueServicePackages))
            .ForMember(x => x.TimeSlots, opt => opt.MapFrom(src => src.TimeSlots));

        CreateMap<AddVenueBindingModel, Venue>()
            .ForMember(x => x.DistrictId, opt => opt.MapFrom(src => src.DisctrictId))
            .ForMember(x => x.OpenHour, opt => opt.MapFrom(src => TimeSpan.Parse(src.OpenHour)))
            .ForMember(x => x.CloseHour, opt => opt.MapFrom(src => TimeSpan.Parse(src.CloseHour)))
            .ForMember(x => x.VenueImages, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateVenueBindingModel, Venue>()
            .ForMember(x => x.Name, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Name) ? src.Name : dest.Name))
            .ForMember(x => x.Address, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Address) ? src.Address : dest.Address))
            .ForMember(x => x.DistrictId, opt => opt.MapFrom((src, dest) => src.DisctrictId.HasValue ? src.DisctrictId.Value : dest.DistrictId))
            .ForMember(x => x.Description, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Description) ? src.Description : dest.Description))
            .ForMember(x => x.OpenHour, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.OpenHour) ? TimeSpan.Parse(src.OpenHour) : dest.OpenHour))
            .ForMember(x => x.CloseHour, opt => opt.MapFrom((src, dest) => !string.IsNullOrEmpty(src.CloseHour) ? TimeSpan.Parse(src.CloseHour) : dest.CloseHour))
            .ForMember(x => x.VenueImages, opt => opt.Ignore())
            .ForMember(x => x.VenueCombos, opt => opt.Ignore())
            .ForMember(x => x.VenueFoods, opt => opt.Ignore())
            .ForMember(x => x.VenueServices, opt => opt.Ignore())
            .ForMember(x => x.VenueServicePackages, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<Venue, SearchItemResponseDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.VenueImages.FirstOrDefault().ImageUrl));

        CreateMap<Venue, VenueSearchResponseDTO>()
            .ForMember(x => x.Venues, opt => opt.Ignore())
            .ForMember(x => x.Services, opt => opt.MapFrom((src, desc) => src.VenueServices != null ? src.VenueServices.Select(x => new SearchItemResponseDTO()
            {
                Id = x.Service.Id,
                Name = x.Service.Name,
                Image = x.Service.Image
            }).ToList() : null));

        CreateMap<Venue, VenuesResponseDTO>()
            .ForMember(x => x.District, opt => opt.MapFrom(src => src.District))
            .ForMember(x => x.Image, opt => opt.MapFrom(src => src.VenueImages.FirstOrDefault()));
    }

    private void TimeSlotConfiguration()
    {
        CreateMap<AddTimeSlotBindingModel, TimeSlot>()
            .ForMember(x => x.StartTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.StartTime)))
            .ForMember(x => x.EndTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)));

        CreateMap<TimeSlot, TimeSlotsResponseDTO>();
    }
}
