using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Facilities
{
    public class eFacilitiesCategoriesDA
    {
        [Key]
        public int FacilityCategoryID { get; set; }


        public string CategoryName { get; set; }


        public string? Description { get; set; }
    }
}



