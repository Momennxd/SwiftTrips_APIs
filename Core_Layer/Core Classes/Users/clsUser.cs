using API_Layer.DTOs;
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace Core_Layer
{
    public class clsUser : Repository<eUsersDA>
    {

        public clsUser()
        {
        }

       



        /// <summary>
        /// A static method to add a new user from its DTO.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>
        /// -1 if the user is has not been added successfully, UserID if has been added successfully.
        /// </returns>
        public static int AddItem(UsersDTOs.CreateUserDTO userDTO)
        {
            clsPerson UserPerson = new clsPerson();

            UserPerson.BaseObject = PeopleDTOs.ToPersonEntity(userDTO.Person);

            if (!UserPerson.AddItem(UserPerson.BaseObject))
                return -1;


            clsUser user = new clsUser();


            user.BaseObject = UsersDTOs.ToUserEntity(userDTO);
            user.BaseObject.PersonID = UserPerson.BaseObject.PersonID;


            if (!user.AddItem(user.BaseObject))
                return -1;


            return user.BaseObject.UserID;

        }

        protected override void InitBaseObject()
        {
            this.BaseObject = new eUsersDA() { Username = "", PersonID = -1, Password = "", IsActive = false};
        }
    }
}
