using BookshelfDAL.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfDAL.Interfaces
{
    public interface IBookRepo
    {
        void Add(BookDTO dto);
        bool BookExists(string title, int authorId);
        //List<BookDTO> GetBooksForList();
    }
}
