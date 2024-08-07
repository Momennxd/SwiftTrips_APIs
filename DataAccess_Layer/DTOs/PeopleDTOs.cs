using Core_Layer;
using DataAccess_Layer.Entities.People;

namespace API_Layer.DTOs
{
    public static class PeopleDTOs
    {

        /// <summary>
        /// used for sending the dto to the client
        /// </summary>
        /// <param name="PersonID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Address"></param>
        /// <param name="Phone"></param>
        /// <param name="Gender"></param>
        /// <param name="CountryID"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="ProfilePicPath"></param>
        /// <param name="Email"></param>
        /// <param name="JoinedDate"></param>
        /// <param name="Notes"></param>
        public record SendPersonDTO(int PersonID,  string FirstName, string? LastName, string? Address,

        string? Phone,  string? Gender, int CountryID, DateTime? DateOfBirth, string? ProfilePicPath, 
        string Email, DateTime JoinedDate, string? Notes);

     

        public record CreatePersonDTO(string FirstName, string? LastName, string? Address,

       string? Phone, string? Gender, int CountryID, DateTime? DateOfBirth, string? ProfilePicPath,
       string Email, string? Notes);






        /// <summary>
        /// Converts a "person object" to a "SendPersonDTO" DTO.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static SendPersonDTO ToSendPersonDTO(ePersonDA person)
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
        /// Converts a "person list" to a "SendPersonDTO" DTOs list.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static List<SendPersonDTO> ToSendPersonDTO(List<ePersonDA> People)
        {
            List<SendPersonDTO> lstDTOs = new List<SendPersonDTO> ();

            foreach(ePersonDA person in People)
            {
                lstDTOs.Add(ToSendPersonDTO(person));
            }

            return lstDTOs;
        }



        public static ePersonDA ToPersonEntity(CreatePersonDTO personDTO)
        {
            if (personDTO == null)
                return null;

            ePersonDA person = new ePersonDA()
            {
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
                Address = personDTO.Address,
                Phone = personDTO.Phone,
                Gender = personDTO.Gender,
                CountryID = personDTO.CountryID,
                DateOfBirth = personDTO.DateOfBirth,
                ProfilePicPath = personDTO.ProfilePicPath,
                Email = personDTO.Email,
                JoinedDate = DateTime.Now,
                Notes = personDTO.Notes

            };




            return person;
        }
    }
}
