using API_Layer.DTOs;
using DataAccess_Layer;
using DataAccess_Layer.Entities.People;


namespace Core_Layer
{
    public static class clsUserCore
    {



        public static eUserDA? GetUserInfo(string Username)
        {
            return clsService.Context.Users.SingleOrDefault(user => user.Username == Username);
        }


        public static bool DoesUserExist(string Username)
        {
            return clsService.Context.Users.SingleOrDefault(user => user.Username == Username) != null;

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
            ePersonDA UserPerson = PeopleDTOs.ToPersonEntity(userDTO.Person);

            if (!ePersonDA.AddItem(UserPerson))
                return -1;


            eUserDA user = UsersDTOs.ToUserEntity(userDTO, UserPerson.PersonID);

            if (!eUserDA.AddItem(user))
                return -1;


            return user.UserID;

        }


    }
}
