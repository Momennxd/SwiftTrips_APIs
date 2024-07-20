using Core_Layer;
using DataAccess_Layer.Entities.People;

namespace API_Layer.DTOs
{
    public class PeopleDTOs
    {
        public record SendPersonDTO(int PersonID,  string FirstName, string? LastName, string? Address,

        string? Phone,  string? Gender, int CountryID, DateTime? DateOfBirth, string? ProfilePicPath, 
        string? Email, DateTime JoinedDate, string? Notes);



        /// <summary>
        /// Converts a "clsPerson object" to a "SendPersonDTO" DTO.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static SendPersonDTO ToDTO(ePeopleDA person)
        {
            if (person == null)
                return null;

            SendPersonDTO dto = new SendPersonDTO(person.PersonID, person.FirstName,
                person.LastName, person.Address, person.Phone, person.Gender,
                person.CountryID, person.DateOfBirth, person.ProfilePicPath, person.Email,
                person.JoinedDate, person.Notes);

            return dto;
        }


        /// <summary>
        /// Converts a "clsPerson list" to a "SendPersonDTO" DTOs list .
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static List<SendPersonDTO> ToDTO(List<ePeopleDA> People)
        {
            List<SendPersonDTO> lstDTOs = new List<SendPersonDTO> ();

            foreach(ePeopleDA person in People)
            {
                lstDTOs.Add(ToDTO(person));
            }

            return lstDTOs;
        }

    }
}
