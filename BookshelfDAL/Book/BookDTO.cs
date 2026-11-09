using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookshelfDAL.Author;

namespace BookshelfDAL.Book
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public int AuthorId { get; set; }
       // public string Genre { get; set; }
        public List<string> BookGenre { get; set; }

        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public int Rating { get; set; }

        

    }
}
