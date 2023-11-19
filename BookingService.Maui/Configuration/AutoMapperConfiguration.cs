using AutoMapper;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.User;

namespace BookingService.Maui.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<UserResponse, User>().ReverseMap();
        }
    }
}
