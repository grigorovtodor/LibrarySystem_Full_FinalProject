using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using LibrarySystemPro.DataAccessLayer.Contratcs;

namespace LibrarySystemPro.DataAccessLayer
{
    public class RentedBookRepository : IRepository<RentedBookBusiness>
    {
        public void Create(RentedBookBusiness item)
        {
            //Mapper.Initialize(cfg => cfg.AddProfiles(typeof(RentedBookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbObject = Mapper.Map<RentedBook>(item);
                database.RentedBooks.Add(dbObject);
                database.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbRentedBook = database.RentedBooks.FirstOrDefault(r => r.Id == id);

                if (dbRentedBook.IsDeleted != true)
                {
                    dbRentedBook.IsDeleted = true;
                }

                database.SaveChanges();
            }
        }

        public void Delete(RentedBookBusiness item)
        {
            Delete(item.Id);
        }

        public RentedBookBusiness Read(int id)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(RentedBookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbRentedBook = database.RentedBooks.FirstOrDefault(r => r.Id == id);
                var result = Mapper.Map<RentedBookBusiness>(dbRentedBook);

                return result;
            }
        }

        public ICollection<RentedBookBusiness> ReadAll()
        {
            //Mapper.Initialize(cfg => cfg.AddProfiles(typeof(RentedBookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbRentedBooks = database.RentedBooks.Where(r => r.IsDeleted == false).ToList();
                var result = new List<RentedBookBusiness>();

                foreach (var book in dbRentedBooks)
                {
                    result.Add(Mapper.Map<RentedBookBusiness>(book));
                }

                return result;
            }
        }

        public void Update(RentedBookBusiness item)
        {
            //Mapper.Initialize(cfg => cfg.AddProfiles(typeof(RentedBookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbRentedBook = database.RentedBooks.FirstOrDefault(r => r.Id == item.Id);

                dbRentedBook.DateRented = item.DateRented;
                dbRentedBook.DateToReturn = item.DateToReturn;
                dbRentedBook.IsDeleted = item.IsDeleted;

                if (dbRentedBook.IsDeleted == null)
                {
                    dbRentedBook.IsDeleted = false;
                }

                dbRentedBook.BookId = item.BookId;
                dbRentedBook.UserId = item.UserId;

                //dbRentedBook.Book = Mapper.Map<Book>(item.Book);
                //dbRentedBook.User = Mapper.Map<User>(item.User);

                database.SaveChanges();
            }
        }
    }
}
