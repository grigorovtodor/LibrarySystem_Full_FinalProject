using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystemPro.WebClient.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Birthdate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }


        public string GenderTransformation(Author auothor)
        {
            var result = string.Empty;

            switch (auothor.Gender)
            {
                case 0:
                    {
                        result = "Not known";
                        break;
                    }
                case 1:
                    {
                        result = "Female";
                        break;
                    }
                case 2:
                    {
                        result = "Male";
                        break;
                    }
                default:
                    result = "not applicable";
                    break;
            }

            return result;
        }

        //public Author GenderTransformation(string gender)
        //{
        //    var result = string.Empty;

        //    switch (gender)
        //    {
        //        case "Not known":
        //            {
        //                result = "Not known";
        //                break;
        //            }
        //        case 1:
        //            {
        //                result = "Female";
        //                break;
        //            }
        //        case 2:
        //            {
        //                result = "Male";
        //                break;
        //            }
        //        default:
        //            result = "not applicable";
        //            break;
        //    }

        //    return result;
        //}
    }
}