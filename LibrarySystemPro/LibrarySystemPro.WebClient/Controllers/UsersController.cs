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
    public class UsersController : Controller
    {
        private BookRepository _bookRepo = new BookRepository();
        private AuthorRepository _authorRepo = new AuthorRepository();
        private UserRepository _userRepo = new UserRepository();
        private RentedBookRepository _rentedBookRepo = new RentedBookRepository();

        // GET: Users
        public ActionResult Index()
        {
            var users = _userRepo.ReadAll();

            var list = new List<User>();

            foreach (var user in users)
            {
                var current = Mapper.Map<User>(user);

                list.Add(current);
            }

            return View(list);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = Mapper.Map<User>(_userRepo.Read(id));

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UniqueIdNumber,Address,Gender,PhoneNumber,Email,IsDeleted")] User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Create(Mapper.Map<UserBusiness>(user));
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = Mapper.Map<User>(_userRepo.Read(id));

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UniqueIdNumber,Address,Gender,PhoneNumber,Email,IsDeleted")] User user)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Update(Mapper.Map<UserBusiness>(user));
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = Mapper.Map<User>(_userRepo.Read(id));

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = Mapper.Map<User>(_userRepo.Read(id));
            _userRepo.Delete(Mapper.Map<UserBusiness>(user));
            return RedirectToAction("Index");
        }


        // GET: Users/Rent/5
        public ActionResult Rent()
        {

            //User user = Mapper.Map<User>(_userRepo.Read(id));
            var rentedBookView = new RentedBook { DateRented = DateTime.Now, DateToReturn = DateTime.Now.AddMonths(1) };

            ViewBag.BookId = new SelectList(_bookRepo.ReadAll(), "Id", "Name");
            ViewBag.UserId = new SelectList(_userRepo.ReadAll(), "Id", "Name");

            return View(rentedBookView);
        }

        // POST: Users/Rent/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rent([Bind(Include = "Id,BookId,UserId,DateRented,DateToReturn,IsDeleted")] RentedBook rentedBook)
        {
            if (ModelState.IsValid)
            {
                _rentedBookRepo.Create(Mapper.Map<RentedBookBusiness>(rentedBook));
                return RedirectToAction("Index");
            }

            return View(rentedBook);
        }

        // GET: Users/Return/5
        public ActionResult Return(int id)
        {
            var rentedBooks = _rentedBookRepo.ReadAll().Where(b => b.UserId == id).ToList();

            var result = new List<RentedBook>();

            foreach (var item in rentedBooks)
            {
                result.Add(Mapper.Map<RentedBook>(item));
            }

            return View(result);
        }

        // POST: Users/Return/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Return(List<int> ids) //[Bind(Include = "Id,BookId,UserId,DateRented,DateToReturn,IsDeleted")]
        {
            foreach (var id in ids)
            {
                    _rentedBookRepo.Delete(id);
            }

            return RedirectToAction("Index");
        }
    }
}
