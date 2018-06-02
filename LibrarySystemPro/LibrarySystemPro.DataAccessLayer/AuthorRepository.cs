using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystemPro.BusinessObjects;
using LibrarySystemPro.DatabaseEntity;
using LibrarySystemPro.DataAccessLayer.Contratcs;
using AutoMapper;

namespace LibrarySystemPro.DataAccessLayer
{
    public class AuthorRepository : IRepository<AuthorBusiness>
    {
        public void Create(AuthorBusiness item)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(AuthorRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbObject = Mapper.Map<Author>(item);
                database.Authors.Add(dbObject);
                database.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbAuthor = database.Authors.FirstOrDefault(a => a.Id == id);

                if (dbAuthor.IsDeleted != true)
                {
                    dbAuthor.IsDeleted = true;
                }

                database.SaveChanges();
            }
        }

        public void Delete(AuthorBusiness item)
        {
            Delete(item.Id);
        }

        public AuthorBusiness Read(int id)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(AuthorRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbAuthor = database.Authors.FirstOrDefault(a => a.Id == id);
                var result = Mapper.Map<AuthorBusiness>(dbAuthor);

                return result;
            }
        }

        public ICollection<AuthorBusiness> ReadAll()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(AuthorRepository)));

            using (var database = new LibrarySystemProEntities())
            {
                var dbAuthors = database.Authors.Where(a => a.IsDeleted == false).ToList();
                var result = new List<AuthorBusiness>();

                foreach (var author in dbAuthors)
                {
                    result.Add(Mapper.Map<AuthorBusiness>(author));
                }

                return result;
            }
        }

        public void Update(AuthorBusiness item)
        {
            using (var database = new LibrarySystemProEntities())
            {
                var dbAuthor = database.Authors.FirstOrDefault(a => a.Id == item.Id);

                dbAuthor.Name = item.Name;
                dbAuthor.Birthdate = item.Birthdate;
                dbAuthor.Gender = item.Gender;
                dbAuthor.IsDeleted = item.IsDeleted;

                if (dbAuthor.IsDeleted == null)
                {
                    dbAuthor.IsDeleted = false;
                }

                database.SaveChanges();
            }
        }
    }
}