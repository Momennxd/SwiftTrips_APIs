using Core_Layer.Entities.Facilities;
using Core_Layer.Repository;
using System.ComponentModel.DataAnnotations;

namespace Core_Layer.Entities.Accommodation
{
    public class eAccommodationFacilitiesDA : Repository<eAccommodationFacilitiesDA>
    {
        [Key]
        public int AccommodationsFacilityID { get; set; }

        public int FacilityID { get; set; }
        public int AccommodationBaseID { get; set; }



    }
}
