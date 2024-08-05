using API_Layer.DTOs;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


namespace Core_Layer
{
    public static class clsHotelsManagerCore
    {

       

      


        public static int AddItem(HotelsManagersDTOs.CreateHotelsManagerDTO managerDTO)
        {

            int UserID = clsUserCore.AddItem(new UsersDTOs.CreateUserDTO(managerDTO.Username, managerDTO.Password,
                new PeopleDTOs.CreatePersonDTO(managerDTO.Name, null, null, null, null, managerDTO.CountryID,
                null, null, managerDTO.Email, null)));

            if (UserID == -1)
                return -1;

            eHotelManagerDA eHotelsManagers = HotelsManagersDTOs.ToHotelsManagerEntity(managerDTO, UserID);

            eHotelManagerDA.AddItem(eHotelsManagers);


            return eHotelsManagers.HotelManagerID;
        }

        public static eHotelManagerDA? GetHotelManager(int UserID)
        {
            return clsService.Context.HotelsManagers.SingleOrDefault(m => m.UserID == UserID);
        }


    }
}
