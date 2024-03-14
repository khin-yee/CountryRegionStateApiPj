
using CountryRegion.Domain.IRepository;
using Entitytest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAAdminPortal.Repository.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseConnect _context;
        public ISRRepository SRRepository { get; }

        public ISRRepository sRRepository { get; }

        public UnitOfWork(DatabaseConnect context,ISRRepository SRRepository)
        {
            this._context = context;
            this.SRRepository = SRRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
