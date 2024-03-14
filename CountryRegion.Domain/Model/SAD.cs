using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Domain.Model
{
    public  class SAD
    {
        public string Id { get; set; }
        public string SRPCode { get; set; }

        public string SRNameEng { get; set; }
        public string SADorSAZcode { get; set; }
        public string SADorSAZNameEng { get; set; }
        public string SADorSAZNameMMR { get; set; }
    }
}
