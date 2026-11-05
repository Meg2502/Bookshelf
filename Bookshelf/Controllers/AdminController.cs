using AspNetCoreGeneratedDocument;
using Bookshelf.ViewModels;
using BookshelfBL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace Bookshelf.Controllers
{
    public class AdminController : Controller
    {
        // private readonly AuthorService _authorService = new AuthorService();
       // private readonly BookService _bookService = new BookService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllBooks()
        {
            return View(new AllBooksViewModel());
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            //ToDo: Get authgors and genres
            //List<AuthorModel> authors = _authorService.GetAllAuthors();
            //  public List<AuthorModel> ExistingAuthors { get; private set; } = new List<AuthorModel>();

            return View(new CreateBookViewModel());
        }

       

        [HttpPost]
        public IActionResult AddBook(CreateBookViewModel Book)
        {
            if (!ModelState.IsValid)
                return View(Book);

            BookModel book = new BookModel(Book.Title, Book.Genre, Book.AuthorID, 
                Book.Description, Book.ReleaseDate, Book.Publisher);

            
            //BookService.CreateBook(book);
            
            //Stap 1: Make a domain model (BookModel) from the CreateBookViewModel
            //Stap 2: Call BookService.CreateBook()

            //ToDo: redirect to correct page
            return RedirectToAction("AllBooks, Admin"); // direct to viewbooks
        }
    }
}
