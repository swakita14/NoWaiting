using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NowaiterApi.Models;

namespace NowaiterApi.DAL.Configurations
{
	public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {

            builder.ToTable("Restaurant");
            // Change as needed for primary key
            builder.HasKey(x => x.RestaurantId);
            // Configure any foreign keys

            builder.Property(x => x.RestaurantId)
                .HasColumnName("RestaurantID")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar").HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.Address1)
                .HasColumnName("Address1")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.Address2)
                .HasColumnName("Address2")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.DateUpdated)
                .HasColumnName("DateUpdated")
                .HasColumnType("datetime");

            builder.Property(x => x.GooglePlaceID)
                .HasColumnName("GooglePlaceID")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
        }
    }

}
