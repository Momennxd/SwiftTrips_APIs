using API_Layer.DTOs;
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;
using System.Diagnostics;


namespace Core_Layer
{
    public class clsUser : Repository<eUsersDA>
    {

        public clsUser()
        {
        }

        
        
        public static bool AddItem(UsersDTOs.CreateUserDTO userDTO)
        {
            clsPerson UserPerson = new clsPerson();


            UserPerson.BaseObject.FirstName = userDTO.Person.FirstName;
            UserPerson.BaseObject.LastName = userDTO.Person.LastName;
            UserPerson.BaseObject.Address = userDTO.Person.Address;
            UserPerson.BaseObject.Phone = userDTO.Person.Phone;
            UserPerson.BaseObject.Gender = userDTO.Person.Gender;
            UserPerson.BaseObject.CountryID = userDTO.Person.CountryID;
            UserPerson.BaseObject.DateOfBirth = userDTO.Person.DateOfBirth;
            UserPerson.BaseObject.ProfilePicPath = userDTO.Person.ProfilePicPath;
            UserPerson.BaseObject.Email = userDTO.Person.Email;
            UserPerson.BaseObject.JoinedDate = DateTime.Now;
            UserPerson.BaseObject.Notes = userDTO.Person.Notes;

            if (!UserPerson.AddItem(UserPerson.BaseObject))
                return false;


            clsUser user = new clsUser();
            user.BaseObject.PersonID = UserPerson.BaseObject.PersonID;
            user.BaseObject.Username = userDTO.Username;
            user.BaseObject.Password = userDTO.Password;
            user.BaseObject.IsActive = true;

            if (!user.AddItem(user.BaseObject))
                return false;


            return true;

        }

        protected override void InitBaseObject()
        {
            this.BaseObject = new eUsersDA() { Username = "", PersonID = -1, Password = "", IsActive = false};
        }
    }
}
