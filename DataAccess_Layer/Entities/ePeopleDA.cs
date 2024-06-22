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
        public int PersonID { get; set; }


        public string FirstName { get; set; }


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




    }
}
