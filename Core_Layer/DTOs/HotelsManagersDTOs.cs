using Core_Layer;
using DataAccess_Layer.Entities.People;

namespace API_Layer.DTOs
{
    public class HotelsManagersDTOs
    {
        public record SendHotelsManagerDTO(int UserID, int PersonID, string Username, string Password);

        public record CreateUserDTO(string Username, string Password, string FirstName,
            string? LastName, string? Address,
        string? Phone, string? Gender, int CountryID, DateTime? DateOfBirth, string? ProfilePicPath,
        string? Email, string? Notes);









        ///// <summary>
        ///// Converts a "eUsersDA object" to a "SendUserDTO" DTO.
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //public static SendUserDTO ToSendUserDTO(eUsersDA user)
        //{
        //    if (user == null)
        //        return null;

        //    SendUserDTO dto = new SendUserDTO(user.UserID, user.PersonID,
        //        user.Username, user.Password);

        //    return dto;
        //}


        ///// <summary>
        ///// Converts a "eUsersDA list" to a "SendUserDTO" DTOs list .
        ///// </summary>
        ///// <param name="person"></param>
        ///// <returns></returns>
        //public static List<SendUserDTO> ToSendUserDTO(List<eUsersDA> users)
        //{
        //    List<SendUserDTO> lstDTOs = new List<SendUserDTO> ();

        //    foreach(eUsersDA user in users)
        //    {
        //        lstDTOs.Add(ToSendUserDTO(user));
        //    }

        //    return lstDTOs;
        //}
    



    }
}
