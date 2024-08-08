using API_Layer.DTOs;
using Core_Layer.DTOs;
using DataAccess_Layer.Repository;
using System.ComponentModel.DataAnnotations;

namespace Core_Layer.Entities.Hotels
{
    public class eHotelDA : Repository<eHotelDA>
    {
        [Key]
        public int HotelID { get; set; }


        public required string HotelName { get; set; }


        public string? Discription { get; set; }


        public required string latitude { get; set; }

        public required string longitude { get; set; }

        public double? DistanceFromBeach { get; set; }

        public double? DistanceFromCenter { get; set; }

        public required string HotelSerialNumber { get; set; }



        #region Add New 
        public async static Task<int> AddItemAsync(HotelsDTOs.CreateHotelDTO NewHotelDTO)
        {
            eHotelDA Hotel = HotelsDTOs.ToHotelEntity(NewHotelDTO);
            if (!await eHotelDA.AddItemAsync(Hotel))
                return -1;

            return Hotel.HotelID;
        }
        #endregion

        #region Update 

        public async static Task<eHotelDA?> UpdateItemAsync(HotelsDTOs.SendHotelDTO UpdatedHotel)
        {
            eHotelDA Hotel = HotelsDTOs.ConvertFromSendHotelDTOtoEntity(UpdatedHotel);

            return await eHotelDA.UpdateItemAsync(Hotel.HotelID, Hotel);
        }

        #endregion
    }
}
