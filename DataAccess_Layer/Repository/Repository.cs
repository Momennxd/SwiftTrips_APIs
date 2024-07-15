using ConsoleApp1;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using DataAccess_Layer.Repository;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Repository
{
    public class Repository<T> : IBasicRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }


        public dynamic GetAllItem()
        {
            return context.Set<T>().ToList();
        }
        public T GetItem(int ItemID)
        {
            if (ItemID <= 0)
                return null;

            return context.Set<T>().Find(ItemID);
        }
        public bool AddItem(T Item)
        {
            if (Item == null)
            {
                return false;
            }

            try
            {
                context.Set<T>().Add(Item);
                context.SaveChanges();
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

                var Item = context.Set<T>().Find(ItemID);

                context.Set<T>().Remove(Item);
                context.SaveChanges();
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
                T Item = context.Set<T>()
                    .Find(ItemID);

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
                T Item = context.Set<T>().Find(ItemID);

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


    }
}












//public static dynamic GetAllPeople()
//{
//    AppDbcontext context = new AppDbcontext();


//    return context.People.AsNoTracking().ToList();
//}


//public static ePeopleDA GetPerson(int personID)
//{
//    if (personID <= 0)
//        return null;

//    AppDbcontext context = new AppDbcontext();


//    return context.People.Select(e => e).Where(e => e.PersonID == personID).FirstOrDefault();
//}


//public static bool AddPerson(ePeopleDA Person)
//{
//    if (Person == null)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();

//    try
//    {
//        context.People.Add(Person);
//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }


//}


//public static bool DeletePerson(int PersonID)
//{
//    if (PersonID <= 0)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();

//    try
//    {

//        ePeopleDA Person = context.People.Find(PersonID);

//        context.People.Remove(Person);
//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }


//}



//public static bool UpatePerson(ePeopleDA newPerson, int personID)
//{
//    if (newPerson == null)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();


//    try
//    {
//        ePeopleDA person = context.People.Find(personID);

//        //id does not exist
//        if (person == null)
//            return false;

//        person.FirstName = newPerson.FirstName;
//        person.LastName = newPerson.LastName;
//        person.Gender = newPerson.Gender;
//        person.ProfilePicPath = newPerson.ProfilePicPath;
//        person.Address = newPerson.Address;
//        person.DateOfBirth = newPerson.DateOfBirth;
//        person.Phone = newPerson.Phone;
//        person.CountryID = newPerson.CountryID;

//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }
//}


//public static bool PatchPerson(JsonPatchDocument<ePeopleDA> NewPerson, int personID)
//{
//    if (NewPerson == null || personID <= 0)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();


//    try
//    {
//        ePeopleDA person = context.People.Find(personID);

//        //id does not exist
//        if (person == null)
//            return false;

//        NewPerson.ApplyTo(person);

//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }
//}












//public static dynamic GetAllPeople()
//{
//    AppDbcontext context = new AppDbcontext();


//    return context.People.AsNoTracking().ToList();
//}


//public static ePeopleDA GetPerson(int personID)
//{
//    if (personID <= 0)
//        return null;

//    AppDbcontext context = new AppDbcontext();


//    return context.People.Select(e => e).Where(e => e.PersonID == personID).FirstOrDefault();
//}


//public static bool AddPerson(ePeopleDA Person)
//{
//    if (Person == null)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();

//    try
//    {
//        context.People.Add(Person);
//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }


//}


//public static bool DeletePerson(int PersonID)
//{
//    if (PersonID <= 0)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();

//    try
//    {

//        ePeopleDA Person = context.People.Find(PersonID);

//        context.People.Remove(Person);
//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }


//}



//public static bool UpatePerson(ePeopleDA newPerson, int personID)
//{
//    if (newPerson == null)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();


//    try
//    {
//        ePeopleDA person = context.People.Find(personID);

//        //id does not exist
//        if (person == null)
//            return false;

//        person.FirstName = newPerson.FirstName;
//        person.LastName = newPerson.LastName;
//        person.Gender = newPerson.Gender;
//        person.ProfilePicPath = newPerson.ProfilePicPath;
//        person.Address = newPerson.Address;
//        person.DateOfBirth = newPerson.DateOfBirth;
//        person.Phone = newPerson.Phone;
//        person.CountryID = newPerson.CountryID;

//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }
//}


//public static bool PatchPerson(JsonPatchDocument<ePeopleDA> NewPerson, int personID)
//{
//    if (NewPerson == null || personID <= 0)
//    {
//        return false;
//    }

//    AppDbcontext context = new AppDbcontext();


//    try
//    {
//        ePeopleDA person = context.People.Find(personID);

//        //id does not exist
//        if (person == null)
//            return false;

//        NewPerson.ApplyTo(person);

//        context.SaveChanges();
//        return true;
//    }
//    catch (Exception ex)
//    {
//        return false;
//    }
//}

















