using API_Layer.DTOs;
using Core_Layer.AppDbContext;
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


        public ePersonDA? Person { private get; set; }
       

        public async Task<ePersonDA?> GetPersonAsync()
        {
            return await ePersonDA.FindAsync(PersonID);
        }


        public static eUserDA InitClass()
        {
            eUserDA p = new eUserDA()
            {
                UserID = -1,
                PersonID = -1,
                Username = string.Empty,
                Password = string.Empty,
                IsActive = false,
                Person = null

            };

            return p;

        }



        public async static Task<eUserDA?> GetUserInfoAsync(string Username)
        {
            if (string.IsNullOrEmpty(Username)) return null;

            eUserDA userDA = InitClass();

            try
            {
                using (AppDbContext context = await clsService.contextFactory!.CreateDbContextAsync())
                {
                    userDA = await context.Users.SingleOrDefaultAsync(user => user.Username == Username);
                    //userDA.Person = await ePersonDA.FindAsync(userDA.PersonID);
                }
            }
            catch (Exception ex) { return null; }

            return userDA;
        }


        public async static Task<bool> DoesUserExistAsync(string Username)
        {
            if(string.IsNullOrEmpty(Username)) return false;
            try
            {
                using (AppDbContext context = await clsService.contextFactory!.CreateDbContextAsync())
                {
                    return await context.Users.SingleOrDefaultAsync(user => user.Username == Username) != null;
                }
            }
            catch (Exception ex) { return false; }
        }



        /// <summary>
        /// A static method to add a new user from its create DTO.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>
        /// -1 if the user has NOT been added successfully, UserID if the user has been added successfully.
        /// </returns>
        public async static Task<int> AddItemAsync(UsersDTOs.CreateUserDTO userDTO)
        {
            ePersonDA UserPerson = PeopleDTOs.ToPersonEntity(userDTO.Person);

            if (!await ePersonDA.AddItemAsync(UserPerson))
                return -1;


            eUserDA user = UsersDTOs.ToUserEntity(userDTO, UserPerson.PersonID);

            if (!await eUserDA.AddItemAsync(user))
                return -1;

            return user.UserID;

        }


      
    }
}
