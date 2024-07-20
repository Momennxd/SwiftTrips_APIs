
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;


namespace Core_Layer
{
    public class clsPerson : Repository<ePeopleDA>
    {

        private AppDbContext _AppDbContext { get; set; }

        public bool JoinedToday { get { return DateTime.Today == this.BaseObject.JoinedDate; } }

        public clsPerson()
        {
            _AppDbContext = new AppDbContext();
            base.Init(_AppDbContext);


           
        }



        
    }
}
