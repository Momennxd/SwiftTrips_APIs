using DataAccess_Layer.Entities.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Reservation
{
    public class eReservationTransactionDA
    {
        public int TranscationID { get; set; }

        public int HotleReservationID {  get; set; }        
        public bool Succeedes { get; set; }

        public DateTime TransactionDate {  get; set; }
        
        public string Notes { get; set; }

        public int PricePaid { get; set; }


<<<<<<< HEAD
=======
       

>>>>>>> 883e113bb43155e3aaab49aec69abd68cecf82f0


    }
}


<<<<<<< HEAD

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
    

   
}



public class eReservationTypeDA
{

    [Key]

    public int ReservationTypeID { get; set; }

    public string ReservationTypeName { get; set; }
}


=======
>>>>>>> 883e113bb43155e3aaab49aec69abd68cecf82f0
