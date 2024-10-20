using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertySystemProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Data.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder.Property(e => e.Street)
                .HasColumnName("Street")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(e => e.Number)
                .HasColumnName("Number")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.City)
                .HasColumnName("City")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.State)
                .HasColumnName("State")
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Property(e => e.CEP)
                .HasColumnName("CEP")
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property(e => e.Complement)
                .HasColumnName("Complement")
                .HasColumnType("varchar(200)")
                .IsRequired(false);

            builder.HasOne(e => e.Property)
            .WithOne(p => p.Address)
            .HasForeignKey<Property>(p => p.AddressId);
        }
    }
}
