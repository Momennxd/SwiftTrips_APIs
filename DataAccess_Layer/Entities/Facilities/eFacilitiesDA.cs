using Core_Layer.Repository;
using System.ComponentModel.DataAnnotations;



namespace Core_Layer.Entities.Facilities
{
    public class eFacilitiesDA : Repository<eFacilitiesDA>
    {
        [Key]
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string Discription { get; set; }
        public int FacilityCategoryID { get; set; }

    }
}





