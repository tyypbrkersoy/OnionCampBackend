using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnionCamp.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnionCampDbContext>
    {
       public OnionCampDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnionCampDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
