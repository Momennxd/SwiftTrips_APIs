using Azure;
using ConsoleApp1;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace API_Layer.DTOs
{
    public class dtoPerson
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return this.FirstName + " " + this.LastName; } }   

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string Gender { get; set; }

        public int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }


        public static dtoPerson ToDTO(ePeopleDA person)
        {
            if (person == null)
                return null;

            dtoPerson dto = new dtoPerson();

            dto.PersonID = person.PersonID;
            dto.FirstName = person.FirstName;
            dto.LastName = person.LastName;
            dto.Address = person.Address;
            dto.Phone = person.Phone;
            dto.Gender = person.Gender;
            dto.CountryID = person.CountryID;
            dto.DateOfBirth = person.DateOfBirth;
            dto.ProfilePicPath = person.ProfilePicPath;

            return dto;
        }



    }
}
