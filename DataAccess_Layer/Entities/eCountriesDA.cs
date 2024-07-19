using Azure;
using ConsoleApp1;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class eCountriesDA
    {

        [Key]
        public int CountryID { get; }


        public required string CountryName { get; set; }


        
        

    }
}
