using Core_Layer.Entities.Hotels;
using DataAccess_Layer.Entities.Hotels;

namespace Core_Layer.DTOs
{
    public static class HotelsDTOs
    {
        #region DTOs


        /// <summary>
        /// this dto is use to send hotel info to the client.
        /// </summary>
        /// <param name="HotelID"></param>
        /// <param name="HotelName"></param>
        /// <param name="Discription"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="DistanceFromBeach"></param>
        /// <param name="DistanceFromCenter"></param>
        /// <param name="HotelSerialNumber"></param>
        public record SendHotelDTO(int HotelID, string HotelName, string? Discription,
            string latitude, string longitude,
            double? DistanceFromBeach, double? DistanceFromCenter, string HotelSerialNumber);
        
        public static eHotelDA ConvertFromSendHotelDTOtoEntity(SendHotelDTO sendHotelDTO)
        {
            return new eHotelDA()
            {
                HotelID = sendHotelDTO.HotelID,
                HotelName = sendHotelDTO.HotelName,
                Discription = sendHotelDTO.Discription,
                latitude = sendHotelDTO.latitude,
                longitude = sendHotelDTO.longitude,
                DistanceFromBeach = sendHotelDTO.DistanceFromBeach,
                DistanceFromCenter = sendHotelDTO.DistanceFromCenter,
                HotelSerialNumber = sendHotelDTO.HotelSerialNumber
            };
        }
        
        
        public record CreateHotelDTO(string HotelName, string? Discription, string latitude, string longitude,
            double? DistanceFromBeach, double? DistanceFromCenter, string HotelSerialNumber);



        #endregion

        #region Send Hotel DTO
        /// <summary>
        /// This statis method is use to send hotel DTO
        /// </summary>
        /// <param name="Hotel"> hotel entity </param>
        /// <returns> Hotel DTO </returns>
        public static SendHotelDTO? ToSendHotelDTO(eHotelDA Hotel)
        {
            if (Hotel == null)
                return null;

            return new SendHotelDTO(Hotel.HotelID, Hotel.HotelName, Hotel.Discription, Hotel.latitude, Hotel.longitude,
                Hotel.DistanceFromBeach, Hotel.DistanceFromCenter, Hotel.HotelSerialNumber);
        }

        #endregion

        #region To Hotel Entity

        public static eHotelDA ToHotelEntity(CreateHotelDTO NewHotel)
        {
            return new eHotelDA()
            {
              
                HotelName = NewHotel.HotelName,
                Discription = NewHotel.Discription,
                latitude = NewHotel.longitude,
                longitude = NewHotel.longitude,
                DistanceFromBeach = NewHotel.DistanceFromBeach,
                DistanceFromCenter = NewHotel.DistanceFromCenter,
                HotelSerialNumber = NewHotel.HotelSerialNumber
            };
        }

        #endregion

       

    }
}
