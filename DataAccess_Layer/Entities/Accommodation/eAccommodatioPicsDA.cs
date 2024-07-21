using DataAccess_Layer.Entities.Accommodation;
using System.ComponentModel.DataAnnotations;

public class eAccommodatioPicsDA
{
    [Key]

    public int AccommodationPicID { get; set; }

    public int AccommodationBaseID { get; set; }

    public string URl {  get; set; }

    public string PicName { get; set; }

    
}

