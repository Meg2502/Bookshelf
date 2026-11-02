using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using static BookshelfBL.Models.BookModel;


namespace BookshelfBL.Models
{
    public class BookModel
    {
        public string Title { get; private set; }
        public AuthorModel Author { get; private set; }      
        public Genre Genre { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Publisher { get; private set; }
        public decimal Rating { get; private set; }

        //TODO image

        public BookModel(string title, AuthorModel author,  DateTime releasedate)
        {
            Title = title;
            Author = author;
            ReleaseDate = releasedate;

            Genre = Genre.Unknown;
            Rating = 0; 
        }

        public BookModel(string title, Genre genre, AuthorModel author,
                           string description, DateTime releasedate, string publisher) : this(title, author, releasedate)
        {
            Genre = genre;
            Description = description;
            Publisher = publisher;
        }
    }
}
