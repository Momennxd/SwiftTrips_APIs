using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;


namespace Core_Layer
{
    public class clsHotelsManager : Repository<eHotelsManagersDA>
    {

        public clsHotelsManager()
        {            
        }

        protected override void InitBaseObject()
        {
            base.BaseObject = new eHotelsManagersDA() { UserID = -1 };
        }
    }
}
