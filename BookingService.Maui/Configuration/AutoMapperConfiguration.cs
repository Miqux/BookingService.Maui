using AutoMapper;
using BookingService.Maui.Model;
using BookingService.Maui.Model.Address;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiRequest.Service;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Address;
using BookingService.Maui.Model.ApiResponse.Company;
using BookingService.Maui.Model.ApiResponse.Service;
using BookingService.Maui.Model.Company;
using BookingService.Maui.Model.Service;
using BookingService.Maui.Model.User;

namespace BookingService.Maui.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<RegisterUser, RegisteryRequest>().ReverseMap();
            CreateMap<ServicesLightResponse, ServiceLight>().ReverseMap();
            CreateMap<ServicesLightResponse, ServiceLight>();
            CreateMap<AddressResponse, Address>().ReverseMap();
            CreateMap<CompanyLightResponse, CompanyLight>().ReverseMap();
            CreateMap<CompanyServiceResponse, CompanyService>().ReverseMap();
            CreateMap<Service, AddServiceRequest>();
            CreateMap<PossibleServiceHourResponse, ServiceTime>();
            CreateMap<ServiceDetailsResponse, ServiceDetails>();
            CreateMap<Service, AddServiceRequest>().ReverseMap();
        }
    }
}
