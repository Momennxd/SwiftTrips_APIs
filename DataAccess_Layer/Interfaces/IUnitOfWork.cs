using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // public IBasicRepository<eHotelsManagersDA> hotleMangers { get; }


         public  IGenericRepository<eHotelsManagersDA> hotleManger { get; }

         public IGenericRepository<eUsersDA> users {  get; }

        int Complete();


    }
}
