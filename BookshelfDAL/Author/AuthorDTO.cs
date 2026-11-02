using System;
using System.Collections.Generic;
using System.Text;
using BookshelfDAL.Book;

namespace BookshelfDAL.Author
{
    public class AuthorDTO
    {
        public string Name { get;  set; }
        public int Id { get;  set; }

        public DateTime Birthdate { get;  set; }
        public string Gender { get; set; }
        public string Biography { get;  set; }
        public List <BookDTO> Books { get; set; } = new List<BookDTO> ();

    }
}
