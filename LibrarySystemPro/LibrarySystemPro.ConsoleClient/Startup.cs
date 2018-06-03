
using AutoMapper;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DataAccessLayer;
using LibrarySystemPro.DataAccessLayer.Profiles;
using LibrarySystemPro.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystemPro.ConsoleClient
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //Mapper.Initialize(cfg => cfg.AddProfiles(typeof(Startup)));

            var bookRepo = new BookRepository();
            var authorRepo = new AuthorRepository();
            var userRepo = new UserRepository();
            var rentedBookRepo = new RentedBookRepository();


            //var testBookBusiness = new BookBusiness { Name = "Test 3", ISBN = "987654321987", PageCount = 150, IsDeleted = false, PublishingDate = new DateTime(2016, 05, 07), AuthorId = 1 };
            //var authorData = new AuthorBusiness();
            //authorData.Name = "Test Author Business";
            //authorData.Birthdate = new DateTime(2017, 12, 23);
            //authorData.Books.Add(testBookBusiness);
            //authorData.Books.ToList();
            //authorData.IsDeleted = false;
            //authorData.Gender = 0;

            //var testUser = new UserBusiness { Name = "Test User", IsDeleted = false, Address = "Mladost 1", Email = "testUser@test.bg",
            //    Gender = 0, PhoneNumber = "0879 555 201", UniqueIdNumber = "7946132598" };

            //var testRentedBook = new RentedBookBusiness { BookId = 10, UserId = 1, DateRented = DateTime.Now, DateToReturn = new DateTime(2018, 06, 05), IsDeleted = false};
            //var authorUpdate = authorRepo.Read(2);
            //authorUpdate.Name = "Test Author Business 2";
            //authorUpdate.Birthdate = new DateTime(2000, 5, 3);
            //authorRepo.Update(authorUpdate);

            //var bookUpdate = bookRepo.Read(9);
            //bookUpdate.Name = "Updated name 2";
            //bookRepo.Update(bookUpdate);

            //authorRepo.Create(authorData);
            //bookRepo.Create(testBookBusiness);
            //userRepo.Create(testUser);
            //var rentedBookToUpdate = rentedBookRepo.Read(2);
            //rentedBookToUpdate.DateToReturn = new DateTime(2018, 06, 15);
            // rentedBookRepo.Update(rentedBookToUpdate);

            //var isRentedBook = bookRepo.IsBookRented(9);
            //Console.WriteLine(isRentedBook);

            //var book = Mapper.Map<BookBusiness>(bookBusiness);
            //var author = Mapper.Map<AuthorBusiness>(authorData);

            //bookRepo.Delete(8);


            //Console.WriteLine($"{book.Name}, {book.ISBN}, {book.PageCount}, {book.IsDeleted}");
            //Console.WriteLine($"{author.Name}, {author.Birthdate}, {author.Gender}, {author.IsDeleted}");

            //foreach (var item in authorData.Books)
            //{
            //    Console.WriteLine($"{item.Name}, {item.PageCount}, {item.ISBN}, {item.IsDeleted}");
            //}
        }
    }
}
