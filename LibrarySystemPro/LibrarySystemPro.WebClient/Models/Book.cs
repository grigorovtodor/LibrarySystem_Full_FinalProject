using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystemPro.WebClient.Models
{
    public class Book
    {
        private bool isRented;

        public Book()
        {
            this.RentedBooks = new HashSet<RentedBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> PageCount { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> PublishingDate { get; set; }

        public int AuthorId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRented { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateRented { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateToReturn { get; set; }

        public Author Author { get; set; }
        public ICollection<RentedBook> RentedBooks { get; set; }
    }
}