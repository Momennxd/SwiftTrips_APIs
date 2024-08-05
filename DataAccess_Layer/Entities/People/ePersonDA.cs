using Core_Layer;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.People
{
    public class ePersonDA : Repository<ePersonDA>
    {

        [Key]

        public int PersonID { get; private set; }


        public required string FirstName { get; set; }


        public string? LastName { get; set; }


        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Gender { get; set; }

        public required int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }

        public required string Email { get; set; }


        public required DateTime JoinedDate { get; set; }

        public string? Notes { get; set; }



        public static ePersonDA InitClass()
        {
            ePersonDA p = new ePersonDA()
            {
                Address = string.Empty,
                Phone = string.Empty,
                Gender = string.Empty,
                PersonID = -1,
                FirstName = string.Empty,
                LastName = string.Empty,
                CountryID = -1,
                DateOfBirth = DateTime.MinValue,
                JoinedDate = DateTime.MinValue,
                Email = string.Empty,
                ProfilePicPath = string.Empty,

            };

            return p;

        }
    }
}
