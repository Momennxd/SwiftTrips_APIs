using System.ComponentModel.DataAnnotations;

public class eAccommodationDiscountDA
{
    [Key]
    public int AccommodationDiacountID { get; set; }

    public int AccommodationPeiceID { get; set; }

    public short DiscountPercentage { get; set; }

    public DateTime StratDate { get; set; }

    public DateTime EndDate { get; set; }   


   


}