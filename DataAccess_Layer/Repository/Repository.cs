using ConsoleApp1;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace DataAccess_Layer.Repository
{
    public abstract class Repository<T> where T : class
    {
        #region Repository init
        protected static AppDbContext context { get; private set; }
        static Repository()
        {
            context = clsService.contextFactory!.CreateDbContext();
        }

        public Repository()
        {
            InitBaseObject();
        }




        /// <summary>
        /// This function init the base object with the default values depending on the child class.
        /// </summary>
        protected abstract void InitBaseObject();
        public T? BaseObject { get; set; }
        #endregion


        #region Get Item
        public static T? GetItem(dynamic ItemPK)
        {
            if (ItemPK == null)
                return null;

            using (AppDbContext context = clsService.contextFactory!.CreateDbContext())
            {

                try
                {
                    return context.Set<T>().Find(ItemPK);

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public static async Task<T?> GetItemAsync(dynamic ItemPK)
        {
            if (ItemPK == null)
                return null;

            using (AppDbContext context = await clsService.contextFactory!.CreateDbContextAsync())
            {

                try
                {
                    return await context.Set<T>().FindAsync(ItemPK);

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        #endregion

        #region Get All Items
        public static List<T>? GetAllItems()
        {
            List<T>? AllItems = null;
            try
            {
                using (AppDbContext context = clsService.contextFactory!.CreateDbContext())
                {
                    AllItems = context.Set<T>().ToList();
                }
            }
            catch (Exception ex) { }

            return AllItems;

        }
        public static async Task<List<T>?> GetAllItemsAsync()
        {
            List<T>? AllItems = null;
            try
            {
                using (AppDbContext context = await clsService.contextFactory!.CreateDbContextAsync())
                {
                    AllItems = await context.Set<T>().ToListAsync();
                }
            }
            catch (Exception ex) { }

            return AllItems;

        }

        #endregion

        #region Add Item
        public static bool AddItem(T Item)
        {
            if (Item == null)
                return false;


            try
            {
                using (AppDbContext context = clsService.contextFactory!.CreateDbContext())
                {
                    context.Set<T>().Add(Item);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public static async Task<bool> AddItemAsync(T Item)
        {
            if (Item == null)
                return false;


            try
            {
                using (AppDbContext context = await clsService.contextFactory!.CreateDbContextAsync())
                {

                    await context.Set<T>().AddAsync(Item);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        #endregion

        #region Delete Item
        public static bool DeleteItem(dynamic ItemPK)
        {
            try
            {
                using (AppDbContext context = clsService.contextFactory!.CreateDbContext())
                {
                    // Need To Perform
                    var Item = context.Set<T>().Find(ItemPK);
                    context.Set<T>().Remove(Item);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        public static async Task<bool> DeleteItemAsync(dynamic ItemPK)
        {
            try
            {
                using (AppDbContext context = await clsService.contextFactory!.CreateDbContextAsync())
                {
                    // Need To Perform
                    var Item = await context.Set<T>().FindAsync(ItemPK);
                    context.Set<T>().Remove(Item);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        #endregion

        #region In Progress

        // Need To Perform
        public static bool UpdateItem(T NewItem, dynamic ItemPK)
        {
            if (NewItem == null)
            {
                return false;
            }


            try
            {
                using (AppDbContext context = clsService.contextFactory!.CreateDbContext())
                {

                    T Item = context.Set<T>()
                        .Find(ItemPK);

                    // تحقق من وجود الكيان
                    if (Item == null)
                    {
                        return false;
                    }

                    //// تحديث كافة الخصائص
                    //context.Entry(Item).CurrentValues.SetValues(NewItem);

                    var keyProperties = context.Model.FindEntityType(typeof(T))
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


                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // يمكنك تسجيل الخطأ هنا
                return false;
            }



        }



        public static bool PatchItem(JsonPatchDocument<T> NewItem, dynamic ItemPK)
        {

            if (NewItem == null || context == null)
            {
                return false;
            }

            try
            {
                T Item = context.Set<T>().Find(ItemPK);

                //id does not exist
                if (Item == null)
                    return false;

                NewItem.ApplyTo(Item);

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion



    }
}
