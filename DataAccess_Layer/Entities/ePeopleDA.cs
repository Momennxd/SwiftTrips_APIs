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


        public required string FirstName {get; set; }


        public required string LastName { get; set; }


        public string? Address { get; set; }

        public string? Phone { get; set; }

        public required string Gender { get; set; }

        public int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }

       

    }
}
