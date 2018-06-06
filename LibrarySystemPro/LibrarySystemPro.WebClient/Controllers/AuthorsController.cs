using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystemPro.WebClient.Models;
using LibrarySystemPro.DataAccessLayer;
using AutoMapper;
using LibrarySystemPro.BusinessObjects;

namespace LibrarySystemPro.WebClient.Controllers
{
    public class AuthorsController : Controller
    {
        private BookRepository _bookRepo = new BookRepository();
        private AuthorRepository _authorRepo = new AuthorRepository();
        private UserRepository _userRepo = new UserRepository();
        private RentedBookRepository _rentedBookRepo = new RentedBookRepository();


        // GET: Authors
        public ActionResult Index()
        {
            var authors = _authorRepo.ReadAll();

            var list = new List<Author>();

            foreach (var author in authors)
            {
                var current = Mapper.Map<Author>(author);

                list.Add(current);
            }

            return View(list);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Author author = Mapper.Map<Author>(_authorRepo.Read(id));

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,Birthdate,IsDeleted")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepo.Create(Mapper.Map<AuthorBusiness>(author));
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = Mapper.Map<Author>(_authorRepo.Read(id));

            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,Birthdate,IsDeleted")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepo.Update(Mapper.Map<AuthorBusiness>(author));
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Author author = Mapper.Map<Author>(_authorRepo.Read(id));

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = Mapper.Map<Author>(_authorRepo.Read(id));
            _authorRepo.Delete(Mapper.Map<AuthorBusiness>(author));
            return RedirectToAction("Index");
        }
    }
}
