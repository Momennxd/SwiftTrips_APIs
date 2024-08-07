
using API_Layer.DTOs;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotMappedAttribute = System.ComponentModel.DataAnnotations.NotMappedAttribute;


namespace DataAccess_Layer.Entities.People
{
    public class eUserDA : Repository<eUserDA>
    {

        [Key]
        public int UserID { get; set; }


        public required int PersonID { get; set; }


        public required string Username { get; set; }


        public required string Password { get; set; }

        public required bool IsActive { get; set; }


        [NotMapped]
        public ePersonDA Person { get { return ePersonDA.Find(PersonID); } }



        public static eUserDA InitClass()
        {
            eUserDA p = new eUserDA()
            {
                UserID = -1,
                PersonID = -1,
                Username = string.Empty,
                Password = string.Empty,
                IsActive = false

            };

            return p;

        }







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
