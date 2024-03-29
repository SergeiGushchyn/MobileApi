﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileApp.Data;

namespace MobileApp.Migrations
{
    [DbContext(typeof(MobileAppContext))]
    [Migration("20190712182242_Remodeled")]
    partial class Remodeled
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MobileApp.Models.CarImage", b =>
                {
                    b.Property<int>("CarImageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarProfileID");

                    b.Property<byte[]>("Picture");

                    b.HasKey("CarImageID");

                    b.HasIndex("CarProfileID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("MobileApp.Models.CarProfile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SpecificationID");

                    b.HasKey("ID");

                    b.HasIndex("SpecificationID");

                    b.ToTable("CarProfile");
                });

            modelBuilder.Entity("MobileApp.Models.Specification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("Condition");

                    b.Property<string>("ExteriorColor");

                    b.Property<string>("InteriorColor");

                    b.Property<string>("Make");

                    b.Property<string>("Mileage");

                    b.Property<string>("Model");

                    b.Property<string>("Price");

                    b.Property<string>("Title");

                    b.Property<string>("Transmission");

                    b.Property<string>("Trim");

                    b.Property<string>("Vin");

                    b.Property<string>("Year");

                    b.HasKey("ID");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("MobileApp.Models.CarImage", b =>
                {
                    b.HasOne("MobileApp.Models.CarProfile", "CarProfile")
                        .WithMany("Images")
                        .HasForeignKey("CarProfileID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileApp.Models.CarProfile", b =>
                {
                    b.HasOne("MobileApp.Models.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
