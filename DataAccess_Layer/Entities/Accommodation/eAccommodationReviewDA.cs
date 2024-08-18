using Core_Layer.Entities.Accommodation;
using Core_Layer.Entities.People;
using System.ComponentModel.DataAnnotations;

public class eAccommodationReviewDA
{
    [Key]

    public int AccommodationRevireID { get; set; }

    public short ReviewValue { get; set; }


    public string ReviewText { get; set; }

    public int UserID {  get; set; }

    public int AccommodationBaseID { get; set; }


   
}