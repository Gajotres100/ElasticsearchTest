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
                .UseOracle(@"DATA SOURCE=10.0.0.81:1521/FMS02;PASSWORD=manager;PERSIST SECURITY INFO=True;USER ID=DEV_FMS_7X;", 
                options => options.UseOracleSQLCompatibility("11"));
    }
}
