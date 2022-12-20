using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data.MainContext
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employees> Employee { get; set; }

        public DbSet<Department> Department { get; set; }
    }
}
