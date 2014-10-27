using System;

namespace DataAccess.Entity
{
    public class Phone
    {
        public int Id { get; set; }
        public int ParentContactId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
