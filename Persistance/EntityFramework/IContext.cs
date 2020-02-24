using Microsoft.EntityFrameworkCore;
using Persistance.EntityFramework.Entitys;

namespace Persistance.EntityFramework
{
    public interface IContext
    {
        DbSet<Addresses> Addresses { get; set; }
    }
}