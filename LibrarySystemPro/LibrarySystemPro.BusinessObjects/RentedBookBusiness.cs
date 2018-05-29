using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystemPro.BusinessObjects
{
    public class RentedBookBusiness
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Nullable<DateTime> DateRented { get; set; }
        public Nullable<DateTime> DateToReturn { get; set; }

        public virtual BookBusiness Book { get; set; }
        public virtual UserBusiness User { get; set; }
    }
}
