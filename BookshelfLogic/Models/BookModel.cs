using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;


namespace BookshelfLogic.Models
{
    public class BookModel
    {
        [Required(ErrorMessage = "Please fill in the title of the book.")]
        [MinLength(1, ErrorMessage = "Please enter the full title")]
        public string Title { get; private set; }
        public string Genre { get; private set; }

        [Required(ErrorMessage = "Please fill in the author.")]
        [MinLength(3, ErrorMessage = "Please enter full name")]
        public AuthorModel Author { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int Rating { get; private set; }

        //TODO image

        public BookModel(string title, string genre, AuthorModel author,
                        string description, DateTime releasedate,  int rating)
        {
            Title = title;
            Genre = genre;
            Author = author;
            Description = description;
            ReleaseDate = releasedate;
            Rating = rating;
        }
    }
}
