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

        public clsUser(eUsersDA? eUser)
        {
            base.BaseObject = eUser;          
        }

        public static eUsersDA? GetUserInfo(string Username)
        {
            return clsUser.context.Users.SingleOrDefault(user => user.Username == Username);
        }


        public static bool DoesUserExist(string Username)
        {
            if (clsUser.context.Users.SingleOrDefault(user => user.Username == Username) == null)
                return false;

            return true;
        }

        

        /// <summary>
        /// A static method to add a new user from its create DTO.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>
        /// -1 if the user has NOT been added successfully, UserID if the user has been added successfully.
        /// </returns>
        public static int AddItem(UsersDTOs.CreateUserDTO userDTO)
        {
            clsPerson UserPerson = new clsPerson();

            UserPerson.BaseObject = PeopleDTOs.ToPersonEntity(userDTO.Person);

            if (!clsPerson.AddItem(UserPerson.BaseObject))
                return -1;


            clsUser user = new clsUser(UsersDTOs.ToUserEntity(userDTO, UserPerson.BaseObject.PersonID));

            if (!clsUser.AddItem(user.BaseObject))
                return -1;


            return user.BaseObject.UserID;

        }

        protected override void InitBaseObject()
        {
            this.BaseObject = new eUsersDA() { Username = "", PersonID = -1, Password = "", IsActive = false};
        }
    }
}
