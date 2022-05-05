using BookControllerMVC.Connect;
using BookControllerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookControllerMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult GetList()
        {
            ConnnectData data = new ConnnectData();
            var books = new List<Book>();
            books = data.getList();
            return View(books);
        }
        public ActionResult Search(string name)
        {
            ConnnectData data = new ConnnectData();
            var books = new List<Book>();
            books = data.searchList(new Book(name));
            return View("GetList", books);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public ActionResult Create(Book book)
        {
            ConnnectData data = new ConnnectData();
            var books = new List<Book>();
            try
            {
                if (ModelState.IsValid)
                {
                    bool fal = data.createBook(book);
                    if (fal)
                    {
                        books = data.getList();
                        return View("GetList", books);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error");
            }

            return View("GetList",books);
        }

        public ActionResult Edit(int id)
        {
            ConnnectData data = new ConnnectData();
            var books = new List<Book>();
            books = data.getList();
            Book book = new Book();
            if(book == null)
            {
                return HttpNotFound();

            }
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            return View(book);
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(int id, string name, string author, string image)
        {
            ConnnectData data = new ConnnectData();
            var books = new List<Book>();
            try
            {
                if (ModelState.IsValid)
                {
                    bool fal = data.editBook(new Book(id, name, author, image));
                    if (fal)
                    {
                        books = data.getList();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error");
            }
            return View("GetList", books);
        }
        public ActionResult Delete(int id)
        {
            ConnnectData data = new ConnnectData();
            var books = new List<Book>();
            data.delete(new Book(id));
            books = data.getList();
            return View("GetList", books);
        }
    }
}