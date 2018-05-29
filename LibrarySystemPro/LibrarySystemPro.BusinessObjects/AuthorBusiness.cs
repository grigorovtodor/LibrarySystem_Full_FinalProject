using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystemPro.BusinessObjects
{
    public class AuthorBusiness
    {
        public AuthorBusiness()
        {
            this.Books = new HashSet<BookBusiness>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Gender { get; set; }
        public Nullable<DateTime> Birthdate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<BookBusiness> Books { get; set; }
    }
}
