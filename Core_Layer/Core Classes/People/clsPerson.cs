
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;


namespace Core_Layer
{
    public class clsPerson : Repository<Person>
    {
        public clsPerson()
        {
            
        }

        public string FullName { get { return this.BaseObject.FirstName + " " +  this.BaseObject.LastName; } }
       
        protected override void InitBaseObject()
        {
            base.BaseObject = new Person()
            {
                Email = "",
                FirstName = "",
                CountryID = -1,
                JoinedDate = DateTime.MinValue
               
            };

        }
    }
}
