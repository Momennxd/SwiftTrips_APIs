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
    public class eHotelsManagersDA
    {

        [Key] 
        public int HotelManagerID { get; }


        public int UserID { get; set; }


       

       

    }
}
