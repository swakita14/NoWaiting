using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Models;

namespace NowaiterApi.DAL
{
    public class NowaiterContext : DbContext
    {
        public NowaiterContext(DbContextOptions<NowaiterContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Status> Statuses { get; set; }

        
    }
}
