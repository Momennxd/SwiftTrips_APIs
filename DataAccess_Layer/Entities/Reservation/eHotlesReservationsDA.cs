using DataAccess_Layer.Entities.Accommodation;
using System.ComponentModel.DataAnnotations;

public class eHotlesReservationsDA
{
    [Key]
    public int HotlereservationID { get; set; }

    public short State { get; set; }

    public string Discripation { get; set; }

    public DateTime CheckIn {  get; set; }

    public DateTime CheckOut { get; set; }

    public int AccommodationBaseID { get; set; }

    public int PersonID { get; set; }

    public int NumberOfPeople { get; set; }

    public int Pin {  get; set; }

    public int  ReservationType { get; set; }

    public short NumberOfAccommodation { get; set; }

    public DateTime ReservationDate { get; set; }  
    

    // Navigation Property 

    public eReservationTypeDA reservationType { get; set; }

    public eAccommdoationBasesDA accommdoationBases { get; set; }
}


