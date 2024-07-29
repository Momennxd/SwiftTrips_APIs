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

namespace ConsoleApp1
{
    public class AppDbContext : DbContext
    {
        const string _dbConnectionString =

            "Server=.;Database=SwiftTripsDB;User Id=sa;Password=sa123456;TrustServerCertificate=true";


        public AppDbContext(DbContextOptions options) :base(options)
        {
        }






        #region Entites

        public DbSet<Country> Countries {  get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Session> UsersSessions { get; set; }
        
        public DbSet<HotelManager> HotelsManagers { get; set; }

        /*public DbSet<eHotelsManagersHotelsDA> HotelsManagersHotels { get; set; } // Need to change PK name in Database

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<eHotelsPicsDA> HotelsPics { get; set; }


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

        public DbSet<eSavedHotlesDA> SavedHotels { get; set; }*/



        #endregion

    }
}
