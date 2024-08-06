using DataAccess_Layer.Entities.Accommodation;
using System.ComponentModel.DataAnnotations;

public class eAccommodationPricesDA
{
    [Key]
    public int AccommodationPricesID { get; set; }

    public int AccommodationBaseID { get; set; }

    public double PricePerNight { get; set; }

    public short NumberOfPeople { get; set; }

   

}


