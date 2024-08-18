using Core_Layer.Entities.Facilities;
using System.ComponentModel.DataAnnotations;

namespace Core_Layer.Entities.Accommodation
{
    public class eAccommodationFacilitiesDA
    {
        [Key]
        public int AccommodationFacilityID { get; set; }

        public int FacilityID { get; set; }

        public int AccommodationBaseID { get; set; }


       
             
    }
}
