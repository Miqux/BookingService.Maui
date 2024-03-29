﻿using AutoMapper;
using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Service;
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

        public async Task<ResultModel<List<ServiceLight>>> GetServiceLight(int? serviceType, string? city)
        {
            var services = await serviceRepository.GetServicesLight(serviceType, city);

            if (!services.Result || services.Value is null)
                return new ResultModel<List<ServiceLight>>(false, services.Message, new List<ServiceLight>());

            return new ResultModel<List<ServiceLight>>(true, mapper.Map<List<ServiceLight>>(services.Value));
        }

        public async Task<ResultModel<List<Model.Service.CompanyService>>> GetCompanyServices(int comapnyId)
        {
            var services = await serviceRepository.GetCompanyServices(comapnyId);

            if (!services.Result || services.Value is null)
                return new ResultModel<List<Model.Service.CompanyService>>(false, services.Message, new List<Model.Service.CompanyService>());

            return new ResultModel<List<Model.Service.CompanyService>>(true, mapper.Map<List<Model.Service.CompanyService>>(services.Value));
        }

        public async Task<ResultModel<int?>> AddService(Service model)
        {
            var addServiceModel = mapper.Map<AddServiceRequest>(model);
            var addServiceResult = await serviceRepository.AddService(addServiceModel);

            if (!addServiceResult.Result)
                return new ResultModel<int?>(false, addServiceResult.Message, null);

            return new ResultModel<int?>(true, addServiceResult.Value.Id);
        }

        public async Task<ResultModel<bool>> DeleteService(int id)
        {
            var deleteServiceResponse = await serviceRepository.DeleteService(id);

            if (!deleteServiceResponse.Result)
                return new ResultModel<bool>(false, deleteServiceResponse.Message, false);

            return new ResultModel<bool>(true, true);
        }

        public async Task<ResultModel<ServiceDetails>> GetServiceDetalis(int id)
        {
            var services = await serviceRepository.GetServicesDetails(id);

            if (!services.Result || services.Value is null)
                return new ResultModel<ServiceDetails>(false, services.Message, new ServiceDetails());

            return new ResultModel<ServiceDetails>(true, mapper.Map<ServiceDetails>(services.Value));
        }

        public async Task<ResultModel<List<ServiceTime>>> GetPossibleServiceHours(int id, DateOnly date)
        {
            var services = await serviceRepository.GetPossibleServiceHours(id, date);

            if (!services.Result || services.Value is null)
                return new ResultModel<List<ServiceTime>>(false, services.Message, new List<ServiceTime>());

            return new ResultModel<List<ServiceTime>>(true, mapper.Map<List<ServiceTime>>(services.Value));
        }
    }
}
