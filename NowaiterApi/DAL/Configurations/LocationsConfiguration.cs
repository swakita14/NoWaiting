using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NowaiterApi.Models;

namespace NowaiterApi.DAL.Configurations
{
	public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");
            // Change as needed for primary key
            builder.HasKey(x => x.LocationId);
            // Configure any foreign keys

            builder.Property(x => x.LocationId)
                .HasColumnName("LocationID")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Latitude)
                .HasColumnName("Latitude")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.Longitude)
                .HasColumnName("Longitude")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
                

            builder.Property(x => x.RestaurantID)
                .HasColumnName("RestaurantID")
                .HasColumnType("int")
                .IsRequired();
        }
    }

}
