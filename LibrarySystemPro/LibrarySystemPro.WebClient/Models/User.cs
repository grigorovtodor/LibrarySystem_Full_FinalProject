using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystemPro.WebClient.Models
{
    public class User
    {
        public User()
        {
            this.RentedBooks = new HashSet<RentedBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueIdNumber { get; set; }
        public string Address { get; set; }
        public Nullable<byte> Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<RentedBook> RentedBooks { get; set; }
    }
}
