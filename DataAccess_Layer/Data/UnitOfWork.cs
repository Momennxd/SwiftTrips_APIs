using DataAccess_Layer.Entities;
using DataAccess_Layer.Entities.People;
using DataAccess_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public IGenericRepository<eHotelsManagersDA> hotleManger {  get; private set; }

       public IGenericRepository<eUsersDA> users {  get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context=context;

            hotleManger = new  GenericRepository<eHotelsManagersDA> (_context);

            users = new GenericRepository<eUsersDA> (_context);
        }

      

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Complete()
        {
            return 1;
        }

      
    }
}
