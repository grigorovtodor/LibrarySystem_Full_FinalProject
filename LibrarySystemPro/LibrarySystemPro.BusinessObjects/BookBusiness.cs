using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemPro.BusinessObjects
{
    public class BookBusiness
    {
        public Book()
        {
            this.RentedBooks = new HashSet<RentedBookBusiness>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> PageCount { get; set; }
        public Nullable<DateTime> PublishingDate { get; set; }
        public int AuthorId { get; set; }
        public bool IsDeleted { get; set; }

        public  AuthorBusiness Author { get; set; }
        public  ICollection<RentedBookBusiness> RentedBooks { get; set; }
    }
}
