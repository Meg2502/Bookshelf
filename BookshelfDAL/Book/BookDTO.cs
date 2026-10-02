using BookshelfLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookshelfDAL.Book
{
    public class BookDTO
    {
        public string Title { get; private set; }
        public string Genre { get; private set; }
        public AuthorModel Author { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public List<int> Ratings { get; set; } = new List<int>();

    }
}
