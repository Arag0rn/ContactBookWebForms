using System;

namespace DataAccess.Entity
{
    public class User
    {
        public int Id { get; set; }
        public short AdminPrivilegeIndex { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }       
    }
}
