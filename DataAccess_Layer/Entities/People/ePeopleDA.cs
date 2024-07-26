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

namespace DataAccess_Layer.Entities.People
{
    public class ePeopleDA
    {

        [Key]
        public int PersonID { get; }


        public required string FirstName { get; set; }


        public string? LastName { get; set; }


        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Gender { get; set; }

        public int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }

        public required string Email { get; set; }

        public required DateTime JoinedDate { get; set; }

        public string? Notes { get; set; }


    }
}
