using AutoMapper;
using BookingService.Maui.Model;
using BookingService.Maui.Model.Address;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiRequest.Company;
using BookingService.Maui.Model.ApiRequest.Post;
using BookingService.Maui.Model.ApiRequest.Reservation;
using BookingService.Maui.Model.ApiRequest.Service;
using BookingService.Maui.Model.ApiRequest.User;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Address;
using BookingService.Maui.Model.ApiResponse.Company;
using BookingService.Maui.Model.ApiResponse.Post;
using BookingService.Maui.Model.ApiResponse.Reservation;
using BookingService.Maui.Model.ApiResponse.Service;
using BookingService.Maui.Model.ApiResponse.User;
using BookingService.Maui.Model.Company;
using BookingService.Maui.Model.Post;
using BookingService.Maui.Model.Reservation;
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
            CreateMap<UserAdministrationResponse, UserAdministration>();
            CreateMap<AddressResponse, Address>().ReverseMap();
            CreateMap<CompanyLightResponse, CompanyLight>().ReverseMap();
            CreateMap<CompanyServiceResponse, CompanyService>().ReverseMap();
            CreateMap<Service, AddServiceRequest>();
            CreateMap<UpdateCompany, UpdateCompanyRequest>();
            CreateMap<UpdateUserRole, UpdateUserRoleRequest>();
            CreateMap<PossibleServiceHourResponse, ServiceTime>();
            CreateMap<ServiceDetailsResponse, ServiceDetails>();
            CreateMap<Service, AddServiceRequest>().ReverseMap();
            CreateMap<Reservation, AddReservationRequest>();
            CreateMap<IncomingReservationViewModel, IncomingReservation>();
            CreateMap<CompletedReservationViewModel, CompletedReservation>();
            CreateMap<CompletedReservationViewModel, CompletedReservation>();
            CreateMap<Post, AddPostRequest>();
            CreateMap<PostViewModel, Post>();
        }
    }
}
