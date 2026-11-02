using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using BookshelfBL;
using BookshelfBL.Models;


namespace Bookshelf.ViewModels
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "Please fill in a title.")]
        public string Title { get; private set; }

        [Required(ErrorMessage = "Please select an author.")]
        public int AuthorID { get; private set; }

        public List<AuthorModel> ExistingAuthors { get; private set; } = new List<AuthorModel>();

        [Required(ErrorMessage ="Please select a genre.")]
        public Genre Genre { get; private set; }

        [MinLength(10)]
        public string Description { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        [MinLength(3)]
        public string Publisher { get; private set; }

        //TODO image


    }
}
