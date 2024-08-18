using Core_Layer.Entities.Accommodation;
using System.ComponentModel.DataAnnotations;

public class eHotlesReservationsDA
{
    [Key]
    public int HotlereservationID { get; set; }

    public short State { get; set; }

    public string Discription { get; set; }

    public DateTime CheckIn {  get; set; }

    public DateTime CheckOut { get; set; }

    public int AccommodationBaseID { get; set; }


    public int NumberOfPeople { get; set; }


    public int  ReservationType { get; set; }

    public short NumberOfAccommodation { get; set; }

    public DateTime ReservationDate { get; set; }  
    

   
}


