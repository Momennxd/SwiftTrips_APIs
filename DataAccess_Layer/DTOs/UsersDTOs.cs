using Core_Layer;
using DataAccess_Layer.Entities.People;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using static API_Layer.DTOs.PeopleDTOs;

namespace API_Layer.DTOs
{
    public static class UsersDTOs
    {
        public record SendUserDTO(int UserID, SendPersonDTO Person, string Username, string Password);

        public record CreateUserDTO(string Username, string Password, PeopleDTOs.CreatePersonDTO Person);

        public record LoginUserDTO(string Username, string Password);


     

        /// <summary>
        /// Converts a "eUsersDA object" to a "SendUserDTO" DTO.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async static Task<SendUserDTO?> ToSendUserDTOAsync(eUserDA? user)
        {
            if (user == null)
                return null;

            
            SendUserDTO dto = new SendUserDTO(user.UserID,
                PeopleDTOs.ToSendPersonDTO(await ePersonDA.FindAsync(user.PersonID)),
                user.Username, user.Password);

            return dto;
        }



      

        /// <summary>
        /// Converts a "eUsersDA list" to a "SendUserDTO" DTOs list .
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async static Task<List<SendUserDTO>> ToSendUserDTO(List<eUserDA> users)
        {
            List<SendUserDTO> lstDTOs = new List<SendUserDTO>();

            foreach(eUserDA user in users)
            {
                lstDTOs.Add(await ToSendUserDTOAsync(user));
            }

            return lstDTOs;
        }



        public static eUserDA? ToUserEntity(CreateUserDTO userDTO, int PersonID)
        {
            if (userDTO == null)
                return null;

            eUserDA user = new eUserDA() { IsActive = true, Username = userDTO.Username,
            Password = userDTO.Password , PersonID = PersonID};

            return user;
        }

    }
}
