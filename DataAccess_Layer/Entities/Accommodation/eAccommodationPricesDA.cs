using DataAccess_Layer.Entities.Accommodation;

public class eAccommodationPricesDA
{
    public int AccommodationPricesID { get; set; }

    public int AccommodationBaseID { get; set; }

    public double PricePerNight { get; set; }

    public short NumberOfPeople { get; set; }

    // Navigation  Property

    public eAccommdoationBasesDA accommdoationBases { get; set; }

}


