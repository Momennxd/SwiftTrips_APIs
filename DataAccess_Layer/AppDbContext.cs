using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.Accommodation;
using DataAccess_Layer.Entities.Bridges;
using DataAccess_Layer.Entities.Facilities;
using DataAccess_Layer.Entities.Hotels;
using DataAccess_Layer.Entities.Language.cs;
using DataAccess_Layer.Entities.Logs;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Entities.Reservation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using eUsersSessionsDA = DataAccess_Layer.Entities.Logs.eUsersSessionsDA;

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
            modelBuilder.Entity<ePaymentsTypeDA>().HasKey(e => e.PaymentTypeID);
            modelBuilder.Entity<eSavedHotlesDA>().HasKey(e => e.SavedHotleID);
            modelBuilder.Entity<eUsersSessionsDA>().HasKey(e => e.SessionID);






            modelBuilder.Entity<eAccommodationDiscountDA>().HasKey(e => e.AccommodationDiacountID);
            modelBuilder.Entity<eAccommdoationBasesDA>().HasKey(e => e.AccommodationBaseID);
            modelBuilder.Entity<eAccommodationFacilitiesDA>().HasKey(e => e.AccommodationFacilityID);
            modelBuilder.Entity<eAccommodationPatmentsMethodDA>().HasKey(e => e.MethodId);
            modelBuilder.Entity<eAccommodationPricesDA>().HasKey(e => e.AccommodationPricesID);
            modelBuilder.Entity<eAccommodationReviewDA>().HasKey(e => e.AccommodationRevireID);
            modelBuilder.Entity<eAccommodatioPicsDA>().HasKey(e => e.AccommodationPicID);


            modelBuilder.Entity<eReservationTransactionDA>().HasKey(e => e.TranscationID);
            modelBuilder.Entity<eReservationTypeDA>().HasKey(e => e.ReservationTypeID);
            modelBuilder.Entity<eHotlesReservationsDA>().HasKey(e => e.HotlereservationID);



            
            


            
            


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

        public DbSet<eAccommodationDiscountDA> AccommodationsDiscounts { get; set; }

        public DbSet<eAccommodationPatmentsMethodDA> AccommationsPaymentsMethods { get; set; }

        public DbSet<eAccommdoationBasesDA> AccommodationsBases { get; set; }

        public DbSet<eAccommodationFacilitiesDA> AccommodationsFacilities { get; set; }

        public DbSet<eAccommodationPricesDA> AccommadationsPrices { get; set; }

        public DbSet<eAccommodatioPicsDA> AccommodationsPics { get; set; }

        public DbSet<ePaymentsTypeDA> PaymentsTypes { get; set; }

        public DbSet<eReservationTypeDA> ReservationsTypes { get; set; }

        public DbSet<eReservationTransactionDA> ReservationsTransactions { get; set; }

        public DbSet<eHotlesReservationsDA> HotelsReservations { get; set; }

        public DbSet<eSavedHotlesDA> SavedHotels { get; set; }

        public DbSet<eUsersSessionsDA> UsersSessions { get; set; }


    

    }
}
