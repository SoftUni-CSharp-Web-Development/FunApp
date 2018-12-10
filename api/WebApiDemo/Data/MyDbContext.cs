using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<CityInfo> Cities { get; set; }

        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public static void SeedData(MyDbContext context)
        {
            context.Cities.Add(new CityInfo
            {
                Name = "Sofia",
                Population = 2000000,
                Temperature = -1.5M,
            });
            context.Cities.Add(new CityInfo
            {
                Name = "Plovdiv",
                Population = 500000,
                Temperature = 3.4M,
            });
            context.Cities.Add(new CityInfo
            {
                Name = "Varna",
                Population = 400000,
                Temperature = 5M,
            });
            context.SaveChanges();
        }
    }
}
