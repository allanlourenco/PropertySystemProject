using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertySystemProject.Domain.Entities;

namespace PropertySystemProject.Data.Mapping
{
    public class PropertyMapping : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnName("Type")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Area)
                .HasColumnName("Area")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.NumberRooms)
                .HasColumnName("NumberRooms")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(p => p.NumberBathrooms)
                .HasColumnName("NumberBathrooms")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(p => p.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("Status")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.AddressId)
                .HasColumnName("AddressId")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder.HasOne(p => p.Address)
            .WithOne(a => a.Property)
            .HasForeignKey<Property>(p => p.AddressId)
            .HasConstraintName("FK_Property_Address")
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
