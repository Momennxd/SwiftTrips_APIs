using API_Layer.DTOs;
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


namespace Core_Layer
{
    public class clsHotelsManager : Repository<HotelManager>
    {

        public clsHotelsManager()
        {
            
        }

        public clsHotelsManager(HotelManager? baseObj)
        {
            base.BaseObject = baseObj;
        }


        //Navigation Property
        public User User
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
                null, null, managerDTO.Email, null)));

            if (UserID == -1)
                return -1;

            HotelManager eHotelsManagers = HotelsManagersDTOs.ToHotelsManagerEntity(managerDTO, UserID);
            
            AddItem(eHotelsManagers);


            return eHotelsManagers.HotelManagerID;
        }
        
        public static clsHotelsManager GetHotelManager(int UserID)
        {
             return new clsHotelsManager(context.HotelsManagers.SingleOrDefault(m => m.UserID == UserID));
        }


        protected override void InitBaseObject()
        {
            base.BaseObject = new HotelManager() { UserID = -1 };
        }
    }
}
