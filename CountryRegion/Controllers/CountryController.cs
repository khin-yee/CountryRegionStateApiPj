using CountryRegion.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CountryRegion.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {

        private readonly ICountryService service;
        public CountryController(ICountryService Service)
        {
            service = Service;
        }

        [HttpGet("GetStateRegionList")]
        public async Task<object> GetAll()
        {
            var result = await service.GetAll();
            return result;
        }
        [HttpGet("GetDistrictbyStatePostCode")]
        public async Task<object>GetDistrictByState(string SRPcode)
        {
            var result = await service.GetDistrictByTownShip(SRPcode);
            return result;
        }
        [HttpGet("GetTownshipbyDistrict")]
        public async Task<object> GetTownshipbyDistrict(string DistrictPcode)
        {
            var result = await service.GetTownshipByDistrict(DistrictPcode);
            return result;
        }

        [HttpGet("GetTownsByTownship")]
        public async Task<object>GetTownsByTownship(string TownshipPcode)
        {
            var result = await service.GetTownsByTownshipCode(TownshipPcode);
            return result;
        
        }
        [HttpGet("GetWardByTown")]
        public async Task<object> GetWardByTown(string Town)
        {
            var result = await service.GetWardByTown(Town);
            return result;
      
        }
    }
}
