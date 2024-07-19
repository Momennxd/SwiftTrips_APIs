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
    public class eHotelsDA
    {

        [Key] 
        public int HotelID { get; }


        public required string HotelName { get; set; }


        public string? Discription { get; set; }


        public required string latitude { get; set; }

        public required string longitude { get; set; }

        public string? DistanceFromBeach { get; set; }

        public string? DistanceFromCenter { get; set; }

        public required string HotelSerialNumber { get; set; }


       

    }
}
