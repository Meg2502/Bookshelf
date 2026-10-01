using Microsoft.AspNetCore.Mvc;
using BookshelfLogic.Models;

namespace Bookshelf.Controllers
{
    public class AdminController : Controller
    {
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

            //persist book here

            return RedirectToAction(nameof(AddBook)); // ToDO go to book list page 
        }
    }
}
