using System;

namespace DataAccess.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        public int ParentUserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0} | Email: {1} | Address: {2} | Company: {3}",
                this.FullName, this.Email, this.Address, this.Company);
        }
    }
}
