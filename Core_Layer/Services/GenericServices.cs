using Business_Logic.Interfaces;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    internal class GenericServices<T> : IGenericServices<T> where T : class
    {

        private IUnitOfWork _unit;

        public GenericServices(IUnitOfWork unit)
        {
            _unit=unit;
        }



        public IGenericRepository<T> GenericRepository()
        {
            if (typeof(T) == typeof(eHotelsManagersDA))
            {
                return (IGenericRepository<T>)_unit.hotleManger;
            }
            else if (typeof(T) == typeof(eUsersDA))
            {
                return (IGenericRepository<T>)_unit.users;
            }
           
            ///
            //  
            ////

            else
            {
                throw new ArgumentException("UnKnown The Entity");
            }


        }


        public bool AddItem(T Item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(int ItemId)
        {
            throw new NotImplementedException();
        }

        public dynamic GetAllItem()
        {
            throw new NotImplementedException();
        }

        public T GetItem(int ItemId)
        {
            throw new NotImplementedException();
        }

        public bool PatchItem(JsonPatchDocument<T> NewItem, int ItemId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(T Item, int ItemID)
        {
            throw new NotImplementedException();
        }
    }
}
