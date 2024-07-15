using ConsoleApp1;
using Microsoft.AspNetCore.JsonPatch;
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

        public string Gender { get; set; }

        public int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }

       

        //public static dynamic GetAllPeople()
        //{
        //    AppDbContext context = new AppDbContext();


        //    return context.People.AsNoTracking().ToList();
        //}


        //public static ePeopleDA GetPerson(int personID)
        //{
        //    if (personID <= 0)
        //        return null;

        //    AppDbContext context = new AppDbContext();


        //   return context.People.Select(e=>e).Where(e=>e.PersonID == personID).FirstOrDefault();
        //}


        //public static bool AddPerson(ePeopleDA Person)
        //{
        //    if (Person == null)
        //    {
        //        return false;
        //    }

        //    AppDbContext context = new AppDbContext();

        //    try
        //    {
        //        context.People.Add(Person);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }


        //}


        //public static bool DeletePerson(int PersonID)
        //{
        //    if (PersonID <= 0)
        //    {
        //        return false;
        //    }

        //    AppDbContext context = new AppDbContext();

        //    try
        //    {

        //        ePeopleDA Person = context.People.Find(PersonID);

        //        context.People.Remove(Person);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }


        //}



        //public static bool UpatePerson(ePeopleDA newPerson, int personID)
        //{
        //    if (newPerson == null)
        //    {
        //        return false;
        //    }

        //    AppDbContext context = new AppDbContext();


        //    try
        //    {
        //        ePeopleDA person = context.People.Find(personID);

        //        //id does not exist
        //        if (person == null)
        //            return false;

        //        person.FirstName = newPerson.FirstName;
        //        person.LastName = newPerson.LastName;
        //        person.Gender = newPerson.Gender;
        //        person.ProfilePicPath = newPerson.ProfilePicPath;
        //        person.Address = newPerson.Address;
        //        person.DateOfBirth = newPerson.DateOfBirth;
        //        person.Phone = newPerson.Phone;
        //        person.CountryID = newPerson.CountryID;

        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        //public static bool PatchPerson(JsonPatchDocument<ePeopleDA> NewPerson, int personID)
        //{
        //    if (NewPerson == null || personID <= 0)
        //    {
        //        return false;
        //    }

        //    AppDbContext context = new AppDbContext();


        //    try
        //    {
        //        ePeopleDA person = context.People.Find(personID);

        //        //id does not exist
        //        if (person == null)
        //            return false;

        //        NewPerson.ApplyTo(person);

        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

    }
}
