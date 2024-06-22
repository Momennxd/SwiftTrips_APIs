using Azure;
using ConsoleApp1;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class eCountriesDA
    {

        [Key]
        public int CountryID { get; }


        public string CountryName { get; set; }


        public static List<eCountriesDA> GetAllCountries()
        {
            AppDbContext context = new AppDbContext();


            return context.Countries.ToList();
        }


        public static eCountriesDA GetCountry(int CountryID)
        {
            if (CountryID <= 0)
            {
                return null;
            }

            AppDbContext context = new AppDbContext();

            eCountriesDA country = context.Countries.FromSql($"SELECT * FROM Countries where CountryID = {CountryID}").FirstOrDefault();


            return country;
        }

        public static bool AddCountry(eCountriesDA country)
        {
            if (country == null || string.IsNullOrEmpty(country.CountryName))
            {
                return false;
            }

            AppDbContext context = new AppDbContext();

            try
            {
                context.Countries.Add(country);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public static bool updateCountry(eCountriesDA NewCountry, int OldCountryID)
        {
            if (NewCountry == null || string.IsNullOrEmpty(NewCountry.CountryName))
            {
                return false;
            }

            AppDbContext context = new AppDbContext();


            try
            {
                eCountriesDA country = context.Countries.Find(OldCountryID);

                //id does not exist
                if (country == null)              
                    return false;

                country.CountryName = NewCountry.CountryName;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool PatchCountry(JsonPatchDocument<eCountriesDA> NewCountry, int OldCountryID)
        {
            if (NewCountry == null || OldCountryID <= 0)
            {
                return false;
            }

            AppDbContext context = new AppDbContext();


            try
            {
                eCountriesDA country = context.Countries.Find(OldCountryID);

                //id does not exist
                if (country == null)
                    return false;

                NewCountry.ApplyTo(country);

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool DeleteCountry(int CountryID)
        {
            if (CountryID <= 0)
            {
                return false;
            }

            AppDbContext context = new AppDbContext();

            try
            {

                eCountriesDA country = context.Countries.Find(CountryID);

                context.Countries.Remove(country);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

    }
}
