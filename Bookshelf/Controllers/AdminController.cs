using Microsoft.AspNetCore.Mvc;
using BookshelfBL.Models;

namespace Bookshelf.Controllers
{
    public class BookController : Controller
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
        public IActionResult AddBook(BookModel Book)
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
