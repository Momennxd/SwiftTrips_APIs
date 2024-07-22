using DataAccess_Layer.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Entities.Accommodation
{
    public class eAccommdoationBasesDA
    {
        [Key]

        public int AccommodationBaseID { get; set; }

        public int HotleID { get; set; } 

        public string Discriptaion { get; set; }

        public short MaxCompactiy { get; set; }

        public short NumberOfSingleBeds { get; set; }

        public short NumberOfDoubleBeds { get; set; }

        public int Size {  get; set; }

        public string AccommodationName { get; set; }

        public string AccommodationSeriaNumber {  get; set; }

        public short NumberOfClones { get; set; }

        public bool Smoking { get; set; }

        public string BedsDiscripation { get; set; }


      



    }
}
