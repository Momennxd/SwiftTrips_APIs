using System.ComponentModel.DataAnnotations;

public class eReservationTypeDA
{

    [Key]

    public int ReservationTypeID { get; set; }

    public string ReservationTypeName { get; set; }
}


