
using DataAccess_Layer.Repository;
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
    public class eUserDA : Repository<eUserDA>
    {

        [Key]
        public int UserID { get; set; }


        public required int PersonID { get; set; }


        public required string Username { get; set; }


        public required string Password { get; set; }

        public required bool IsActive { get; set; }




        public static eUserDA InitClass()
        {
            eUserDA p = new eUserDA()
            {
                UserID = -1,
                PersonID = -1,
                Username = string.Empty,
                Password = string.Empty,
                IsActive = false

            };

            return p;

        }

    }
}
