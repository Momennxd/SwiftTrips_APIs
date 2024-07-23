using API_Layer.DTOs;
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Data;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;


namespace Core_Layer
{
    public class clsHotelsManager : GenericRepository<eHotelsManagersDA>
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



        protected override void InitBaseObject()
        {
            base.BaseObject = new eHotelsManagersDA() { UserID = -1 };
        }
    }
}
