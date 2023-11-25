using AutoMapper;
using BookingService.Maui.Model;
using BookingService.Maui.Model.Service;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Services.Interface;

namespace BookingService.Maui.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IMapper mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }
        public async Task<ResultModel<List<ServiceLight>>> GetServiceLight()
        {
            var services = await serviceRepository.GetServicesLight();

            if (!services.Result || services.Value is null)
                return new ResultModel<List<ServiceLight>>(false, services.Message, new List<ServiceLight>());

            return new ResultModel<List<ServiceLight>>(true, mapper.Map<List<ServiceLight>>(services));
        }
    }
}
