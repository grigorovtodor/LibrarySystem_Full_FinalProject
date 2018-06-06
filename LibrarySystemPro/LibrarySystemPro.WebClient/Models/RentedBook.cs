using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystemPro.WebClient.Models
{
    public class RentedBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateRented { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateToReturn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}