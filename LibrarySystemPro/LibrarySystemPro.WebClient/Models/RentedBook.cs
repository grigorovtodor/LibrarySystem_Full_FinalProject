using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystemPro.WebClient.Models
{
    public class RentedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Nullable<DateTime> DateRented { get; set; }
        public Nullable<DateTime> DateToReturn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}