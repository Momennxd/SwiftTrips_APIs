

using ConsoleApp1;
using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Repository
{
    public interface IBasicRepository<T> where T : class
    {

        /// <summary>
        /// Gets all the items
        /// </summary>
        /// <returns></returns>
        dynamic GetAllItem();


        /// <summary>
        /// Returns Null if nothing was found.
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>      
        T GetItem(int ItemId);





        /// <summary>
        /// Returns TRUE if saved successfully or FALSE if some error happed in the database 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        bool AddItem(T Item);




        /// <summary>
        /// Returns TRUE if saved successfully or FALSE if some error happed in the database 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        bool DeleteItem(int ItemId);





        /// <summary>
        /// Returns TRUE if saved successfully or FALSE if some error happed in the database 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        bool UpdateItem(T Item, int ItemID);





        /// <summary>
        /// Returns TRUE if saved successfully or FALSE if some error happed in the database 
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        bool PatchItem(JsonPatchDocument<T> NewItem, int ItemId);



    }
}
