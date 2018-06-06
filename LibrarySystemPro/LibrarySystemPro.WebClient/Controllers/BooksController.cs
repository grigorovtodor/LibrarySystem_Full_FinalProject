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
    public class BooksController : Controller
    {
        //private LibrarySystemProEntities db = new LibrarySystemProEntities();
        private BookRepository _bookRepo = new BookRepository();
        private AuthorRepository _authorRepo = new AuthorRepository();
        private UserRepository _userRepo = new UserRepository();
        private RentedBookRepository _rentedBookRepo = new RentedBookRepository();


        // GET: Books
        public ActionResult Index()
        {
            var books = _bookRepo.ReadAll();

            var list = new List<Book>();

            foreach (var book in books)
            {
                var current = Mapper.Map<Book>(book);
                current.IsRented = _bookRepo.IsBookRented(current.Id);

                if (_bookRepo.IsBookRented(book.Id))
                {
                    current.DateRented = _rentedBookRepo.BookDateRented(current.Id);
                    current.DateToReturn = _rentedBookRepo.BookDateToReturn(current.Id);
                }

                list.Add(current);
            }

            return View(list);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = Mapper.Map<Book>(_bookRepo.Read(id));
            book.DateRented = _rentedBookRepo.BookDateRented(book.Id);
            book.DateToReturn = _rentedBookRepo.BookDateToReturn(book.Id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ISBN,PageCount,PublishingDate,AuthorId,IsDeleted,IsRented")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Create(Mapper.Map<BookBusiness>(book));
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = Mapper.Map<Book>(_bookRepo.Read(id));

            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ISBN,PageCount,PublishingDate,AuthorId,IsDeleted,IsRented")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Update(Mapper.Map<BookBusiness>(book));
            }
            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = Mapper.Map<Book>(_bookRepo.Read(id));

            if (book == null && book.IsRented != true)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = Mapper.Map<Book>(_bookRepo.Read(id));
            _bookRepo.Delete(Mapper.Map<BookBusiness>(book));
            return RedirectToAction("Index");
        }
    }
}
