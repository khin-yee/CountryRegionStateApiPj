using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Domain.IServices
{
    public interface ICountryService
    {
        Task<object> GetAll();
        Task<object> GetDistrictByTownShip(string SRPCode);
        Task<object> GetTownshipByDistrict(string DistrictPcode);
        Task<object> GetTownsByTownshipCode(string townshipcode);

        Task<object> GetWardByTown(string Town);
    }
}
