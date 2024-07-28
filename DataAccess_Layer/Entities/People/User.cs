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
    public class User
    {

        public int UserID { get; set; }


        public required int PersonID { get; set; }


        public required string Username { get; set; }


        public required string Password { get; set; }

        public required bool IsActive { get; set; }

       


    }
}
