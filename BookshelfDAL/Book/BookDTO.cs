using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookshelfDAL.Author;

namespace BookshelfDAL.Book
{
    public class BookDTO
    {
        public string Title { get;  set; }
        public string Genre { get; set; }
       // public List<string> BookGenre { get; set; }
        
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public int Rating { get; set; }

        

    }
}
