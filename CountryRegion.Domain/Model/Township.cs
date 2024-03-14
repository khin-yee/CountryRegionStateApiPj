using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Domain.Model
{
    public  class Township
    {
        public int Id { get; set; }
        public string SRPcode { get; set; }

        public string SRNameEng { get; set; }
        public string DistrictorSAZPcode { get; set; }
        public string DistrictorSAZNameEng { get; set; }
        public string TspPcode { get; set; }
        public string TownshipNameEng { get; set; }
        public string TownshipNameMMR { get; set; }
    }
}
