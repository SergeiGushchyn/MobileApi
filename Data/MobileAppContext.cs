using Microsoft.EntityFrameworkCore;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.Data
{
    public class MobileAppContext : DbContext
    {
        public MobileAppContext(DbContextOptions<MobileAppContext> options) : base(options)
        { }

        public DbSet<CarProfile> CarProfiles { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<CarImage> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarProfile>().ToTable("CarProfile");
            modelBuilder.Entity<Specification>().ToTable("Specification");
            modelBuilder.Entity<CarImage>().ToTable("Image");
        }
    }
}
