using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NowaiterApi.Models;

namespace NowaiterApi.DAL.Configurations
{
	public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {

        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");
            // Change as needed for primary key
            builder.HasKey(x => x.StatusId);
            // Configure any foreign keys

            builder.Property(x => x.StatusId)
                .HasColumnName("StatusID")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Drive_Thru)
                .HasColumnName("Drive_Thru")
                .HasColumnType("int");

            builder.Property(x => x.In_Store)
                .HasColumnName("In_Store")
                .HasColumnType("int");

            builder.Property(x => x.RestaurantID)
                .HasColumnName("RestaurantID")
                .HasColumnType("int")
                .IsRequired();
        }
    }

}
