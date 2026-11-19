using AspNetCoreGeneratedDocument;
using Bookshelf.ViewModels;
using BookshelfBL;
using BookshelfBL.Models;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace Bookshelf.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthorService _authorService = new AuthorService();
        //private readonly AuthorService _authorService; 
        private readonly BookService _bookService;

        public AdminController(BookService bookService)
            //, AuthorService authorservice)
        {
            _bookService = bookService;
            //_authorService = authorservice;
        }

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
            List<AuthorModel> authorsdd = _authorService.GetAuthorsDD();

            var model = new CreateBookViewModel
            {
                ExistingAuthors = authorsdd
            };
            
     

            return View(model);
        }



        [HttpPost]
        public IActionResult AddBook(CreateBookViewModel Book)
        {
            if (!ModelState.IsValid)
            {
                Book.ExistingAuthors = _authorService.GetAuthorsDD();
                return View(Book);
            }

            if (Book.Publisher == null)
            {
                Book.Publisher = "Unknown";
            }

            if (Book.SelectedGenres.Count == 0)
            {
                Book.SelectedGenres.Add(Genre.Unknown);
            }

            BookModel book = new BookModel(Book.Title, Book.AuthorID, Book.SelectedGenres,
                Book.Description, Book.ReleaseDate, Book.Publisher);

            try 
            { 
                _bookService.CreateBook(book);
                return RedirectToAction(nameof(AllBooks));
            }
            catch (InvalidOperationException exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);

                Book.ExistingAuthors = _authorService.GetAuthorsDD();

                return View(Book);
            }

             
        }
    }
}
