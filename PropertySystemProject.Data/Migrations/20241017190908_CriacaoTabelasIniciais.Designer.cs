﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertySystemProject.Data.Context;

#nullable disable

namespace PropertySystemProject.Data.Migrations
{
    [DbContext(typeof(PropertyWebContext))]
    [Migration("20241017190908_CriacaoTabelasIniciais")]
    partial class CriacaoTabelasIniciais
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PropertySystemProject.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("ID");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("CEP");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("City");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar")
                        .HasColumnName("Complement");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("Number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("State");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("Street");

                    b.HasKey("Id");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("PropertySystemProject.Domain.Entities.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("ID");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("AddressId");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Area");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("NumberBathrooms")
                        .HasColumnType("int")
                        .HasColumnName("NumberBathrooms");

                    b.Property<int?>("NumberRooms")
                        .HasColumnType("int")
                        .HasColumnName("NumberRooms");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Title");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("Type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Property", (string)null);
                });

            modelBuilder.Entity("PropertySystemProject.Domain.Entities.Property", b =>
                {
                    b.HasOne("PropertySystemProject.Domain.Entities.Address", "Address")
                        .WithOne("Property")
                        .HasForeignKey("PropertySystemProject.Domain.Entities.Property", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Property_Address");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PropertySystemProject.Domain.Entities.Address", b =>
                {
                    b.Navigation("Property")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
