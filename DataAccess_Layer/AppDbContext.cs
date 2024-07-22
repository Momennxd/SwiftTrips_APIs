using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.Bridges;
using DataAccess_Layer.Entities.Facilities;
using DataAccess_Layer.Entities.Hotels;
using DataAccess_Layer.Entities.Language.cs;
using DataAccess_Layer.Entities.Logs;
using DataAccess_Layer.Entities.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AppDbContext : DbContext
    {
        const string _dbConnectionString =

            "Server=.;Database=SwiftTripsDB;User Id=sa;Password=sa123456;TrustServerCertificate=true";


        public AppDbContext(DbContextOptions options) :base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eCountriesDA>().HasKey(e=> e.CountryID);
            modelBuilder.Entity<ePeopleDA>().HasKey(e => e.PersonID);
            modelBuilder.Entity<eHotelsManagersDA>().HasKey(e => e.HotelManagerID);
            modelBuilder.Entity<eHotelsManagersHotelsDA>().HasKey(e => e.ID);
            modelBuilder.Entity<eHotelsDA>().HasKey(e => e.HotelID);
            modelBuilder.Entity<eHotelsPicsDA>().HasKey(e => e.HotelID);
            modelBuilder.Entity<eUsersDA>().HasKey(e => e.UserID);
            modelBuilder.Entity<eFacilitiesCategoriesDA>().HasKey(e => e.FacilityCategoryID);
            modelBuilder.Entity<eFacilitiesDA>().HasKey(e => e.FacilityID);
            modelBuilder.Entity<eHotelFacilitiesDA>().HasKey(e => e.HotelFactilityID);
            modelBuilder.Entity<eLanguageDA>().HasKey(e => e.LanguageID);
            modelBuilder.Entity<ePreferedPeopleLanguagesDA>().HasKey(e => e.LanguagePersonID);


        }






        //tabels

        public DbSet<eCountriesDA> Countries {  get; set; }

        public DbSet<ePeopleDA> People { get; set; }

        public DbSet<eHotelsManagersDA> HotelsManagers { get; set; }

        public DbSet<eHotelsManagersHotelsDA> HotelsManagersHotels { get; set; }

        public DbSet<eHotelsDA> Hotels { get; set; }

        public DbSet<eHotelsPicsDA> HotelsPics { get; set; }

        public DbSet<eUsersDA> Users { get; set; }

        public DbSet<eFacilitiesCategoriesDA> FacilitiesCategories { get; set; }

        public DbSet<eFacilitiesDA> Facilities { get; set; }

        public DbSet<eHotelFacilitiesDA> HotelFacilities { get; set; }

        public DbSet<eLanguageDA> Languages { get; set; }

        public DbSet<ePreferedPeopleLanguagesDA> PreferedPeopleLanguages { get; set; }





    }
}
