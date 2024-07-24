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


        // NP
        public eUsersDA User 
        {
            get
            {
                clsUser user = new clsUser();
                return user.GetItem(this.BaseObject.UserID);
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


            clsHotelsManager hotelsManager = new clsHotelsManager();

            hotelsManager.AddItem(eHotelsManagers);


            return eHotelsManagers.HotelManagerID;
        }

        public static clsHotelsManager GetItem(int UserID)
        {
            clsHotelsManager HM = new clsHotelsManager();
            HM.BaseObject = new clsHotelsManager().context.HotelsManagers.SingleOrDefault(h => h.UserID == UserID);
            return HM;
        }


        protected override void InitBaseObject()
        {
            base.BaseObject = new eHotelsManagersDA() { UserID = -1 };
        }
    }
}
