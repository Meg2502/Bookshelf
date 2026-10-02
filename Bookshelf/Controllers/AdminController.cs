using Microsoft.AspNetCore.Mvc;
using BookshelfLogic.Models;

namespace Bookshelf.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(BookModel Book)
        {
            string title = Book.Title;
            string author = Book.Author?.Name;
            string genre = Book.Genre;
            string description = Book.Description;

            if (!ModelState.IsValid)
                return View(Book);



            return RedirectToPage(); // direct to viewbooks
        }
    }
}
