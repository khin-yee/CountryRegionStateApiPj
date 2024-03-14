using CountryRegion.Domain.IRepository;
using CountryRegion.Domain.Model;
using Entitytest.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Repository
{
    public class Repository:ISRRepository
    {
        private readonly DatabaseConnect _connection;
        //protected readonly IMapper _mapper;
        public Repository(DatabaseConnect connection)
        {
            _connection = connection;
        }

        public async  Task<object> GetAll()
        {
            var SRlist = await _connection.SR.ToListAsync();
            return SRlist;
        }

        public async Task<object> GetDistrictByTownShip(string SRPcode)
        {
            var SRList2 = await _connection.District.Where(d => d.SR == SRPcode).ToListAsync();
            return SRList2;
        }
        public async Task<object>GetTownshipByDistrict(string DistrictPcode)
        {

            var District = await _connection.Township.Where(t => t.DistrictorSAZPcode == DistrictPcode).ToListAsync();
            if(District.Count == 0)
            {
                District = await _connection.Township.Where(t => t.SRPcode == DistrictPcode).ToListAsync();
            }
            return District;

        }
        public async Task<object> GetTownsByTownship(string TownshipPcode)
        {

            var Towns = await _connection.Town.Where(t => t.TspPcode == TownshipPcode).ToListAsync();
          
            if (Towns.Count == 0)
            {
                Towns = await _connection.Town.Where(t=>t.DistrictPcode == TownshipPcode).ToListAsync();
            }
            if (Towns.Count==0)
            {
                Towns = await _connection.Town.Where(t => t.SRPcode == TownshipPcode).ToListAsync();
              
            }      
            return Towns;
        }
        public async Task<object>GetWardByTown(string Town)
        {

            var Ward = await _connection.Ward.Where(w => w.TownPcode == Town).ToListAsync();
            if (Ward.Count == 0)
            {
                Ward = await _connection.Ward.Where(w => w.TspPcode == Town).ToListAsync();
            }
            if (Ward.Count == 0)
            {
                Ward = await _connection.Ward.Where(w => w.DistrictPcode == Town).ToListAsync();
            }
            if (Ward.Count == 0)
            {
                Ward = await _connection.Ward.Where(w => w.SRPcode == Town).ToListAsync();
            }
              
            return Ward;
        }

    }
}
