using DataAccess_Layer.Entities.People;
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
using NotMappedAttribute = System.ComponentModel.DataAnnotations.NotMappedAttribute;

namespace DataAccess_Layer.Entities
{
    public class eHotelManagerDA : Repository<eHotelManagerDA>
    {
        [Key]

        public int HotelManagerID { get; set; }


        public required int UserID { get; set; }


        [NotMapped]
        public eUserDA User { get; }

       

    }
}
