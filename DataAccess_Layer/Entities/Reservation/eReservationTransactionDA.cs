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


        // Navigation Property 

        public eHotlesReservationsDA hotlesReservations { get; set; }



    }
}


