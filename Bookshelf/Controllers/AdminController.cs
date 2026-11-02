using Microsoft.AspNetCore.Mvc;
using BookshelfBL.Models;
using Bookshelf.ViewModels;


namespace Bookshelf.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthorService _authorService = new AuthorService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            List<AuthorModel> authors = _authorService.GetAllAuthors();
            //  public List<AuthorModel> ExistingAuthors { get; private set; } = new List<AuthorModel>();

            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookModel Book)
        {
            string title = Book.Title;
            int authorid = Book.AuthorId;
            string genre = Book.Genre;
            string description = Book.Description;

            if (!ModelState.IsValid)
                return View(Book);



            return RedirectToPage(); // direct to viewbooks
        }
    }
}
