using DataAccess_Layer.Entities;
using DataAccess_Layer.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Data
{
    public  class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        // //public AppDbContext context { get; private set; }

        // /// <summary>
        // /// Initializes the class by Initializing the appDbContext 
        // /// </summary>
        // /// <param name="context"></param>
        // /// <returns>
        // /// True if init successfully, False if context is null
        // /// </returns>
        // //private void InitContext()
        // //{
        // //    context = new AppDbContext();
        // //}



        // private readonly AppDbContext _context;

        // protected Repository(AppDbContext context)
        // {
        //     _context=context;
        // }

        // //public Repository()
        // //{
        // //    InitContext();
        // //    InitBaseObject();
        // //}


        // /// <summary>
        // /// This function init the base object with the default values depending on the child class.
        // /// </summary>
        //// protected abstract void InitBaseObject();


        // //public T BaseObject { get; set; }

















        // public dynamic GetAllItem()
        // {
        //     if (context == null)
        //         return null;

        //     return context.Set<T>().ToList();


        // }



        // public T GetItem(int ItemID)
        // {
        //     if (ItemID <= 0)
        //         return null;

        //     if (context == null)
        //         return null;

        //     return context.Set<T>().Find(ItemID);
        // }




        // public bool AddItem(T Item)
        // {
        //     if (Item == null || context == null)
        //         return false;


        //     try
        //     {
        //         context.Set<T>().Add(Item);
        //         context.SaveChanges();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         return false;
        //     }


        // }





        // public bool DeleteItem(int ItemID)
        // {
        //     if (ItemID <= 0 || context == null)
        //     {
        //         return false;
        //     }

        //     try
        //     {

        //         var Item = context.Set<T>().Find(ItemID);

        //         context.Set<T>().Remove(Item);
        //         context.SaveChanges();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         return false;
        //     }


        // }






        // public bool UpdateItem(T NewItem, int ItemID)
        // {
        //     if (NewItem == null || context == null)
        //     {
        //         return false;
        //     }


        //     try
        //     {
        //         T Item = context.Set<T>()
        //             .Find(ItemID);

        //         // تحقق من وجود الكيان
        //         if (Item == null)
        //         {
        //             return false;
        //         }

        //         //// تحديث كافة الخصائص
        //         //context.Entry(Item).CurrentValues.SetValues(NewItem);

        //         var keyProperties = context.Model.FindEntityType(typeof(T))
        //                                 .FindPrimaryKey()
        //                                 .Properties;

        //         // Get all properties of the entity type
        //         var properties = typeof(T).GetProperties();

        //         // Update properties except the key properties
        //         foreach (var property in properties)
        //         {
        //             // Skip key properties
        //             if (keyProperties.Any(kp => kp.Name == property.Name))
        //             {
        //                 continue;
        //             }

        //             var newValue = property.GetValue(NewItem);
        //             property.SetValue(Item, newValue);
        //         }


        //         context.SaveChanges();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         // يمكنك تسجيل الخطأ هنا
        //         return false;
        //     }



        // }






        // public bool PatchItem(JsonPatchDocument<T> NewItem, int ItemID)
        // {

        //     if (NewItem == null || ItemID <= 0 || context == null)
        //     {
        //         return false;
        //     }

        //     try
        //     {
        //         T Item = context.Set<T>().Find(ItemID);

        //         //id does not exist
        //         if (Item == null)
        //             return false;

        //         NewItem.ApplyTo(Item);

        //         context.SaveChanges();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         return false;
        //     }
        // }



        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {

            _context = context;
        }


        public dynamic GetAllItem()
        {


            return _context.Set<T>().ToList();


        }



        public T GetItem(int ItemID)
        {



            if (ItemID <= 0)
                return null;

            return _context.Set<T>().Find(ItemID);
        }




        public bool AddItem(T Item)
        {
            if (Item == null)
                return false;


            try
            {
                _context.Set<T>().Add(Item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }





        public bool DeleteItem(int ItemID)
        {
            if (ItemID <= 0)
            {
                return false;
            }

            try
            {

                var Item = _context.Set<T>().Find(ItemID);

                _context.Set<T>().Remove(Item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }






        public bool UpdateItem(T NewItem, int ItemID)
        {
            if (NewItem == null)
            {
                return false;
            }


            try
            {
                T Item = _context.Set<T>()
                    .Find(ItemID);

                // تحقق من وجود الكيان
                if (Item == null)
                {
                    return false;
                }

                //// تحديث كافة الخصائص
                //context.Entry(Item).CurrentValues.SetValues(NewItem);

                var keyProperties = _context.Model.FindEntityType(typeof(T))
                                        .FindPrimaryKey()
                                        .Properties;

                // Get all properties of the entity type
                var properties = typeof(T).GetProperties();

                // Update properties except the key properties
                foreach (var property in properties)
                {
                    // Skip key properties
                    if (keyProperties.Any(kp => kp.Name == property.Name))
                    {
                        continue;
                    }

                    var newValue = property.GetValue(NewItem);
                    property.SetValue(Item, newValue);
                }


                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ هنا
                return false;
            }



        }






        public bool PatchItem(JsonPatchDocument<T> NewItem, int ItemID)
        {

            if (NewItem == null || ItemID <= 0)
            {
                return false;
            }

            try
            {
                T Item = _context.Set<T>().Find(ItemID);

                //id does not exist
                if (Item == null)
                    return false;

                NewItem.ApplyTo(Item);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}