using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities
{
    public class ePeopleDA
    {

        [Key] 
        public int PersonID { get; }


        public string FirstName {get; set; }


        public string LastName { get; set; }


        public string? Address { get; set; }

        public string? Phone { get; set; }

        public bool Gender { get; set; }

        public int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }

       

        public static List<ePeopleDA> GetAllPeople()
        {
            AppDbContext context = new AppDbContext();


            return context.People.ToList();
        }


        public static ePeopleDA GetPerson(int personID)
        {
            if (personID <= 0)
                return null;

            AppDbContext context = new AppDbContext();


           return context.People.Select(e=>e).Where(e=>e.PersonID == personID).FirstOrDefault();
        }


        public static bool AddPerson(ePeopleDA Person)
        {
            if (Person == null)
            {
                return false;
            }

            AppDbContext context = new AppDbContext();

            try
            {
                context.People.Add(Person);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public static bool DeletePerson(int PersonID)
        {
            if (PersonID <= 0)
            {
                return false;
            }

            AppDbContext context = new AppDbContext();

            try
            {

                ePeopleDA Person = context.People.Find(PersonID);

                context.People.Remove(Person);
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
