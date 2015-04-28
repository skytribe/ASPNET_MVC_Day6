using ContactManager.Infrastructure;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {

        private IGenericRepository _repos;

        public ContactsController()
        {

        }

        public ContactsController(IGenericRepository repo)
        {
            _repos = repo;
        }

        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = from m in _repos.Query<Contact>()
                           select m;

            return View(contacts.ToList());

        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            // id is comming from the route controller argument
            // NOT The property from the movie class
            Contact contact = null;

            contact = _repos.Find<Contact>(id);
            if (contact != null)
            {
                return View(contact);
            }

            return RedirectToAction("Index");
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _repos.Add<Contact>(contact);

                _repos.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            Contact contact = null;

            contact = _repos.Find<Contact>(id);
            if (contact != null)
            {
                return View(contact);
            }
            return View();
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            if (ModelState.IsValid)
            {
                var original = _repos.Find<Contact>(contact.Id);
                original.FirstName = contact.FirstName;
                original.LastName = contact.LastName;
                original.Birthday = contact.Birthday;
                original.Phone = contact.Phone;
                _repos.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contact = null;

            contact = _repos.Find<Contact>(id);
            if (contact != null)
            {
                return View(contact);
            }

            return View();
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Contact contact)
        {
            _repos.Delete<Contact>(id);

            _repos.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
