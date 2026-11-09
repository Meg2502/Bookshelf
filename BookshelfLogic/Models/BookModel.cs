using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using static BookshelfBL.Models.BookModel;


namespace BookshelfBL.Models
{
    public class BookModel
    {
        public string Title { get; private set; }
        public int AuthorID  { get; private set; }      
        public List<Genre> BookGenre { get; private set; }
        public string Description { get; private set; }
        public DateOnly ReleaseDate { get; private set; }
        public string Publisher { get; private set; }
        public decimal Rating { get; private set; }


        //TODO image

        public BookModel(string title, int authorid,  DateOnly releasedate)
        {
            Title = title;
            AuthorID = authorid;
            ReleaseDate = releasedate;

            
            Rating = 0; 
        }

        public BookModel(string title,  int authorid, List<Genre> bookgenre,
                           string description, DateOnly releasedate, string publisher) : this(title, authorid, releasedate)
        {
            BookGenre = bookgenre;
            Description = description;
            Publisher = publisher;
        }
    }
}
