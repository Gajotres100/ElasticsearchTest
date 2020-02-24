using Microsoft.EntityFrameworkCore;
using Persistance.EntityFramework.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.EntityFramework
{
    public class Context : DbContext
    {

        public DbSet<RepDataDrivers> RepDataDrivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseOracle(@"DATA SOURCE=10.70.54.44:1521/ORCL;PASSWORD=manager;PERSIST SECURITY INFO=True;USER ID=FMS_PLUS;", 
                options => options.UseOracleSQLCompatibility("11"));
    }
}
