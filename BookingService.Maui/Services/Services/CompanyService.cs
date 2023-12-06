using AutoMapper;
using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Company;
using BookingService.Maui.Model.Company;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Services.Interface;

namespace BookingService.Maui.Services.Services
{
    internal class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<ResultModel<CompanyLight?>> GetByUserId(int id)
        {
            var company = await companyRepository.GetCompanyByUserId(id);

            if (!company.Result)
                return new ResultModel<CompanyLight?>(false, null);

            var mappedAddress = mapper.Map<CompanyLight>(company.Value);
            return new ResultModel<CompanyLight?>(true, mappedAddress);
        }

        public async Task<ResultModel<bool>> UpdateCompany(UpdateCompany model)
        {
            var updateCompanyModel = mapper.Map<UpdateCompanyRequest>(model);
            var updateCompanyResponse = await companyRepository.UpdateCompany(updateCompanyModel);

            if (!updateCompanyResponse.Result)
                return new ResultModel<bool>(false, updateCompanyResponse.Message, false);

            return new ResultModel<bool>(true, true);
        }
    }
}
