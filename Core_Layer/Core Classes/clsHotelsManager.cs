using API_Layer.DTOs;
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


namespace Core_Layer
{
    public class clsHotelsManager : Repository<eHotelsManagersDA>
    {

        public clsHotelsManager()
        {
            
        }

        public clsHotelsManager(eHotelsManagersDA? baseObj)
        {
            base.BaseObject = baseObj;
        }


        //NP
        public eUsersDA User
        {
            get
            {
                return clsUser.GetItem(BaseObject.UserID);
            }
        }


        public static int AddItem(HotelsManagersDTOs.CreateHotelsManagerDTO managerDTO)
        {

            int UserID = clsUser.AddItem(new UsersDTOs.CreateUserDTO(managerDTO.Username, managerDTO.Password,
                new PeopleDTOs.CreatePersonDTO(managerDTO.Name, null, null, null, null, managerDTO.CountryID,
                null, null, null, null)));

            if (UserID == -1)
                return -1;


            eHotelsManagersDA eHotelsManagers = HotelsManagersDTOs.ToHotelsManagerEntity(managerDTO);
            eHotelsManagers.UserID = UserID;


            clsHotelsManager.AddItem(eHotelsManagers);


            return eHotelsManagers.HotelManagerID;
        }

        public static clsHotelsManager GetHotelManager(int UserID)
        {
             return new clsHotelsManager(context.HotelsManagers.SingleOrDefault(m => m.UserID == UserID));
        }


        protected override void InitBaseObject()
        {
            base.BaseObject = new eHotelsManagersDA() { UserID = -1 };
        }
    }
}
