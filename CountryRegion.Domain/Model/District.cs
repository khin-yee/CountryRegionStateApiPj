using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Domain.Model
{
    public  class District
    {
        public int Id { get; set; }
        public string SR { get; set; }
        public string SRNameEng { get; set; }
        public string DistrictPcode { get; set; }
        public string DistrictNameEng { get; set; }
        public string DistrictNameMMR { get; set; }


    }
}
