using CountryRegion.Domain.IRepository;
using CountryRegion.Domain.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Service
{
    public class CountryService:ICountryService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ILogger<CountryService> _logger;
        public CountryService(IUnitOfWork unitOfWork,ILogger<CountryService> logger)
        {
            _unitofwork = unitOfWork;
            _logger = logger;
        }
        public async Task<object> GetAll()
        {
            return await _unitofwork.SRRepository.GetAll();
        }
        public async Task<object> GetDistrictByTownShip(string SRPcode)
        {
            _logger.LogInformation("Get District Request with SRPcode:{SRPcode} ", SRPcode);
            var response = await _unitofwork.SRRepository.GetDistrictByTownShip(SRPcode);
            _logger.LogInformation("District list Response {@response} for SRPcode:{SRPcode} ",response,SRPcode);
            return response;
        }
        public async Task<object>GetTownshipByDistrict(string DistrictPcode)
        {
            _logger.LogInformation("Get Township Request with District : {DistrictPcode}",DistrictPcode);
            var response =  await _unitofwork.SRRepository.GetTownshipByDistrict(DistrictPcode);
            _logger.LogInformation("Township Response {@response} for DistrictPcode :{DistrictPcode}",response,DistrictPcode);
            return response;
        }
        public async Task<object> GetTownsByTownshipCode(string townshipcode)
        {
            _logger.LogInformation("Get Town Request with township :{townshipcode}", townshipcode);
           var response = await _unitofwork.SRRepository.GetTownsByTownship(townshipcode);
            _logger.LogInformation("Town Response {response} for townshipcode:{townshipcode}", response, townshipcode);
            return response;
        }
        public async Task<object> GetWardByTown (string Town)
        {
            _logger.LogInformation("Get Wards with Town Code {@Town}", Town);
            return await _unitofwork.SRRepository.GetWardByTown(Town);
        }
      
    }
}
