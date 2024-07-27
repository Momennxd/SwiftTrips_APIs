using ConsoleApp1;
using Microsoft.AspNetCore.JsonPatch;

namespace DataAccess_Layer.Repository
{
    public abstract class Repository<T> where T : class
    {
        #region Repository init
        protected static AppDbContext context { get; private set; }
        static Repository()
        {
            context = new AppDbContext();
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

        #region Static Members
        public static T? GetItem(dynamic ItemPK)
        {
            if (ItemPK == null)
                return null;

            using (AppDbContext context = new AppDbContext())
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
        public static List<T>? GetAllItem()
        {
            List<T>? AllItems = null;
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    AllItems = context.Set<T>().ToList();
                }
            }
            catch (Exception ex) { }

            return AllItems;

        }



        public static bool AddItem(T Item)
        {
            if (Item == null)
                return false;


            try
            {
                using (AppDbContext context = new AppDbContext())
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



        public static bool DeleteItem(dynamic ItemPK)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    // Need To Perform
                    var Item = context.Set<T>().Find(ItemPK);
                    context.Set<T>().Remove(Item);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        // Need To Perform
        public static bool UpdateItem(T NewItem, dynamic ItemPK)
        {
            if (NewItem == null)
            {
                return false;
            }


            try
            {
                using (AppDbContext context = new AppDbContext())
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
