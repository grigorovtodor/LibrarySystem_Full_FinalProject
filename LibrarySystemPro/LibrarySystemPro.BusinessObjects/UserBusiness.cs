using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystemPro.BusinessObjects
{
    public class UserBusiness
    {
        public UserBusiness()
        {
            this.RentedBooks = new HashSet<RentedBookBusiness>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueIdNumber { get; set; }
        public string Address { get; set; }
        public Nullable<byte> Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<RentedBookBusiness> RentedBooks { get; set; }
    }
}
