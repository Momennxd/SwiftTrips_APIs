using System.ComponentModel.DataAnnotations;

namespace DataAccess_Layer.Entities.Facilities
{
    public class eHotelFacilitiesDA
    {
        [Key]
        public int HotelFactilityID { get; set; }


        public int FacilityID { get; set; }


        public int HotelID { get; set; }



    }
}
