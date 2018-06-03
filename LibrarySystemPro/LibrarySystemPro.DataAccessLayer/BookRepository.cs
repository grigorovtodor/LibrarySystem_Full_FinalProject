using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using LibrarySystemPro.DataAccessLayer.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystemPro.DataAccessLayer
{
    public class BookRepository : IRepository<BookBusiness>
    {
        public void Create(BookBusiness item)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(BookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbObject = Mapper.Map<Book>(item);
                database.Books.Add(dbObject);
                database.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(var database = new LibrarySystemProEntities())
            {
                var dbBook = database.Books.FirstOrDefault(b => b.Id == id);

                if (dbBook.IsDeleted != true)
                {
                    dbBook.IsDeleted = true;
                }

                database.SaveChanges();
            }
        }

        public void Delete(BookBusiness item)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(BookRepository)));
            Delete(item.Id);
        }

        public BookBusiness Read(int id)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(BookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbBook = database.Books.FirstOrDefault(b => b.Id == id);
                var result = Mapper.Map<BookBusiness>(dbBook);

                return result;
            }
        }

        public ICollection<BookBusiness> ReadAll()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(BookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbBook = database.Books.Where(b => b.IsDeleted == false).ToList();
                var result = new List<BookBusiness>();

                foreach (var book in dbBook)
                {
                    result.Add(Mapper.Map<BookBusiness>(book));
                }

                return result;
            }
        }

        public void Update(BookBusiness item)
        {
            //Mapper.Initialize(cfg => cfg.AddProfiles(typeof(BookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                AuthorRepository authorRepo = new AuthorRepository();
                var dbBook = database.Books.FirstOrDefault(b => b.Id == item.Id);

                //var result = Mapper.Map<Book>(item);

                dbBook.Name = item.Name;
                dbBook.ISBN = item.ISBN;
                dbBook.PageCount = item.PageCount;
                dbBook.PublishingDate = item.PublishingDate;
                dbBook.IsDeleted = item.IsDeleted;
                if (dbBook.IsDeleted == null)
                {
                    dbBook.IsDeleted = false;
                }

                dbBook.AuthorId = item.AuthorId;
                //dbBook.Author = Mapper.Map<Author>(authorRepo.Read(item.AuthorId));

                database.SaveChanges();
            }
        }

        public bool IsBookRented(int id)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(BookRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                //var dbBook = database.Books.FirstOrDefault(b => b.Id == id);
                var allRentedBooks = new RentedBookRepository().ReadAll();
                var result = false;

                foreach (var book in allRentedBooks)
                {
                    if (book.BookId == id)
                    {
                        result = true;
                    }
                }

                return result;
            }
        }
    }
}
