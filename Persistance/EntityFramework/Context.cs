using Microsoft.EntityFrameworkCore;
using Persistance.EntityFramework.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.EntityFramework
{
    public class Context : DbContext, IContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Addresses> Addresses { get; set; }

    }
}
