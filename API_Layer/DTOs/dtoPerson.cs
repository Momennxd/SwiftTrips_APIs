using Azure;
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace API_Layer.DTOs
{
    public class dtoPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return this.FirstName + " " + this.LastName; } }   

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public bool Gender { get; set; }

        public int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }

        public eCountriesDA? Country
        {

            get
            {
                AppDbContext context = new AppDbContext();
                return context.Countries.Select(c => c).Where(c => c.CountryID == this.CountryID).FirstOrDefault();
            }

        }


        public static List<dtoPerson> GetAllPeople()
        {
            AppDbContext context = new AppDbContext();

            List<dtoPerson> peopleDTO = new List<dtoPerson>();


            List<ePeopleDA> PeopleEntitys = context.People.ToList();
            

            foreach(ePeopleDA person in PeopleEntitys)
            {
                peopleDTO.Add(new dtoPerson
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Address = person.Address,
                    Phone = person.Phone,
                    Gender = person.Gender,
                    CountryID = person.CountryID,
                    DateOfBirth = person.DateOfBirth,
                    ProfilePicPath = person.ProfilePicPath


                });
            }

            return peopleDTO;   
            
        }


        public static dtoPerson GetPerson(int personID)
        {
            if (personID <= 0)
                return null;

            AppDbContext context = new AppDbContext();


            ePeopleDA person =
                context.People.Select(e => e).Where(e => e.PersonID == personID).FirstOrDefault();

            if (person == null)
                return null;

            return new dtoPerson()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Address = person.Address,
                Phone = person.Phone,
                Gender = person.Gender,
                CountryID = person.CountryID,
                DateOfBirth = person.DateOfBirth,
                ProfilePicPath = person.ProfilePicPath
            };
        }


       
        public static bool DeletePerson(int PersonID)
        {
            return ePeopleDA.DeletePerson(PersonID);
        }

        public static bool UpdatePerson(ePeopleDA Person, int ID)
        {
            return ePeopleDA.UpatePerson(Person, ID);
        }

        public static bool PatchPerson(JsonPatchDocument<ePeopleDA> Person, int ID)
        {
            return ePeopleDA.PatchPerson(Person, ID);
        }
    }
}
