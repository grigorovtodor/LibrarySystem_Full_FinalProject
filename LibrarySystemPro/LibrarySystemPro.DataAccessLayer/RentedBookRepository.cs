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
            using (var database = new LibrarySystemProEntities())
            {
                var dbRentedBook = database.RentedBooks.FirstOrDefault(r => r.Id == id);
                var result = Mapper.Map<RentedBookBusiness>(dbRentedBook);

                return result;
            }
        }

        public ICollection<RentedBookBusiness> ReadAll()
        {
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

        public DateTime? BookDateRented(int id)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var allRentedBooks = new RentedBookRepository().ReadAll();
                DateTime? result = null;

                foreach (var item in allRentedBooks)
                {
                    if (item.BookId == id)
                    {
                        result = item.DateRented;
                    }
                }

                return result;
            }
        }

        public DateTime? BookDateToReturn(int id)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var allRentedBooks = new RentedBookRepository().ReadAll();
                DateTime? result = null;

                foreach (var item in allRentedBooks)
                {
                    if (item.BookId == id)
                    {
                        result = item.DateToReturn;
                    }
                }

                return result;
            }
        }

        //public void RentBook(RentedBookBusiness rentBook)
        //{
        //    //var _userRepo = new UserRepository();
        //    //var _rentedBookRepository = new RentedBookRepository();
        //    //var _bookRepo = new BookRepository();

        //    //var user = Mapper.Map<UserBusiness>(_userRepo.Read(userId));
        //    //var book = Mapper.Map<BookBusiness>(_bookRepo.Read(bookId));

        //    //var rentedBook = new RentedBookBusiness();
        //    ////rentedBook.User = user;
        //    //rentedBook.UserId = userId;
        //    //rentedBook.DateRented = DateTime.Now;
        //    //rentedBook.DateToReturn = rentedBook.DateRented.Value.AddMonths(1);
        //    //rentedBook.BookId = bookId;
        //    ////rentedBook.Book = book;
        //    var result = Mapper.Map<RentedBook>(rentBook);

        //   Create(rentBook);
        //}
    }
}
