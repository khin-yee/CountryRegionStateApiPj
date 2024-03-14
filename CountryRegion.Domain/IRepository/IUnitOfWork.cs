using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRegion.Domain.IRepository
{
    public  interface IUnitOfWork:IDisposable
    {
        ISRRepository SRRepository { get; }
        int Complete();
    }
}
