using System;
using System.Collections.Generic;
using System.Text;
using BookshelfDAL;
using BookshelfDAL.Book;

namespace BookshelfBL.Models
{
    public class Bookservice
    {
        private readonly BookRepo _bookRepository;
        public Bookservice(BookRepo bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string CreateBook(BookModel book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new InvalidOperationException("Fill in book title");
            }

            if (book.Author == null)
            {
                throw new InvalidOperationException("Please select an author");
            }

            if (book.Genre == null)
            {
                book.Genre = BookModel.Genres.Unknown;
            }

            if (book.ReleaseDate == null)
            {
                throw new ArgumentException("Please select a Releasedate");
            }

            if (_bookRepository.BookExists(book.Title.Trim(), book.Author.AuthorId))
            {
                throw new InvalidOperationException("Book already exists");
            }
        }

        public void UpdateBook(BookModel book)
        {
            //todo not this iteration
        }
    }
}
