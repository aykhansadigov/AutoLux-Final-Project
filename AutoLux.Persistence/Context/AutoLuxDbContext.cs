using AutoLux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoLux.Persistence.Context
{
    public class AutoLuxDbContext:DbContext
    {
        public AutoLuxDbContext(DbContextOptions<AutoLuxDbContext> options) : base(options) 
        { 
        }

        public DbSet<Car>GetCars {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Brand = "Porsche",
                    Model = "911",
                    Year = 2024,
                    Category = "Sportkar",
                    Price = 120000,
                    ImageUrl = "porsche-url",
                    IsForSale = true
                },
                new Car
                {
                    Id = 2,
                    Brand = "Changan",
                    Model = "UNI-Z",
                    Year = 2024,
                    Category = "SUV",
                    Price = 45000,
                    ImageUrl = "changan-url",
                    IsForRent = true
                }
            );

            modelBuilder.Entity<Car>().Property(c => c.Price).HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}

