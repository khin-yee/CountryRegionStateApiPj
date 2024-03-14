using CountryRegion.Domain.Model;


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitytest.Repository
{
    public class DatabaseConnect:DbContext
    {
        public DatabaseConnect(DbContextOptions<DatabaseConnect> options) : base(options)
        {

        }
       
        public DbSet<SR> SR{ get; set; }
        public DbSet<SAD> SAD { get; set; }
        public  DbSet<Town> Town { get; set; }   
        public DbSet<Township> Township { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Ward> Ward { get; set; }
    }
}
