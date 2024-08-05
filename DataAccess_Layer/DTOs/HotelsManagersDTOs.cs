using Core_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using static API_Layer.DTOs.UsersDTOs;

namespace API_Layer.DTOs
{
    public class HotelsManagersDTOs
    {
        public record SendHotelsManagerDTO(int HotelsManagerID, SendUserDTO User);


        public record CreateHotelsManagerDTO(string Username, string Password, string Email
            , string Name, int CountryID);




        /// <summary>
        /// Converts a "eHotelsManagersDA object" to a "SendHotelsManagerDTO" DTO.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static SendHotelsManagerDTO? ToSendHotelsManagerDTO(eHotelManagerDA HotelManager,
            string SessionID = "")
        {
            if (HotelManager == null)
                return null;


            SendHotelsManagerDTO dto = new SendHotelsManagerDTO(HotelManager.HotelManagerID,
                UsersDTOs.ToSendUserDTO(HotelManager.User, SessionID));

            return dto;
        }


        /// <summary>
        /// Converts a "eHotelsManagersDA list" to a "SendHotelsManagerDTO" DTOs list .
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static List<SendHotelsManagerDTO> ToSendHotelsManagerDTO(List<eHotelManagerDA> hotelers)
        {
            List<SendHotelsManagerDTO> lstDTOs = new List<SendHotelsManagerDTO>();

            foreach (eHotelManagerDA hoteler in hotelers)
            {
                lstDTOs.Add(ToSendHotelsManagerDTO(hoteler));
            }

            return lstDTOs;
        }


        public static eHotelManagerDA ToHotelsManagerEntity(CreateHotelsManagerDTO HotelManagerDTO, int UserID)
        {
            if (HotelManagerDTO == null)
                return null;

            eHotelManagerDA eHotelManager = new eHotelManagerDA()
            {
                UserID = UserID
            };

            return eHotelManager;
        }

    }
}
