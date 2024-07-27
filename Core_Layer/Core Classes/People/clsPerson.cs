﻿
using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Repository;


namespace Core_Layer
{
    public class clsPerson : Repository<ePeopleDA>
    {
        public clsPerson()
        {
            
        }

        public string FullName { get { return this.BaseObject.FirstName + " " +  this.BaseObject.LastName; } }
       
        protected override void InitBaseObject()
        {
            base.BaseObject = new ePeopleDA()
            {
                Email = "",
                FirstName = "",
                CountryID = -1,
                JoinedDate = DateTime.MinValue
               
            };

        }
    }
}
