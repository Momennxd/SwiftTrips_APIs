using Core_Layer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Entities.Facilities
{
    public class eFacilitiesCategoriesDA : Repository<eFacilitiesCategoriesDA>
    {
        [Key]
        public int FacilityCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? Discription { get; set; }
    }
}



