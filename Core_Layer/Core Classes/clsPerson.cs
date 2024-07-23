
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Data;
using DataAccess_Layer.Entities.People;


namespace Core_Layer
{
    public class clsPerson : GenericRepository<ePeopleDA>
    {
        public clsPerson()
        {

        }


       
        protected override void InitBaseObject()
        {
            base.BaseObject = new ePeopleDA()
            {
                FirstName = "",
                CountryID = -1,
                JoinedDate = DateTime.MinValue
               
            };

        }
    }
}
