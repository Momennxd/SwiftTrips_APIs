using Core_Layer.Entities.Hotels;
using Core_Layer.Entities.People;
using System.ComponentModel.DataAnnotations;

public class eSavedHotlesDA
{
    [Key]

    public int SavedHotleID { get; set; }

    public int UserID { get; set; }

    public int HotleID { get; set; }

    public bool IsSaved {  get; set; }

    public DateTime SaveDate { get; set; }


    // Navigation Properties

    public eUserDA users {  get; set; }

    public eHotelDA hotels {  get; set; }  

}
