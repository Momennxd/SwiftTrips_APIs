using Azure;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Hotels
{
    public class eHotelsPicsDA : Repository<eHotelsPicsDA>
    {

        [Key]
        public int HotelPicID { get; set; }

        public required string URL { get; set; }

        public required int HotelID { get; set; }

        public required string PicName { get; set; }


        //overloading 
        public static async Task<List<eHotelsPicsDA>?> GetAllItemsAsync(int HotelID)
        {
            return await clsService.Context.HotelsPics.Where(p => p.HotelID == HotelID).ToListAsync();
        }


    }
}
