using AutoMapper;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiResponse;
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
            CreateMap<List<ServicesLightResponse>, List<ServiceLight>>().ReverseMap();
        }
    }
}
