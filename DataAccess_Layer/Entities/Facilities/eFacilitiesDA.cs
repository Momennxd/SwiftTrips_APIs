using System.ComponentModel.DataAnnotations;



namespace DataAccess_Layer.Entities.Facilities
{
    public class eFacilitiesDA
    {
        [Key]
        public int FacilityID { get; set; }


        public string FacilityName { get; set; }


        public string Description { get; set; }


        public int CategoryID { get; set; }


    }
}





