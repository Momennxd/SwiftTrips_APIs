using Core_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using static API_Layer.DTOs.UsersDTOs;

namespace API_Layer.DTOs
{
    public class HotelsManagersDTOs
    {
        public record SendHotelsManagerDTO(UsersDTOs.SendUserDTO User);

       // public record CreateHotelsManagerDTO(UsersDTOs.CreateUserDTO User);

        public record CreateHotelsManagerDTO(string Username, string Password, string Name, int CountryID);








        /// <summary>
        /// Converts a "eHotelsManagersDA object" to a "SendHotelsManagerDTO" DTO.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static SendHotelsManagerDTO ToSendHotelsManagerDTO(eHotelsManagersDA HotelManager)
        {
            if (HotelManager == null)
                return null;

            clsHotelsManager hotelsManager = new clsHotelsManager();


            SendHotelsManagerDTO dto = new SendHotelsManagerDTO(
                UsersDTOs.ToSendUserDTO(hotelsManager.User));

            return dto;
        }


        /// <summary>
        /// Converts a "eHotelsManagersDA list" to a "SendHotelsManagerDTO" DTOs list .
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static List<SendHotelsManagerDTO> ToSendHotelsManagerDTO(List<eHotelsManagersDA> hotelers)
        {
            List<SendHotelsManagerDTO> lstDTOs = new List<SendHotelsManagerDTO>();

            foreach (eHotelsManagersDA hoteler in hotelers)
            {
                lstDTOs.Add(ToSendHotelsManagerDTO(hoteler));
            }

            return lstDTOs;
        }


        public static eHotelsManagersDA ToHotelsManagerEntity(CreateHotelsManagerDTO HotelManagerDTO)
        {
            if (HotelManagerDTO == null)
                return null;

            eHotelsManagersDA eHotelManager = new eHotelsManagersDA()
            {
                UserID = -1
            };

            return eHotelManager;
        }

    }
}
