using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using LibrarySystemPro.DataAccessLayer.Contratcs;

namespace LibrarySystemPro.DataAccessLayer
{
    public class UserRepository : IRepository<UserBusiness>
    {
        public void Create(UserBusiness item)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbObject = Mapper.Map<User>(item);
                database.Users.Add(dbObject);
                database.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbUser = database.Users.FirstOrDefault(u => u.Id == id);

                if (dbUser.IsDeleted != true)
                {
                    dbUser.IsDeleted = true;
                }

                database.SaveChanges();
            }
        }

        public void Delete(UserBusiness item)
        {
            Delete(item.Id);
        }

        public UserBusiness Read(int id)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbUser = database.Users.FirstOrDefault(u => u.Id == id);
                var result = Mapper.Map<UserBusiness>(dbUser);

                return result;
            }
        }

        public ICollection<UserBusiness> ReadAll()
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbUsers = database.Users.Where(u => u.IsDeleted == false).ToList();
                var result = new List<UserBusiness>();

                foreach (var user in dbUsers)
                {
                    result.Add(Mapper.Map<UserBusiness>(user));
                }

                return result;
            }
        }

        public void Update(UserBusiness item)
        {

            using (var database = new LibrarySystemProEntities())
            {
                var dbUser = database.Users.FirstOrDefault(u => u.Id == item.Id);

                dbUser.Name = item.Name;
                dbUser.Email = item.Email;
                dbUser.Address = item.Address;
                dbUser.PhoneNumber = item.PhoneNumber;
                dbUser.UniqueIdNumber = item.UniqueIdNumber;
                dbUser.Gender = item.Gender;
                dbUser.IsDeleted = item.IsDeleted;

                if (dbUser.IsDeleted == null)
                {
                    dbUser.IsDeleted = false;
                }

                database.SaveChanges();
            }
        }

        //public void RentBook(int userId, int bookId)
        //{
        //    using (var database = new LibrarySystemProEntities())
        //    {
        //        var dbUser = database.Users.FirstOrDefault(u => u.Id == userId);
        //        var rentedBooks = new RentedBookRepository().ReadAll();


        //        if (dbUser.IsDeleted != true)
        //        {
        //            dbUser.IsDeleted = true;
        //        }

        //        database.SaveChanges();
        //    }
        //}

        public List<RentedBookBusiness> RentedBooksByUser(int id)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbRentedBooks = database.RentedBooks.Where(r => r.IsDeleted == false && r.UserId == id).ToList();
                var result = new List<RentedBookBusiness>();

                foreach (var book in dbRentedBooks)
                {
                    result.Add(Mapper.Map<RentedBookBusiness>(book));
                }

                return result;
            }
        }
    }
}
