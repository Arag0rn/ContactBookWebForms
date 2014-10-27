using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace DataAccess.Repository
{
    public class RepositoryFactory
    {        
        public static UsersRepository GetUsersRepository()
        {            
            return new UsersRepository(HttpContext.Current.Server.MapPath("/DataFiles/users.txt"));
        }

        public static ContactsRepository GetContactsRepository()
        {
            return new ContactsRepository(HttpContext.Current.Server.MapPath("/DataFiles/contacts.txt"));
        }

        public static PhonesRepository GetPhonesRepository()
        {
            return new PhonesRepository(HttpContext.Current.Server.MapPath("/DataFiles/phones.txt"));
        }
    }
}
