using System;
using System.Collections.Generic;
using System.Text;
using BookshelfDAL;
using BookshelfDAL.Book;
using Mysqlx.Crud;

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

            if (book.BookGenre.Count == 0)
            {
                book.BookGenre.Add(Genre.Unknown);
            }

            if (_bookRepository.BookExists(book.Title.Trim(), book.AuthorID))
            {
                throw new ArgumentException("This book already exists"); 
            }

            BookDTO dto = new BookDTO()
            {
                Title = book.Title,
                AuthorId = book.AuthorID,
                Description = book.Description,
                ReleaseDate = book.ReleaseDate,
                Publisher = book.Publisher,
                Rating = 0
            };

            foreach (Genre genre in book.BookGenre)
            {
                dto.BookGenre.Add((int)genre);
            }

            _bookRepository.Add(dto);

                return dto;
            }

        public void UpdateBook(BookModel book)
        {
            //todo not this iteration
        }
    }
}
