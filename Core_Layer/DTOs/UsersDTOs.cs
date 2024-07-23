using Core_Layer;
using DataAccess_Layer.Entities.People;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using static API_Layer.DTOs.PeopleDTOs;

namespace API_Layer.DTOs
{
    public class UsersDTOs
    {
        public record SendUserDTO(int UserID, PeopleDTOs.SendPersonDTO Person, string Username, string Password);

        public record CreateUserDTO(string Username, string Password, PeopleDTOs.CreatePersonDTO Person);

        public record LoginUserDTO(string Username, string Password);





        /// <summary>
        /// Converts a "eUsersDA object" to a "SendUserDTO" DTO.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static SendUserDTO ToSendUserDTO(eUsersDA user)
        {
            if (user == null)
                return null;

            clsPerson MainPerson = new clsPerson();
            
            SendUserDTO dto = new SendUserDTO(user.UserID, PeopleDTOs.ToSendPersonDTO(MainPerson.GetItem(user.PersonID)),
                user.Username, user.Password);

            return dto;
        }



       

        /// <summary>
        /// Converts a "eUsersDA list" to a "SendUserDTO" DTOs list .
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static List<SendUserDTO> ToSendUserDTO(List<eUsersDA> users)
        {
            List<SendUserDTO> lstDTOs = new List<SendUserDTO> ();

            foreach(eUsersDA user in users)
            {
                lstDTOs.Add(ToSendUserDTO(user));
            }

            return lstDTOs;
        }



        public static eUsersDA ToUserEntity(CreateUserDTO userDTO)
        {
            if (userDTO == null)
                return null;

            eUsersDA user = new eUsersDA() { IsActive = true, Username = userDTO.Username,
            Password = userDTO.Password , PersonID = -1};

            return user;
        }

    }
}
