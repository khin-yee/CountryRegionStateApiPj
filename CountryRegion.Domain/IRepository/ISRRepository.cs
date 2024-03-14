using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Domain.IRepository
{
    public  interface ISRRepository
    {
        public Task<object> GetAll();
        public Task<object> GetDistrictByTownShip(string name);
        public Task<object> GetTownshipByDistrict(string DistrictPcode);
        public Task<object> GetTownsByTownship(string Townshipcode);
        public Task<object> GetWardByTown(string Town);
    }
}
