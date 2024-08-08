using API_Layer.DTOs;
using Core_Layer;
using DataAccess_Layer.Entities.People;
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

namespace DataAccess_Layer.Entities
{
    public class eHotelManagerDA : Repository<eHotelManagerDA>
    {
        [Key]

        public int HotelManagerID { get; set; }


        public required int UserID { get; set; }


        [NotMapped]
        public eUserDA User { get { return eUserDA.Find(UserID); } }








        public async static Task<int> AddItemAsync(HotelsManagersDTOs.CreateHotelsManagerDTO managerDTO)
        {

            int UserID = await eUserDA.AddItemAsync(new UsersDTOs.CreateUserDTO(managerDTO.Username, managerDTO.Password,
                new PeopleDTOs.CreatePersonDTO(managerDTO.Name, null, null, null, null, managerDTO.CountryID,
                null, null, managerDTO.Email, null)));

            if (UserID == -1)
                return -1;

            eHotelManagerDA eHotelsManagers = HotelsManagersDTOs.ToHotelsManagerEntity(managerDTO, UserID);

           await eHotelManagerDA.AddItemAsync(eHotelsManagers);


            return eHotelsManagers.HotelManagerID;
        }

        public async static Task<eHotelManagerDA?> GetHotelManagerAsync(int UserID)
        {
            return await clsService.Context.HotelsManagers.SingleOrDefaultAsync(m => m.UserID == UserID);
        }

    }
}
