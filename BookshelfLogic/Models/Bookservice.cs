using System;
using System.Collections.Generic;
using System.Text;
using BookshelfDAL;
using BookshelfDAL.Book;

namespace BookshelfBL.Models
{
    public class BookService
    {
        private readonly BookRepo _bookRepository;
        public BookService()
        {
            _bookRepository = new BookRepo();
        }

        public BookDTO CreateBook(BookModel book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new InvalidOperationException("Fill in book title");
            }

            if (book.AuthorID == null)
            {
                throw new InvalidOperationException("Please select an author");
            }


            if (book.ReleaseDate == null)
            {
                throw new ArgumentException("Please select a Releasedate");
            }

            if (_bookRepository.BookExists(book.Title.Trim(), book.AuthorID))
            {
                throw new InvalidOperationException("Book already exists");
            }

            BookDTO dto = new BookDTO()
            {
                Title = book.Title,
                AuthorId = book.AuthorID,
                Description = book.Description,
                ReleaseDate = book.ReleaseDate,
                Publisher = book.Publisher,
                Rating = 0

                //todo convert list genres
                //foreach (Genre in book.SelectedGenres )
                //{
                //BookGenre.Add();
                //}
            };

            _bookRepository.Add(dto);

            return dto;
        }

        public void UpdateBook(BookModel book)
        {
            //todo not this iteration
        }
    }
}
