using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
    public interface IGenericServices<T> where T : class
    {
        dynamic GetAllItem();  
        T GetItem(int ItemId);

        bool AddItem(T Item);

        bool DeleteItem(int ItemId);

        bool UpdateItem(T Item, int ItemID);

        bool PatchItem(JsonPatchDocument<T> NewItem, int ItemId);


    }
}
