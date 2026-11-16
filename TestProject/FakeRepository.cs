using BookshelfDAL.Book;
using BookshelfDAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Tests
{
    public class FakeBookRepository : IBookRepo
    {
        public List<BookDTO> Books { get; } = new List<BookDTO>();

        public bool AddWasCalled { get; private set; }

        public void Add(BookDTO dto)
        {
            AddWasCalled = true;
            Books.Add(dto);
        }

        public bool BookExists(string title, int authorId)
        {
            return Books.Any(book =>
                book.Title == title &&
                book.AuthorId == authorId);
        }
    }
}

/// <summary>
/// Replaces the real BookRepo during unit tests.
/// Stores books in memory so tests do not connect to or change the database.
/// 
/// Both BookRepo and FakeBookRepository implement IBookRepo.
/// This interface defines the methods BookService needs, such as Add
/// and BookExists. BookService depends on IBookRepo, allowing us to pass
/// the real repository in the application and the fake repository in tests.
///
/// The interface lets the fake replace the real repository without inheriting
/// from BookRepo or executing its database code.
/// </summary>