﻿// <auto-generated />
using System;
using FinalProjectExampleOne.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProjectExampleOne.Migrations
{
    [DbContext(typeof(ContactsAPIDBContext))]
    partial class ContactsAPIDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinalProjectExampleOne.Models.Amplifier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("AmplifierCost")
                        .HasColumnType("real");

                    b.Property<string>("AmplifierManufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmplifierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmplifierType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amplifiers");
                });

            modelBuilder.Entity("FinalProjectExampleOne.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CollegeProgram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearInProgram")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("FinalProjectExampleOne.Models.Guitar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("GuitarCost")
                        .HasColumnType("real");

                    b.Property<string>("GuitarManufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuitarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuitarType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guitars");
                });

            modelBuilder.Entity("FinalProjectExampleOne.Models.Pedal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("PedalCost")
                        .HasColumnType("real");

                    b.Property<string>("PedalManufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PedalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PedalType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pedals");
                });
#pragma warning restore 612, 618
        }
    }
}
