using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NowaiterApi.DAL.Configurations;
using NowaiterApi.Models;

namespace NowaiterApi.DAL
{
    public class NowaiterContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public NowaiterContext(DbContextOptions<NowaiterContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Registering configurations separately 
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());
        }

        
    }
}
