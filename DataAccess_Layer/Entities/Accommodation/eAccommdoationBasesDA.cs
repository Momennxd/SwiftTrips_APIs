using Core_Layer.DTOs.Accommodations;
using Core_Layer.Entities.Hotels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Entities.Accommodation
{
    public class eAccommdoationBasesDA : Repository.Repository<eAccommdoationBasesDA>
    {
        #region Columns
        [Key]
        public int AccommodationBaseID { get; set; } // Primary Key

        public int HotelID { get; set; }

        public string? Discription { get; set; } // Nullable nvarchar(500)

        public short MaxCapacity { get; set; }

        public byte NumberOfSingleBeds { get; set; }

        public byte NumberOfDoubleBeds { get; set; }

        public short Size { get; set; }

        public string AccommadationName { get; set; } = string.Empty; // nvarchar(50)

        public string AccommodationSerialNumber { get; set; } = string.Empty; // nvarchar(50)

        public short NumberOfClones { get; set; }

        public bool Smoking { get; set; } // bit

        public string? BedsDiscription { get; set; } // Nullable nvarchar(500)
        #endregion


        #region Add New

        public static async Task<int> AddItemAsync(AccommodationBasesDTOs.AddNewDTO addNewDTO)
        {
            eAccommdoationBasesDA AccommodationBase = AccommodationBasesDTOs.ToAccommdoationBasesEntity(addNewDTO);

            if (!await eAccommdoationBasesDA.AddItemAsync(AccommodationBase))
                return -1;

            return AccommodationBase.AccommodationBaseID;
        }

        #endregion


    }
}
