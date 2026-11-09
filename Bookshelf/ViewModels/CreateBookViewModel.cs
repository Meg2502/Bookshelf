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
        public string Title { get; set; }

        [Required(ErrorMessage = "Please select an author.")]
        public int AuthorID { get; set; }
        public List<AuthorModel> ExistingAuthors { get; set; } = new();

        public List<Genre> SelectedGenres { get; set; } = new();
        public List<Genre> Genres { get; set; }

        public string Description { get;  set; }

        public DateOnly ReleaseDate { get; set; }
        public string Publisher { get; set; }

        //TODO image


    }
}
