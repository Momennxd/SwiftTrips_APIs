using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities;



namespace Business_Layer.Classes
{
    public class clsPeople
    {

        public int PersonID { get; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string Gender { get; set; }

        public int CountryID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePicPath { get; set; }



        //public static dynamic GetAllPeople()
        //{

        //    return DataAccess_Layer.Entities.ePeopleDA.GetAllPeople();
        //}





    }
}
