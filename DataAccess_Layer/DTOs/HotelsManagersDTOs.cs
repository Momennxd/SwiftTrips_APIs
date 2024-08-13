using Core_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using Newtonsoft.Json;
using static API_Layer.DTOs.UsersDTOs;

namespace API_Layer.DTOs
{
    public static class HotelsManagersDTOs
    {
        public record SendHotelsManagerDTO(int HotelsManagerID, SendUserDTO User);


        public record CreateHotelsManagerDTO
        {
            private string? _username;
            private string? _password;
            private string? _email;
            private string? _name;

            public string? Username
            {
                get => _username;
                init => _username = string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)? null: value;
            }

            public string? Password
            {
                get => _password;
                init => _password = string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) ? null : value;
            }

            public string? Email
            {
                get => _email;
                init => _email = string.IsNullOrWhiteSpace(value)
                    || string.IsNullOrEmpty(value) 
                    ? null: value;
            } 


            public string? Name
            {
                get => _name;
                init => _name = string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)? null: value;
            }

            public int CountryID { get; init; }
        }









        /// <summary>
        /// Converts a "eHotelsManagersDA object" to a "SendHotelsManagerDTO" DTO.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async static Task<SendHotelsManagerDTO?> ToSendHotelsManagerDTO(eHotelManagerDA? HotelManager)
        {
            if (HotelManager == null)
                return null;


            SendHotelsManagerDTO dto = new SendHotelsManagerDTO(HotelManager.HotelManagerID, await
                UsersDTOs.ToSendUserDTOAsync(HotelManager.User));

            return dto;
        }


        /// <summary>
        /// Converts a "eHotelsManagersDA list" to a "SendHotelsManagerDTO" DTOs list .
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async static Task<List<SendHotelsManagerDTO>> ToSendHotelsManagerDTO(List<eHotelManagerDA> hotelers)
        {
            List<SendHotelsManagerDTO> lstDTOs = new List<SendHotelsManagerDTO>();

            foreach (eHotelManagerDA hoteler in hotelers)
            {
                lstDTOs.Add(await ToSendHotelsManagerDTO(hoteler));
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
